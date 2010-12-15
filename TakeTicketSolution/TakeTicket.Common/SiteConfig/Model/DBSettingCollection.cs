using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TakeTicket.Common.SiteConfig.Model
{
    [Serializable]
    public class DBSettingCollection : CollectionBase
    {
        public DBInfo this[int index]
        {
            get { return (DBInfo)this.List[index]; }
        }

        public DBInfo this[string key]
        {
            get
            {
                return GetDBInfo(key);
            }
        }

        public void Add(DBInfo item)
        {
            this.List.Add(item);
        }

        public DBInfo GetDBInfo(string key)
        {
            foreach (DBInfo item in this.List)
            {
                if (string.Compare(item.ConnectionKey, key, true) == 0)
                {
                    return item;
                }
            }
            return new DBInfo();
        }

        public string GetValue(string key)
        {
            var dbInfo = GetDBInfo(key);
            if (dbInfo != null)
            {
                return dbInfo.ConnectionString;
            }
            return "";
        }
    }
}
