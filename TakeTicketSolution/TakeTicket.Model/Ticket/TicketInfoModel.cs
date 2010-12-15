
#region Using
using System;
#endregion

/*****************************************
功能描述：TicketInfo的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class TicketInfoModel
        {        
            private long _ticketInfoID;
            /// <summary>
            /// 票品信息ID
            /// </summary> 
            public long TicketInfoID
            {
                get { return _ticketInfoID; }
                set { _ticketInfoID = value; }
            }
            
            private string _name;
            /// <summary>
            /// 票品名称
            /// </summary> 
            public string Name
            {
                get { return _name; }
                set { _name = value; }
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
            
            private int _category;
            /// <summary>
            /// 票品类别
            /// </summary> 
            public int Category
            {
                get { return _category; }
                set { _category = value; }
            }
            
            private decimal _priceIntro;
            /// <summary>
            /// 价格介绍
            /// </summary> 
            public decimal PriceIntro
            {
                get { return _priceIntro; }
                set { _priceIntro = value; }
            }
            
            private string _intro;
            /// <summary>
            /// 简介
            /// </summary> 
            public string Intro
            {
                get { return _intro; }
                set { _intro = value; }
            }
            
            private string _detailsIntro;
            /// <summary>
            /// 详情介绍
            /// </summary> 
            public string DetailsIntro
            {
                get { return _detailsIntro; }
                set { _detailsIntro = value; }
            }
            
            private int _featuresCategory;
            /// <summary>
            /// 特色类别
            /// </summary> 
            public int FeaturesCategory
            {
                get { return _featuresCategory; }
                set { _featuresCategory = value; }
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
            
            private int _businessCategory;
            /// <summary>
            /// 商家类别
            /// </summary> 
            public int BusinessCategory
            {
                get { return _businessCategory; }
                set { _businessCategory = value; }
            }
            
            private string _linkAddress;
            /// <summary>
            /// 连接地址
            /// </summary> 
            public string LinkAddress
            {
                get { return _linkAddress; }
                set { _linkAddress = value; }
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
            
            private System.DateTime _updateDate;
            /// <summary>
            /// 修改时间
            /// </summary> 
            public System.DateTime UpdateDate
            {
                get { return _updateDate; }
                set { _updateDate = value; }
            }
            
        }
}
