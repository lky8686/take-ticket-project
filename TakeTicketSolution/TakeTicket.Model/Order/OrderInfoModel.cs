
#region Using
using System;
#endregion

/*****************************************
功能描述：OrderInfo的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class OrderInfoModel
        {        
            private long _orderID;
            /// <summary>
            /// 订单id
            /// </summary> 
            public long OrderID
            {
                get { return _orderID; }
                set { _orderID = value; }
            }
            
            private long _userID;
            /// <summary>
            /// 订单人
            /// </summary> 
            public long UserID
            {
                get { return _userID; }
                set { _userID = value; }
            }
            
            private short _status;
            /// <summary>
            /// 订单状态
            /// </summary> 
            public short Status
            {
                get { return _status; }
                set { _status = value; }
            }
            
            private string _consignee;
            /// <summary>
            /// 收货人
            /// </summary> 
            public string Consignee
            {
                get { return _consignee; }
                set { _consignee = value; }
            }
            
            private int _areaID;
            /// <summary>
            /// 地区id
            /// </summary> 
            public int AreaID
            {
                get { return _areaID; }
                set { _areaID = value; }
            }
            
            private int _cityID;
            /// <summary>
            /// 城市id
            /// </summary> 
            public int CityID
            {
                get { return _cityID; }
                set { _cityID = value; }
            }
            
            private string _address;
            /// <summary>
            /// 街道
            /// </summary> 
            public string Address
            {
                get { return _address; }
                set { _address = value; }
            }
            
            private int _postcode;
            /// <summary>
            /// 邮政编码
            /// </summary> 
            public int Postcode
            {
                get { return _postcode; }
                set { _postcode = value; }
            }
            
            private string _phone;
            /// <summary>
            /// 电话
            /// </summary> 
            public string Phone
            {
                get { return _phone; }
                set { _phone = value; }
            }
            
            private string _mobile;
            /// <summary>
            /// 手机
            /// </summary> 
            public string Mobile
            {
                get { return _mobile; }
                set { _mobile = value; }
            }
            
            private decimal _freight;
            /// <summary>
            /// 运费
            /// </summary> 
            public decimal Freight
            {
                get { return _freight; }
                set { _freight = value; }
            }
            
            private int _receivingType;
            /// <summary>
            /// 收货方式
            /// </summary> 
            public int ReceivingType
            {
                get { return _receivingType; }
                set { _receivingType = value; }
            }
            
            private decimal _total;
            /// <summary>
            /// 金额总计
            /// </summary> 
            public decimal Total
            {
                get { return _total; }
                set { _total = value; }
            }
            
            private string _remarks;
            /// <summary>
            /// 备注
            /// </summary> 
            public string Remarks
            {
                get { return _remarks; }
                set { _remarks = value; }
            }
            
            private System.DateTime _createDate;
            /// <summary>
            /// 下单时间
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
