using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeTicket.Model;
using TakeTicket.DataAccess.Account;

namespace TakeTicket.Bussiness.Account
{
    public class UserInfoManager
    {
        public static bool Save(UserInfoModel userInfo)
        {
            return UserInfoDAL.Save(userInfo);
        }

        /// <summary>
        /// 增加或者保存收货地址
        /// </summary>
        /// <returns></returns>
        public static bool SaveDeliveryAddress(DeliveryAddressModel deliveryAddress)
        {
            return DeliveryAddressDAL.Save(deliveryAddress);
        }
    }
}
