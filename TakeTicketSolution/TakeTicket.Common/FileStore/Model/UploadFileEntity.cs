using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeTicket.Common.FileStore
{
    public class UploadFileEntity
    {
        public UploadFileEntity(long id, long companyId, string clientFileName, byte[] content)
        {
            #region
            Id = id;
            CompanyId = companyId;
            ClientFileName = clientFileName;
            Content = content;
            UploadDate = DateTime.Now;
            #endregion
        }

        public UploadFileEntity(long id, string clientFileName, byte[] content)
        {
            #region
            Id = id;
            ClientFileName = clientFileName;
            Content = content;
            UploadDate = DateTime.Now;
            #endregion
        }

        public UploadFileEntity(long id, string clientFileName, byte[] content, string contentType)
        {
            #region
            Id = id;
            ClientFileName = clientFileName;
            Content = content;
            ContentType = contentType;
            UploadDate = DateTime.Now;
            #endregion
        }

        public long CompanyId
        {
            get;
            set;
        }

        public long Id
        {
            get;
            private set;
        }

        public string ClientFileName
        {
            get;
            private set;
        }

        /// <summary>
        /// 文件内容 length=0 不保存
        /// </summary>
        public byte[] Content
        {
            get;
            private set;
        }

        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// 存储到文件服务器的路径
        /// </summary>
        public string ServerStorePath
        {
            get;
            set;
        }

        /// <summary>
        /// 相对路径
        /// </summary>
        public string ServerStoreRelativePath
        {
            get;
            set;
        }

        /// <summary>
        /// 配置文件中的url路径
        /// </summary>
        public string PublishUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 存入数据库的路径
        /// </summary>
        public string PublishUrlPath
        {
            get;
            set;
        }

        /// <summary>
        /// 文件的上传时间
        /// </summary>
        public DateTime UploadDate
        {
            get;
            set;
        }
    }
}
