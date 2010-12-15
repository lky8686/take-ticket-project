
#region Using
using System;
#endregion

/*****************************************
功能描述：OrderDeliveryDetails的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class OrderDeliveryDetailsModel
        {        
            private long _deliveryDetailsID;
            /// <summary>
            /// id
            /// </summary> 
            public long DeliveryDetailsID
            {
                get { return _deliveryDetailsID; }
                set { _deliveryDetailsID = value; }
            }
            
            private long _orderID;
            /// <summary>
            /// 订单id
            /// </summary> 
            public long OrderID
            {
                get { return _orderID; }
                set { _orderID = value; }
            }
            
            private string _deliveryman;
            /// <summary>
            /// 送货人
            /// </summary> 
            public string Deliveryman
            {
                get { return _deliveryman; }
                set { _deliveryman = value; }
            }
            
            private string _deliverymanPhone;
            /// <summary>
            /// 送货人手机
            /// </summary> 
            public string DeliverymanPhone
            {
                get { return _deliverymanPhone; }
                set { _deliverymanPhone = value; }
            }
            
            private string _express;
            /// <summary>
            /// 快递公司
            /// </summary> 
            public string Express
            {
                get { return _express; }
                set { _express = value; }
            }
            
            private string _courierNumber;
            /// <summary>
            /// 快递编号
            /// </summary> 
            public string CourierNumber
            {
                get { return _courierNumber; }
                set { _courierNumber = value; }
            }
            
        }
}
