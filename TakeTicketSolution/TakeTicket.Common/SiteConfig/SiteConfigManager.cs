using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeTicket.Common.FileStore;
using TakeTicket.Common.SiteConfig.Model;

namespace TakeTicket.Common.SiteConfig
{
    public class SiteConfigManager
    {
        public static SiteConfigManager Intance = null;
        static SiteConfigManager()
        {
            Intance = new SiteConfigManager();
            var filePath = IOUtility.GetRootedFilePath(@"Config\ConfigFilePathSetting.config");
            Intance.FilePathSettings = (ConfigFilePathSetting)SerializerUtility.DeserializeFromXmlFile(filePath, typeof(ConfigFilePathSetting));
        }

        public ConfigFilePathSetting FilePathSettings
        {
            get;
            private set;
        }

        public FileServerMapCollection FileServerMapList
        {
            get
            {
                return FileCacheUtility.GetObjectFromXmlFile(FilePathSettings.FileServerMapPath, typeof(FileServerMapCollection)) as FileServerMapCollection;
            }
        }

        public FileServerCollection FileServerList
        {
            get
            {
                return FileCacheUtility.GetObjectFromXmlFile(FilePathSettings.FileServerPath, typeof(FileServerCollection)) as FileServerCollection;
            }
        }

        public DBSettingCollection DatabaseSettings
        {
            get
            {
                return FileCacheUtility.GetObjectFromXmlFile(FilePathSettings.DatabaseConfigPath, typeof(DBSettingCollection)) as DBSettingCollection;
            }
        }
    }
}
