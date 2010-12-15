
#region Using
using System;
#endregion

/*****************************************
功能描述：ShareCodeClass的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class ShareCodeClassModel
        {        
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
            /// 类别名称
            /// </summary> 
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            private string _enName;
            /// <summary>
            /// 类别英文名称
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
            
        }
}
