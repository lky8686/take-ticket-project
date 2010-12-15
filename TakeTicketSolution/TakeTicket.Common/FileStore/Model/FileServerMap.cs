using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TakeTicket.Common.FileStore
{
    [Serializable]
    public class FileServerMap
    {
        public string MapName
        {
            get;
            set;
        }
        
        [XmlAttribute(AttributeName = "mimeItemKey")]
        public string MimeItemKey
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "serviceType")]
        public string ServiceType
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }
    }
}
