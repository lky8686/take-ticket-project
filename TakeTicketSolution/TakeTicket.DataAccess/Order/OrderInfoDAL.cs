using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeTicket.DataAccess.DBUtility;
using System.Data.SqlClient;
using TakeTicket.Model;
using System.Data;

namespace TakeTicket.DataAccess.Order
{
    public class OrderInfoDAL
    {
        #region private const
        private const string PARAM_ORDER_I = "@OrderID";
        private const string PARAM_USER_ID = "@UserId";
        private const string PARAM_STATUS = "@Status";
        private const string PARAM_CONSIGNEE = "@Consignee";
        private const string PARAM_AREA_I = "@AreaID";
        private const string PARAM_CITY_I = "@CityID";
        private const string PARAM_ADDRESS = "@Address";
        private const string PARAM_POSTCODE = "@Postcode";
        private const string PARAM_PHONE = "@Phone";
        private const string PARAM_MOBILE = "@Mobile";
        private const string PARAM_FREIGHT = "@Freight";
        private const string PARAM_RECEIVING_TYPE = "@ReceivingType";
        private const string PARAM_TOTAL = "@Total";
        private const string PARAM_REMARKS = "@Remarks";
        private const string PARAM_CREATE_DATE = "@CreateDate";
        private const string PARAM_UPDATE_DATE = "@UpdateDate";

        private static readonly string ConnectionString = SQLHelper.CONNECTION_STRING;
        #endregion

