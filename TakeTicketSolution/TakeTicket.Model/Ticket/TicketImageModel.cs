
#region Using
using System;
#endregion

/*****************************************
功能描述：TicketImage的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class TicketImageModel
        {        
            private long _imageID;
            /// <summary>
            /// 图片id
            /// </summary> 
            public long ImageID
            {
                get { return _imageID; }
                set { _imageID = value; }
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
            
            private string _hotBigPath;
            /// <summary>
            /// 热点大图
            /// </summary> 
            public string HotBigPath
            {
                get { return _hotBigPath; }
                set { _hotBigPath = value; }
            }
            
            private string _hotSmallPath;
            /// <summary>
            /// 热点小图
            /// </summary> 
            public string HotSmallPath
            {
                get { return _hotSmallPath; }
                set { _hotSmallPath = value; }
            }
            
            private string _imagePath;
            /// <summary>
            /// 订票大图
            /// </summary> 
            public string ImagePath
            {
                get { return _imagePath; }
                set { _imagePath = value; }
            }
            
            private string _seatPath;
            /// <summary>
            /// 座位图
            /// </summary> 
            public string SeatPath
            {
                get { return _seatPath; }
                set { _seatPath = value; }
            }
            
        }
}
