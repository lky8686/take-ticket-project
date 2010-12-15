using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TakeTicket.Common.FileStore
{
    [Serializable]
    public class MimeItem
    {
        [XmlAttribute(AttributeName = "key")]
        public string Key
        {
            get;
            set;
        }

        public string MimeTypeList
        {
            get;
            set;
        }
    }
}
