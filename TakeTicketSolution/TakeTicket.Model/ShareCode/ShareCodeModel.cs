
#region Using
using System;
#endregion

/*****************************************
功能描述：ShareCode的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class ShareCodeModel
        {        
            private long _shareCodeID;
            /// <summary>
            /// 编码id
            /// </summary> 
            public long ShareCodeID
            {
                get { return _shareCodeID; }
                set { _shareCodeID = value; }
            }
            
            private int _classID;
            /// <summary>
            /// 类别id
            /// </summary> 
            public int ClassID
            {
                get { return _classID; }
                set { _classID = value; }
            }
            
            private string _name;
            /// <summary>
            /// 编码名称
            /// </summary> 
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            private string _enName;
            /// <summary>
            /// 编码英文名称
            /// </summary> 
            public string EnName
            {
                get { return _enName; }
                set { _enName = value; }
            }
            
            private System.DateTime _createDate;
            /// <summary>
            /// 创建时间
            /// </summary> 
            public System.DateTime CreateDate
            {
                get { return _createDate; }
                set { _createDate = value; }
            }
            
            private long _parentID;
            /// <summary>
            /// 父id
            /// </summary> 
            public long ParentID
            {
                get { return _parentID; }
                set { _parentID = value; }
            }
            
        }
}
