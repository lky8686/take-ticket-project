using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace TakeTicket.Common.FileStore
{
    public class ImpersonateUser : IDisposable
    {
        #region API

        [DllImport("advapi32.dll")]
        public static extern int LogonUserA(String lpszUserName,
            String lpszDomain,
            String lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        #endregion

        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;

        private bool _LoginSuccessful;
        private WindowsImpersonationContext impersonationContext;

        #region IDisposable Members

        public void Dispose()
        {
            if (_LoginSuccessful) impersonationContext.Undo();
        }

        #endregion

        // 模拟 Windows 用户
        public void ImpersonateValidUser(String domain, String userName, String password)
        {
            #region
            _LoginSuccessful = false;
            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;

            if (RevertToSelf())
            {
                if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
                    LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tempWindowsIdentity.Impersonate();
                        if (impersonationContext != null)
                        {
                            CloseHandle(token);
                            CloseHandle(tokenDuplicate);
                            _LoginSuccessful = true;
                        }
                    }
                }
            }

            if (token != IntPtr.Zero) CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero) CloseHandle(tokenDuplicate);
            #endregion
        }

        public static void ValidUser(ImpersonateUser iu, IdentityModel authentication)
        {
            #region
            if (authentication.Impersonate)
            {
                iu.ImpersonateValidUser(authentication.Domain, authentication.UserName, authentication.Password);
            }
            #endregion
        }
    }

    [Serializable]
    public class IdentityModel
    {
        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Domain
        {
            get;
            set;
        }

        public bool Impersonate
        {
            get;
            set;
        }
    }
}
