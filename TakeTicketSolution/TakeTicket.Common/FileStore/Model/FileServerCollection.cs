using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TakeTicket.Common.FileStore
{
    [Serializable]
    public class FileServerCollection : CollectionBase
    {
        public FileServer this[int index]
        {
            get { return (FileServer)this.List[index]; }
        }

        public void Add(FileServer item)
        {
            this.List.Add(item);
        }

        public FileServer GetFileServer(string mapKey)
        {
            foreach (FileServer item in this.List)
            {
                if (string.Compare(item.MapKey, mapKey, true) == 0)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
