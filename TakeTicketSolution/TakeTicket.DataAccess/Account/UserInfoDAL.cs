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
    public class UserInfoDAL
    {
        #region private const
        private const string PARAM_USER_I = "@UserID";
        private const string PARAM_EMAIL = "@Email";
        private const string PARAM_LOGIN_NAME = "@LoginName";
        private const string PARAM_PASSWORD = "@Password";
        private const string PARAM_SEX = "@Sex";
        private const string PARAM_MOBILE = "@Mobile";
        private const string PARAM_REAL_NAME = "@RealName";

        private static readonly string ConnectionString = SQLHelper.CONNECTION_STRING;
        #endregion

        private static void FillModelFrom(SqlDataReader reader, UserInfoModel obj)
        {
            #region
            if (reader != null && !reader.IsClosed)
            {
                obj.UserID = reader.IsDBNull(reader.GetOrdinal("UserID")) ? 0 : reader.GetInt64(reader.GetOrdinal("UserID"));
                obj.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? String.Empty : reader.GetString(reader.GetOrdinal("Email"));
                obj.LoginName = reader.IsDBNull(reader.GetOrdinal("LoginName")) ? String.Empty : reader.GetString(reader.GetOrdinal("LoginName"));
                obj.Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? String.Empty : reader.GetString(reader.GetOrdinal("Password"));
                obj.Sex = reader.IsDBNull(reader.GetOrdinal("Sex")) ? false : reader.GetBoolean(reader.GetOrdinal("Sex"));
                obj.Mobile = reader.IsDBNull(reader.GetOrdinal("Mobile")) ? String.Empty : reader.GetString(reader.GetOrdinal("Mobile"));
                obj.RealName = reader.IsDBNull(reader.GetOrdinal("RealName")) ? String.Empty : reader.GetString(reader.GetOrdinal("RealName"));
            }
            #endregion
        }

        private static SqlParameter[] GetUserInfoParams(UserInfoModel obj)
        {
            #region
            SqlParameter[] dbParams ={					
					 SQLHelper.MakeParam(PARAM_USER_I, SqlDbType.BigInt,0,obj.UserID),
					 SQLHelper.MakeParam(PARAM_EMAIL, SqlDbType.NVarChar, 200,obj.Email),					
					 SQLHelper.MakeParam(PARAM_LOGIN_NAME, SqlDbType.NVarChar, 20,obj.LoginName),					
					 SQLHelper.MakeParam(PARAM_PASSWORD, SqlDbType.NVarChar, 20,obj.Password),					
					 SQLHelper.MakeParam(PARAM_SEX, SqlDbType.Bit,0,obj.Sex),
					 SQLHelper.MakeParam(PARAM_MOBILE, SqlDbType.NVarChar, 20,obj.Mobile),					
					 SQLHelper.MakeParam(PARAM_REAL_NAME, SqlDbType.NVarChar, 50,obj.RealName)					
			};

            return dbParams;
            #endregion
        }

        public static bool Save(UserInfoModel obj)
        {
            #region
            try
            {
                SqlParameter[] dbParams = GetUserInfoParams(obj);

                if (obj.UserID == 0)
                {
                    obj.UserID = Convert.ToInt32(SQLHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, "UserInfo_InsertUpdate", dbParams));
                    return obj.UserID > 0 ? true : false;
                }
                else
                {
                    var affectNum = SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "UserInfo_InsertUpdate", dbParams);
                    return affectNum > 0 ? true : false;
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("UserInfo-->InsertOrUpdate-->" + e.Message);

                ExceptionMessageDAL.Record(ex);
            }

            return false;
            #endregion
        }
    }
}
