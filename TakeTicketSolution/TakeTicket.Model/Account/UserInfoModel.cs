
#region Using
using System;
#endregion

/*****************************************
功能描述：UserInfo的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class UserInfoModel
        {        
            private long _userID;
            /// <summary>
            /// 用户id
            /// </summary> 
            public long UserID
            {
                get { return _userID; }
                set { _userID = value; }
            }
            
            private string _email;
            /// <summary>
            /// Email
            /// </summary> 
            public string Email
            {
                get { return _email; }
                set { _email = value; }
            }
            
            private string _loginName;
            /// <summary>
            /// 登录名
            /// </summary> 
            public string LoginName
            {
                get { return _loginName; }
                set { _loginName = value; }
            }
            
            private string _password;
            /// <summary>
            /// 密码
            /// </summary> 
            public string Password
            {
                get { return _password; }
                set { _password = value; }
            }
            
            private bool _sex;
            /// <summary>
            /// 性别
            /// </summary> 
            public bool Sex
            {
                get { return _sex; }
                set { _sex = value; }
            }
            
            private string _mobile;
            /// <summary>
            /// 手机
            /// </summary> 
            public string Mobile
            {
                get { return _mobile; }
                set { _mobile = value; }
            }
            
            private string _realName;
            /// <summary>
            /// 真实姓名
            /// </summary> 
            public string RealName
            {
                get { return _realName; }
                set { _realName = value; }
            }
            
        }
}
