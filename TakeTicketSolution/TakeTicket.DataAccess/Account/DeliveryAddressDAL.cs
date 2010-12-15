using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TakeTicket.DataAccess.DBUtility;
using System.Data;
using TakeTicket.Model;

namespace TakeTicket.DataAccess.Account
{
    public class DeliveryAddressDAL
    {
        #region private const
        private const string PARAM_DELIVERY_ADDRESS_I = "@DeliveryAddressID";
        private const string PARAM_USER_I = "@UserID";
        private const string PARAM_CONSIGNEE = "@Consignee";
        private const string PARAM_AREA_I = "@AreaID";
        private const string PARAM_CITY_I = "@CityID";
        private const string PARAM_ADDRESS = "@Address";
        private const string PARAM_POSTCODE = "@Postcode";
        private const string PARAM_PHONE = "@Phone";
        private const string PARAM_MOBILE = "@Mobile";
        private const string PARAM_IS_DEFAULT = "@IsDefault";

        private static readonly string ConnectionString = SQLHelper.CONNECTION_STRING;
        #endregion

        private static void FillModelFrom(SqlDataReader reader, DeliveryAddressModel obj)
        {
            #region
            if (reader != null && !reader.IsClosed)
            {
                obj.DeliveryAddressID = reader.IsDBNull(reader.GetOrdinal("DeliveryAddressID")) ? 0 : reader.GetInt64(reader.GetOrdinal("DeliveryAddressID"));
                obj.UserID = reader.IsDBNull(reader.GetOrdinal("UserID")) ? 0 : reader.GetInt64(reader.GetOrdinal("UserID"));
                obj.Consignee = reader.IsDBNull(reader.GetOrdinal("Consignee")) ? String.Empty : reader.GetString(reader.GetOrdinal("Consignee"));
                obj.AreaID = reader.IsDBNull(reader.GetOrdinal("AreaID")) ? 0 : reader.GetInt32(reader.GetOrdinal("AreaID"));
                obj.CityID = reader.IsDBNull(reader.GetOrdinal("CityID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CityID"));
                obj.Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? String.Empty : reader.GetString(reader.GetOrdinal("Address"));
                obj.Postcode = reader.IsDBNull(reader.GetOrdinal("Postcode")) ? String.Empty : reader.GetString(reader.GetOrdinal("Postcode"));
                obj.Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? String.Empty : reader.GetString(reader.GetOrdinal("Phone"));
                obj.Mobile = reader.IsDBNull(reader.GetOrdinal("Mobile")) ? String.Empty : reader.GetString(reader.GetOrdinal("Mobile"));
                obj.IsDefault = reader.IsDBNull(reader.GetOrdinal("IsDefault")) ? false : reader.GetBoolean(reader.GetOrdinal("IsDefault"));
            }
            #endregion
        }

        private static SqlParameter[] GetDeliveryAddressParams(DeliveryAddressModel obj)
        {
            #region
            SqlParameter[] dbParams ={					
					 SQLHelper.MakeParam(PARAM_DELIVERY_ADDRESS_I, SqlDbType.BigInt,0,obj.DeliveryAddressID),
					 SQLHelper.MakeParam(PARAM_USER_I, SqlDbType.BigInt,0,obj.UserID),
					 SQLHelper.MakeParam(PARAM_CONSIGNEE, SqlDbType.NVarChar, 20,obj.Consignee),					
					 SQLHelper.MakeParam(PARAM_AREA_I, SqlDbType.Int,0,obj.AreaID),
					 SQLHelper.MakeParam(PARAM_CITY_I, SqlDbType.Int,0,obj.CityID),
					 SQLHelper.MakeParam(PARAM_ADDRESS, SqlDbType.NVarChar, 100,obj.Address),					
					 SQLHelper.MakeParam(PARAM_POSTCODE, SqlDbType.NVarChar, 10,obj.Postcode),					
					 SQLHelper.MakeParam(PARAM_PHONE, SqlDbType.NVarChar, 20,obj.Phone),					
					 SQLHelper.MakeParam(PARAM_MOBILE, SqlDbType.NVarChar, 20,obj.Mobile),					
					 SQLHelper.MakeParam(PARAM_IS_DEFAULT, SqlDbType.Bit,0,obj.IsDefault)
			};

            return dbParams;
            #endregion
        }

        public static bool Save(DeliveryAddressModel obj)
        {
            #region
            try
            {
                SqlParameter[] dbParams = GetDeliveryAddressParams(obj);

                if (obj.DeliveryAddressID == 0)
                {
                    obj.DeliveryAddressID = Convert.ToInt32(SQLHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, "DeliveryAddress_InsertUpdate", dbParams));
                    return obj.DeliveryAddressID > 0 ? true : false;
                }
                else
                {
                    var affectNum = SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DeliveryAddress_InsertUpdate", dbParams);
                    return affectNum > 0 ? true : false;
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("DeliveryAddress-->InsertOrUpdate-->" + e.Message);

                ExceptionMessageDAL.Record(ex);
            }

            return false;
            #endregion
        }
    }
}
