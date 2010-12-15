
#region Using
using System;
#endregion

/*****************************************
功能描述：TicketComments的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class TicketCommentsModel
        {        
            private long _commentID;
            /// <summary>
            /// ID
            /// </summary> 
            public long CommentID
            {
                get { return _commentID; }
                set { _commentID = value; }
            }
            
            private long _ticketInfoID;
            /// <summary>
            /// 票品id
            /// </summary> 
            public long TicketInfoID
            {
                get { return _ticketInfoID; }
                set { _ticketInfoID = value; }
            }
            
            private long _userID;
            /// <summary>
            /// 评论人id
            /// </summary> 
            public long UserID
            {
                get { return _userID; }
                set { _userID = value; }
            }
            
            private string _content;
            /// <summary>
            /// 评论内容
            /// </summary> 
            public string Content
            {
                get { return _content; }
                set { _content = value; }
            }
            
            private System.DateTime _createDate;
            /// <summary>
            /// 评论时间
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
