
#region Using
using System;
#endregion

/*****************************************
功能描述：DeliveryAddress的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class DeliveryAddressModel
        {        
            private long _deliveryAddressID;
            /// <summary>
            /// 收获地址id
            /// </summary> 
            public long DeliveryAddressID
            {
                get { return _deliveryAddressID; }
                set { _deliveryAddressID = value; }
            }
            
            private long _userID;
            /// <summary>
            /// 用户id
            /// </summary> 
            public long UserID
            {
                get { return _userID; }
                set { _userID = value; }
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
            
            private string _postcode;
            /// <summary>
            /// 邮政编码
            /// </summary> 
            public string Postcode
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
            
            private bool _isDefault;
            /// <summary>
            /// 默认收货地址
            /// </summary> 
            public bool IsDefault
            {
                get { return _isDefault; }
                set { _isDefault = value; }
            }
            
        }
}
