using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using TakeTicket.Common.SiteConfig;

namespace TakeTicket.Common.FileStore
{
    public abstract class FileUploadProviderBase : IFileUploadProvider
    {
        #region protected

        protected FileServerMap _FileServerMap = null;
        protected FileServer _FileServer = null;
        protected UploadFileEntity _UploadFileEntity = null;
        protected string _ServiceType = null;
        protected string _MimeItemKey = "image";

        #endregion

        public virtual string FileServerRootPath
        {
            get;
            set;
        }

        protected virtual void MatchFileServer()
        {
            #region

            _FileServerMap = SiteConfigManager.Intance.FileServerMapList.GetFileServerMap(_UploadFileEntity.UploadDate, _ServiceType);
            if (_FileServerMap == null)
            {
                throw new Exception("查询不到文件服务器匹配节点");
            }
            else
            {
                _FileServer = SiteConfigManager.Intance.FileServerList.GetFileServer(_FileServerMap.MapName);
                if (_FileServer == null)
                {
                    throw new Exception("根据节点‘" + _FileServerMap.MapName + "’查询不到服务器");
                }
            }
            FileServerRootPath = _FileServer.RootPath;
            #endregion
        }

        protected virtual void ValidateFileMime()
        {
            #region
            var extName = Path.GetExtension(_UploadFileEntity.ClientFileName).ToLower();
            var flag = false;
            MimeItem mimeItem = _FileServer.MimeItemList.GetMimeItem(_MimeItemKey);
            if (mimeItem != null)
            {
                flag = mimeItem.MimeTypeList.Split(';').ToList<string>().Contains(extName);
                if (flag == false)
                {
                    throw new Exception("上传的文件扩展名未知" + extName);
                }
            }
            #endregion
        }

        public virtual void Save()
        {
            #region
            if (_UploadFileEntity.Content.Length <= 0)
                return;
            using (ImpersonateUser iu = new ImpersonateUser())
            {
                ImpersonateUser.ValidUser(iu, _FileServer.Indentity);

                string dirPath = Path.GetDirectoryName(_UploadFileEntity.ServerStorePath);
                if (!System.IO.Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                using (FileStream writer = File.Open(_UploadFileEntity.ServerStorePath, FileMode.OpenOrCreate))
                {
                    writer.Write(_UploadFileEntity.Content, 0, _UploadFileEntity.Content.Length);
                    writer.Flush();
                    writer.Close();
                }
            }
            #endregion
        }

        public virtual void Delete()
        {
            #region
            using (ImpersonateUser iu = new ImpersonateUser())
            {
                ImpersonateUser.ValidUser(iu, _FileServer.Indentity);

                if (File.Exists(_UploadFileEntity.ServerStorePath))
                {
                    File.Delete(_UploadFileEntity.ServerStorePath);
                }
            }
            #endregion
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        public virtual string Read(string filePath)
        {
            #region
            var result = "";
            using (ImpersonateUser iu = new ImpersonateUser())
            {
                ImpersonateUser.ValidUser(iu, _FileServer.Indentity);

                if (File.Exists(filePath))
                {
                    using (FileStream reader = File.Open(filePath, FileMode.OpenOrCreate))
                    {
                        var content = new byte[reader.Length];
                        reader.Read(content, 0, content.Length);
                        reader.Close();
                        result = System.Text.Encoding.Default.GetString(content);
                    }
                }
            }
            return result;
            #endregion
        }

        /// <summary>
        /// 将指定的文件直接写入 HTTP 响应输出流，而不在内存中缓冲该文件。
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="response"></param>
        public virtual bool TransmitFile(string fileName, string filePath, HttpResponse Response)
        {
            #region
            var flag = false;
            using (ImpersonateUser iu = new ImpersonateUser())
            {
                ImpersonateUser.ValidUser(iu, _FileServer.Indentity);

                //if (File.Exists(filePath))
                //{
                //    response.TransmitFile(filePath);
                //    flag = true;
                //}
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
                if (fileInfo.Exists == true)
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
                    const long ChunkSize = 102400;//100K 每次读取文件，只读取100Ｋ，这样可以缓解服务器的压力
                    byte[] buffer = new byte[ChunkSize];
                    Response.Clear();
                    System.IO.FileStream fileStream = System.IO.File.OpenRead(filePath);
                    long dataTotalLength = fileStream.Length;
                    int readDataLength = 0;
                    while (dataTotalLength > 0 && Response.IsClientConnected)
                    {
                        readDataLength = fileStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));
                        Response.OutputStream.Write(buffer, 0, readDataLength);
                        Response.Flush();
                        dataTotalLength = dataTotalLength - readDataLength;
                    }
                    Response.Close();

                    flag = true;
                }
            }
            return flag;
            #endregion
        }
    }
}
