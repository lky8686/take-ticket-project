using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TakeTicket.DataAccess.DBUtility;
using TakeTicket.Model;

namespace TakeTicket.DataAccess.Order
{
    public class OrderDeliveryDetailsDAL
    {
        #region private const
        private const string PARAM_DELIVERY_DETAILS_I = "@DeliveryDetailsID";
        private const string PARAM_ORDER_I = "@OrderID";
        private const string PARAM_DELIVERYMAN = "@Deliveryman";
        private const string PARAM_DELIVERYMAN_PHONE = "@DeliverymanPhone";
        private const string PARAM_EXPRESS = "@Express";
        private const string PARAM_COURIER_NUMBER = "@CourierNumber";

        private static readonly string ConnectionString = SQLHelper.CONNECTION_STRING;
        #endregion

        public static void FillModelFrom(SqlDataReader reader, OrderDeliveryDetailsModel obj)
        {
            #region
            if (reader != null && !reader.IsClosed)
            {
                obj.DeliveryDetailsID = reader.IsDBNull(reader.GetOrdinal("DeliveryDetailsID")) ? 0 : reader.GetInt64(reader.GetOrdinal("DeliveryDetailsID"));
                obj.OrderID = reader.IsDBNull(reader.GetOrdinal("OrderID")) ? 0 : reader.GetInt64(reader.GetOrdinal("OrderID"));
                obj.Deliveryman = reader.IsDBNull(reader.GetOrdinal("Deliveryman")) ? String.Empty : reader.GetString(reader.GetOrdinal("Deliveryman"));
                obj.DeliverymanPhone = reader.IsDBNull(reader.GetOrdinal("DeliverymanPhone")) ? String.Empty : reader.GetString(reader.GetOrdinal("DeliverymanPhone"));
                obj.Express = reader.IsDBNull(reader.GetOrdinal("Express")) ? String.Empty : reader.GetString(reader.GetOrdinal("Express"));
                obj.CourierNumber = reader.IsDBNull(reader.GetOrdinal("CourierNumber")) ? String.Empty : reader.GetString(reader.GetOrdinal("CourierNumber"));
            }
            #endregion
        }

        private static SqlParameter[] GetOrderDeliveryDetailsParams(OrderDeliveryDetailsModel obj)
        {
            #region
            SqlParameter[] dbParams ={					
					 SQLHelper.MakeParam(PARAM_DELIVERY_DETAILS_I, SqlDbType.BigInt,0,obj.DeliveryDetailsID),
					 SQLHelper.MakeParam(PARAM_ORDER_I, SqlDbType.BigInt,0,obj.OrderID),
					 SQLHelper.MakeParam(PARAM_DELIVERYMAN, SqlDbType.NVarChar, 50,obj.Deliveryman),					
					 SQLHelper.MakeParam(PARAM_DELIVERYMAN_PHONE, SqlDbType.NVarChar, 20,obj.DeliverymanPhone),					
					 SQLHelper.MakeParam(PARAM_EXPRESS, SqlDbType.NVarChar, 200,obj.Express),					
					 SQLHelper.MakeParam(PARAM_COURIER_NUMBER, SqlDbType.NVarChar, 100,obj.CourierNumber)					
			};

            return dbParams;
            #endregion
        }

        public static bool Save(OrderDeliveryDetailsModel obj)
        {
            #region
            try
            {
                SqlParameter[] dbParams = GetOrderDeliveryDetailsParams(obj);

                if (obj.DeliveryDetailsID == 0)
                {
                    obj.DeliveryDetailsID = Convert.ToInt32(SQLHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, "OrderDeliveryDetails_InsertUpdate", dbParams));
                    return obj.DeliveryDetailsID > 0 ? true : false;
                }
                else
                {
                    var affectNum = SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "OrderDeliveryDetails_InsertUpdate", dbParams);
                    return affectNum > 0 ? true : false;
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("OrderDeliveryDetails-->InsertOrUpdate-->" + e.Message);

                ExceptionMessageDAL.Record(ex);
            }

            return false;
            #endregion
        }
    }
}
