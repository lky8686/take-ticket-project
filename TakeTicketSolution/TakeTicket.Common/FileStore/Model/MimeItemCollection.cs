using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TakeTicket.Common.FileStore
{
    [Serializable]
    public class MimeItemCollection : CollectionBase
    {
        public MimeItem this[int index]
        {
            get
            {
                return (MimeItem)this.List[index];
            }
        }

        public int Add(MimeItem item)
        {
            return this.List.Add(item);
        }

        public MimeItem GetMimeItem(string mimeItemKey)
        {
            foreach (MimeItem item in this.List)
            {
                if (string.IsNullOrEmpty(item.Key))
                {
                    continue;
                }

                if (string.Compare(item.Key, mimeItemKey, true)==0)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
