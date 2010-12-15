using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace TakeTicket.Common
{
    public class IOUtility
    {
        /// <summary>获取文件全路径</summary>
        /// <param name="File">相对|绝对</param>
        /// <returns></returns>
        public static string GetRootedFilePath(string FilePath)
        {
            if (Path.IsPathRooted(FilePath))
                return FilePath;

            string rootPath = HttpRuntime.AppDomainAppPath;

            if (string.IsNullOrEmpty(rootPath)) return rootPath;

            return Path.Combine(rootPath, FilePath);
        }
    }
}
