using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeTicket.Model;
using TakeTicket.DataAccess.Order;

namespace TakeTicket.Bussiness.Order
{
    public class OrderManager
    {
        public bool Add(OrderInfoModel orderInfo, List<OrderItemModel> orderItemList)
        {
            return OrderInfoDAL.Save(orderInfo, orderItemList);
        }
    }
}
