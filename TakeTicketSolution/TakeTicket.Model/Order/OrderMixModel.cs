using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeTicket.Model
{
    public class OrderMixModel
    {
        public OrderMixModel()
        {
            OrderInfo = new OrderInfoModel();
            OrderItemList = new List<OrderItemModel>();
            OrderDeliveryDetails = new OrderDeliveryDetailsModel();
        }

        public OrderInfoModel OrderInfo
        {
            get;
            set;
        }

        public List<OrderItemModel> OrderItemList
        {
            get;
            set;
        }

        public OrderDeliveryDetailsModel OrderDeliveryDetails
        {
            get;
            set;
        }

    }
}
