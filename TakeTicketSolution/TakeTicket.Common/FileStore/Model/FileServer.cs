using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace TakeTicket.Common.FileStore
{
    [Serializable]
    public class FileServer
    {
        #region
        [XmlAttribute(AttributeName = "key")]
        public string MapKey
        {
            get;
            set;
        }

        public string RootPath
        {
            get;
            set;
        }

        public string PublishUrl
        {
            get;
            set;
        }

        public IdentityModel Indentity
        {
            get;
            set;
        }

        [XmlArray(ElementName = "ArrayOfMimeItem")]
        public MimeItemCollection MimeItemList
        {
            get;
            set;
        }
        #endregion
    }
    [Serializable]
    public class FileStoreServerCollection : IList<FileServer>
    {
        #region
        private FileServer[] list;
        private int count = 0;

        public FileStoreServerCollection()
        {
            list = new FileServer[0x10];
        }

        internal FileStoreServerCollection(FileStoreServerCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            this.list = new FileServer[collection.Count];
            this.AddRange(collection);
        }

        internal FileStoreServerCollection(FileServer[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            this.list = new FileServer[array.Length];
            this.AddRange(array);
        }

        public virtual void AddRange(FileServer[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (array.Length != 0)
            {
                this.ValidateIndex(this.count + array.Length);
                Array.Copy(array, 0, this.list, this.count, array.Length);
                this.count += array.Length;
            }
        }

        public virtual void AddRange(FileStoreServerCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            if (collection.Count != 0)
            {
                this.ValidateIndex(this.count + collection.Count);
                Array.Copy(collection.list, 0, this.list, this.count, collection.Count);
                this.count += collection.Count;
            }
        }

        private bool ValidateIndex(int index)
        {
            #region

            if (index >= this.list.Length)
            {
                throw new ArgumentOutOfRangeException("index 超出最大容量15");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index 小于0");
            }
            if (index > this.count)
            {
                throw new ArgumentOutOfRangeException("index 超出总数");
            }
            return true;
            #endregion
        }

        private void CheckTargetArray(Array array, int arrayIndex)
        {
            #region
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (array.Rank > 1)
            {
                throw new ArgumentException("Argument cannot be multidimensional.", "array");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", arrayIndex, "Argument cannot be negative.");
            }
            if (arrayIndex >= array.Length)
            {
                throw new ArgumentException("Argument must be less than array length.", "arrayIndex");
            }
            if (this.count > (array.Length - arrayIndex))
            {
                throw new ArgumentException("Argument section must be large enough for collection.", "array");
            }
            #endregion
        }

        private void CheckEnumIndex(int index)
        {
            if ((index < 0) || (index >= this.count))
            {
                throw new InvalidOperationException("Enumerator is not on a collection element.");
            }
        }

        #region IList<FileStoreServer> 成员

        public int IndexOf(FileServer item)
        {
            return Array.IndexOf(list, item, 0, this.count);
        }

        public void Insert(int index, FileServer item)
        {
            this.ValidateIndex(index);
            Array.Copy(this.list, index, this.list, index + 1, this.count - index);
            list[index] = item;
            this.count++;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            var num = 0;
            this.count = num = this.count - 1;
            Array.Copy(this.list, index + 1, this.list, index, this.count - index);
        }

        public FileServer this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return list[index];
            }
            set
            {
                this.ValidateIndex(index);
                list[index] = value;
            }
        }

        #endregion

        #region ICollection<FileStoreServer> 成员

        public void Add(FileServer item)
        {
            this.ValidateIndex(this.count);
            this.list[this.count] = item;
            this.count = this.count + 1;
        }

        public void Clear()
        {
            if (this.count != 0)
            {
                Array.Clear(this.list, 0, this.count);
                this.count = 0;
            }
        }

        public bool Contains(FileServer item)
        {
            return this.IndexOf(item) > 0 ? true : false;
        }

        public void CopyTo(FileServer[] array, int arrayIndex)
        {
            this.CheckTargetArray(array, arrayIndex);
            Array.Copy(this.list, 0, array, arrayIndex, this.count);
        }

        public int Count
        {
            get { return this.count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(FileServer item)
        {
            var index = this.IndexOf(item);
            if (index >= 0)
            {
                this.RemoveAt(index);
                return true;
            }
            return false;
        }

        #endregion

        #region IEnumerable<FileStoreServer> 成员

        public IEnumerator<FileServer> GetEnumerator()
        {
            return new IFileStoreServerEnumerator(this);
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        [Serializable]
        private sealed class IFileStoreServerEnumerator : IEnumerator<FileServer>
        {
            private readonly FileStoreServerCollection _collection;
            private int _index = -1;

            internal IFileStoreServerEnumerator(FileStoreServerCollection collection)
            {
                this._collection = collection;
                this._index = -1;
            }

            #region IEnumerator<FileStoreServer> 成员

            public FileServer Current
            {
                get
                {
                    _collection.CheckEnumIndex(this._index);
                    return this._collection[this._index];
                }
            }

            #endregion

            #region IDisposable 成员

            public void Dispose()
            {

            }

            #endregion

            #region IEnumerator 成员

            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                var num = 0;
                this._index = num = this._index + 1;
                return (num < this._collection.Count);
            }

            public void Reset()
            {
                this._index = -1;
            }

            #endregion
        }
        #endregion
    }
}
