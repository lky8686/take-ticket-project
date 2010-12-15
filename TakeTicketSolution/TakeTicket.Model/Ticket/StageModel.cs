
#region Using
using System;
#endregion

/*****************************************
功能描述：Stage的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class StageModel
        {        
            private long _stageID;
            /// <summary>
            /// 场次id
            /// </summary> 
            public long StageID
            {
                get { return _stageID; }
                set { _stageID = value; }
            }
            
            private long _placeID;
            /// <summary>
            /// 场馆id
            /// </summary> 
            public long PlaceID
            {
                get { return _placeID; }
                set { _placeID = value; }
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
            
            private short _status;
            /// <summary>
            /// 状态
            /// </summary> 
            public short Status
            {
                get { return _status; }
                set { _status = value; }
            }
            
            private System.DateTime _beginTime;
            /// <summary>
            /// 上演时间
            /// </summary> 
            public System.DateTime BeginTime
            {
                get { return _beginTime; }
                set { _beginTime = value; }
            }
            
            private System.DateTime _endTime;
            /// <summary>
            /// 结束时间
            /// </summary> 
            public System.DateTime EndTime
            {
                get { return _endTime; }
                set { _endTime = value; }
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
