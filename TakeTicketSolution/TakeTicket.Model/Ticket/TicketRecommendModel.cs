
#region Using
using System;
#endregion

/*****************************************
功能描述：TicketRecommend的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class TicketRecommendModel
        {        
            private long _ticketInfoID;
            /// <summary>
            /// 票品id
            /// </summary> 
            public long TicketInfoID
            {
                get { return _ticketInfoID; }
                set { _ticketInfoID = value; }
            }
            
            private int _recommendCategory;
            /// <summary>
            /// 推荐类别
            /// </summary> 
            public int RecommendCategory
            {
                get { return _recommendCategory; }
                set { _recommendCategory = value; }
            }
            
        }
}
