
#region Using
using System;
#endregion

/*****************************************
功能描述：OrderItem的实体类。
创建时间：2010/12/14 16:58:51
******************************************/
namespace TakeTicket.Model
{
        public class OrderItemModel
        {        
            private long _orderItemID;
            /// <summary>
            /// 项目id
            /// </summary> 
            public long OrderItemID
            {
                get { return _orderItemID; }
                set { _orderItemID = value; }
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
            
            private long _productID;
            /// <summary>
            /// 商品id
            /// </summary> 
            public long ProductID
            {
                get { return _productID; }
                set { _productID = value; }
            }
            
            private int _number;
            /// <summary>
            /// 数量
            /// </summary> 
            public int Number
            {
                get { return _number; }
                set { _number = value; }
            }
            
            private decimal _price;
            /// <summary>
            /// 价格
            /// </summary> 
            public decimal Price
            {
                get { return _price; }
                set { _price = value; }
            }
            
        }
}
