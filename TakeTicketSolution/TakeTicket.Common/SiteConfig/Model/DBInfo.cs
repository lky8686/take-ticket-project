using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TakeTicket.Common.SiteConfig.Model
{
    [Serializable]
    public class DBInfo
    {
        [XmlAttribute(AttributeName = "connectionKey")]
        public string ConnectionKey
        {
            get;
            set;
        }
        [XmlAttribute(AttributeName = "connectionString")]
        public string ConnectionString
        {
            get;
            set;
        }
    }
}
