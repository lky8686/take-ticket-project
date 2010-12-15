using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeTicket.Common.SiteConfig
{
    [Serializable]
    public class ConfigFilePathSetting
    {
        /// <summary>
        /// 根据这个文件中的配置 查找文件应该存储的位置
        /// </summary>
        public string FileServerMapPath
        {
            get;
            set;
        }

        public string FileServerPath
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库连接配置文件路径
        /// </summary>
        public string DatabaseConfigPath
        {
            get;
            set;
        }

    }
}
