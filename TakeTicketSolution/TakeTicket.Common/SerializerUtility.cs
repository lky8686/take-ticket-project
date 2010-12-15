using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TakeTicket.Common
{
    public class SerializerUtility
    {
        public static MemoryStream SerializeToStream(Object obj)
        {
            #region
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.Default);
            xs.Serialize(writer, obj);
            writer.Close();
            return mem;
            #endregion
        }

        public static string SerializeToXmlString(Object obj)
        {
            MemoryStream mem = SerializeToStream(obj);
            var result = Encoding.Default.GetString(mem.ToArray());
            return result;
        }

        public static object DeserializeFromXmlString(string xmlString, Type t)
        {
            #region
            XmlSerializer xs = new XmlSerializer(t);
            MemoryStream mem = new MemoryStream(Encoding.Default.GetBytes(xmlString));
            StreamReader reader = new StreamReader(mem, Encoding.Default);
            object obj = xs.Deserialize(reader);
            reader.Close();
            return obj;
            #endregion
        }

        public static object DeserializeFromXmlFile(string filePath, Type t)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);            //直接open file 会报权限不够
            return DeserializeFromXmlText(doc.OuterXml, t);
        }

        public static object DeserializeFromXmlText(string xmlText, Type t)
        {
            XmlSerializer xs = new XmlSerializer(t);
            StreamReader reader = new StreamReader(new MemoryStream(Encoding.Default.GetBytes(xmlText)), Encoding.Default);
            object obj = xs.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}