        private static void FillModelFrom(SqlDataReader reader, OrderInfoModel obj)
        {
            #region
            if (reader != null && !reader.IsClosed)
            {
                obj.OrderID = reader.IsDBNull(reader.GetOrdinal("OrderID")) ? 0 : reader.GetInt64(reader.GetOrdinal("OrderID"));
                obj.UserID = reader.IsDBNull(reader.GetOrdinal("UserId")) ? 0 : reader.GetInt64(reader.GetOrdinal("UserId"));
                obj.Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? (byte)0 : reader.GetByte(reader.GetOrdinal("Status"));
                obj.Consignee = reader.IsDBNull(reader.GetOrdinal("Consignee")) ? String.Empty : reader.GetString(reader.GetOrdinal("Consignee"));
                obj.AreaID = reader.IsDBNull(reader.GetOrdinal("AreaID")) ? 0 : reader.GetInt32(reader.GetOrdinal("AreaID"));
                obj.CityID = reader.IsDBNull(reader.GetOrdinal("CityID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CityID"));
                obj.Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? String.Empty : reader.GetString(reader.GetOrdinal("Address"));
                obj.Postcode = reader.IsDBNull(reader.GetOrdinal("Postcode")) ? 0 : reader.GetInt32(reader.GetOrdinal("Postcode"));
                obj.Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? String.Empty : reader.GetString(reader.GetOrdinal("Phone"));
                obj.Mobile = reader.IsDBNull(reader.GetOrdinal("Mobile")) ? String.Empty : reader.GetString(reader.GetOrdinal("Mobile"));
                obj.Freight = reader.IsDBNull(reader.GetOrdinal("Freight")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Freight"));
                obj.ReceivingType = reader.IsDBNull(reader.GetOrdinal("ReceivingType")) ? 0 : reader.GetInt32(reader.GetOrdinal("ReceivingType"));
                obj.Total = reader.IsDBNull(reader.GetOrdinal("Total")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Total"));
                obj.Remarks = reader.IsDBNull(reader.GetOrdinal("Remarks")) ? String.Empty : reader.GetString(reader.GetOrdinal("Remarks"));
                obj.CreateDate = reader.IsDBNull(reader.GetOrdinal("CreateDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("CreateDate"));
                obj.UpdateDate = reader.IsDBNull(reader.GetOrdinal("UpdateDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("UpdateDate"));
            }
            #endregion
        }

        private static SqlParameter[] GetOrderInfoParams(OrderInfoModel obj)
        {
            #region
            SqlParameter[] dbParams ={					
					 SQLHelper.MakeParam(PARAM_ORDER_I, SqlDbType.BigInt,0,obj.OrderID),
					 SQLHelper.MakeParam(PARAM_USER_ID, SqlDbType.BigInt,0,obj.UserID),
					 SQLHelper.MakeParam(PARAM_STATUS, SqlDbType.SmallInt,0,obj.Status),
					 SQLHelper.MakeParam(PARAM_CONSIGNEE, SqlDbType.NVarChar, 20,obj.Consignee),					
					 SQLHelper.MakeParam(PARAM_AREA_I, SqlDbType.Int,0,obj.AreaID),
					 SQLHelper.MakeParam(PARAM_CITY_I, SqlDbType.Int,0,obj.CityID),
					 SQLHelper.MakeParam(PARAM_ADDRESS, SqlDbType.NVarChar, 255,obj.Address),					
					 SQLHelper.MakeParam(PARAM_POSTCODE, SqlDbType.Int,0,obj.Postcode),
					 SQLHelper.MakeParam(PARAM_PHONE, SqlDbType.NVarChar, 20,obj.Phone),					
					 SQLHelper.MakeParam(PARAM_MOBILE, SqlDbType.NVarChar, 20,obj.Mobile),					
					 SQLHelper.MakeParam(PARAM_FREIGHT, SqlDbType.Money,0,obj.Freight),
					 SQLHelper.MakeParam(PARAM_RECEIVING_TYPE, SqlDbType.Int,0,obj.ReceivingType),
					 SQLHelper.MakeParam(PARAM_TOTAL, SqlDbType.Money,0,obj.Total),
					 SQLHelper.MakeParam(PARAM_REMARKS, SqlDbType.NVarChar, 500,obj.Remarks),					
			};

            return dbParams;
            #endregion
        }

        private static void FillModelFrom(SqlDataReader reader, OrderMixModel obj)
        {
            #region
            while (reader.Read())
            {//OrderInfo
                FillModelFrom(reader, obj.OrderInfo);
            }

            if (reader.NextResult())
            {//OrderItem
                while (reader.Read())
                {
                    var orderItem = new OrderItemModel();
                    OrderItemDAL.FillModelFrom(reader, orderItem);
                    obj.OrderItemList.Add(orderItem);
                }
            }

            if (reader.NextResult())
            {//OrderDeliveryDetails
                while (reader.Read())
                {
                    OrderDeliveryDetailsDAL.FillModelFrom(reader, obj.OrderDeliveryDetails);
                }
            }
            #endregion
        }

        public static bool Save(OrderInfoModel obj,List<OrderItemModel> orderItemList)
        {
            #region
            bool executeStatus = false;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction sqlTran = conn.BeginTransaction();
                executeStatus = true;
                try
                {
                    SqlParameter[] dbParams = GetOrderInfoParams(obj);
                    obj.OrderID = Convert.ToInt32(SQLHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, "OrderInfo_Insert", dbParams));

                    if (obj.OrderID > 0)
                    {
                        foreach (var item in orderItemList)
                        {
                            executeStatus = OrderItemDAL.Save(item, sqlTran);
                            if (executeStatus == false)
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    executeStatus = false;

                    Exception ex = new Exception("OrderInfo-->Insert-->" + e.Message);
                    ExceptionMessageDAL.Record(ex);
                }

                if (executeStatus)
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
            }
            return executeStatus;
            #endregion
        }

        public static OrderMixModel GetOrderMixInfo(long orderId, long userId)
        {
            #region
            OrderMixModel result = new OrderMixModel();
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[] { 
                    SQLHelper.MakeParam(PARAM_ORDER_I,SqlDbType.BigInt,0,orderId),
                    SQLHelper.MakeParam(PARAM_USER_ID,SqlDbType.BigInt,0,userId)
                };

                reader = SQLHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, "OrderInfo_GetOrderMixInfo", dbParams);
                FillModelFrom(reader, result);
            }
            catch (Exception e)
            {
                ExceptionMessageDAL.Record(e);
            }
            finally
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }
            }
            return result;
            #endregion
        }
    }
}
