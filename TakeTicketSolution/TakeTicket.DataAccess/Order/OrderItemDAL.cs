using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TakeTicket.DataAccess.DBUtility;
using System.Data;
using TakeTicket.Model;

namespace TakeTicket.DataAccess.Order
{
    public class OrderItemDAL
    {
        #region private const
        private const string PARAM_ORDER_ITEM_I = "@OrderItemID";
        private const string PARAM_ORDER_I = "@OrderID";
        private const string PARAM_PRODUCT_I = "@ProductID";
        private const string PARAM_NUMBER = "@Number";
        private const string PARAM_PRICE = "@Price";

        private static readonly string ConnectionString = SQLHelper.CONNECTION_STRING;
        #endregion

        public static void FillModelFrom(SqlDataReader reader, OrderItemModel obj)
        {
            #region
            if (reader != null && !reader.IsClosed)
            {
                obj.OrderItemID = reader.IsDBNull(reader.GetOrdinal("OrderItemID")) ? 0 : reader.GetInt64(reader.GetOrdinal("OrderItemID"));
                obj.OrderID = reader.IsDBNull(reader.GetOrdinal("OrderID")) ? 0 : reader.GetInt64(reader.GetOrdinal("OrderID"));
                obj.ProductID = reader.IsDBNull(reader.GetOrdinal("ProductID")) ? 0 : reader.GetInt64(reader.GetOrdinal("ProductID"));
                obj.Number = reader.IsDBNull(reader.GetOrdinal("Number")) ? 0 : reader.GetInt32(reader.GetOrdinal("Number"));
                obj.Price = reader.IsDBNull(reader.GetOrdinal("Price")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Price"));
            }
            #endregion
        }

        private static SqlParameter[] GetOrderItemParams(OrderItemModel obj)
        {
            #region
            SqlParameter[] dbParams ={					
					 SQLHelper.MakeParam(PARAM_ORDER_ITEM_I, SqlDbType.BigInt,0,obj.OrderItemID),
					 SQLHelper.MakeParam(PARAM_ORDER_I, SqlDbType.BigInt,0,obj.OrderID),
					 SQLHelper.MakeParam(PARAM_PRODUCT_I, SqlDbType.BigInt,0,obj.ProductID),
					 SQLHelper.MakeParam(PARAM_NUMBER, SqlDbType.Int,0,obj.Number),
					 SQLHelper.MakeParam(PARAM_PRICE, SqlDbType.Money,0,obj.Price)
			};

            return dbParams;
            #endregion
        }

        public static bool Save(OrderItemModel obj, SqlTransaction sqlTran)
        {
            #region

            SqlParameter[] dbParams = GetOrderItemParams(obj);

            obj.OrderItemID = Convert.ToInt32(SQLHelper.ExecuteScalar(sqlTran, CommandType.StoredProcedure, "OrderItem_Insert", dbParams));
            return obj.OrderItemID > 0 ? true : false;
            #endregion
        }
    }
}
