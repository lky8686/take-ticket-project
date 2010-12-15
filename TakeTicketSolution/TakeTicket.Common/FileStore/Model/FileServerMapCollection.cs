using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TakeTicket.Common.FileStore
{
    [Serializable]
    public class FileServerMapCollection : CollectionBase
    {
        public FileServerMap this[int index]
        {
            get { return (FileServerMap)this.List[index]; }
        }

        public void Add(FileServerMap item)
        {
            this.List.Add(item);
        }

        public FileServerMap GetFileServerMap(string serviceType)
        {
            foreach (FileServerMap item in this.List)
            {
                if (string.Compare(item.ServiceType, serviceType, true) == 0)
                {
                    return item;
                }
            }
            return null;
        }

        public FileServerMap GetFileServerMap(DateTime uploadDate, string serviceType)
        {
            foreach (FileServerMap item in this.List)
            {
                if (string.Compare(item.ServiceType, serviceType, true) == 0
                    && uploadDate >= item.StartDate && uploadDate < item.EndDate)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
