using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Web;

namespace TakeTicket.Common.FileStore
{
    public enum ExistAction
    {
        Overwrite,
        Exception,
        Rename
    }
    public enum FileNameMethod
    {
        Client,
        Guid,
        Custom
    }

    public interface IFileUploadProvider
    {
        void Save();
        void Delete();
        string Read(string filePath);
        bool TransmitFile(string fileName, string filePath, HttpResponse response);
        /// <summary>
        /// 文件服务器根路径
        /// </summary>
        string FileServerRootPath { get; set; }
    }
}
