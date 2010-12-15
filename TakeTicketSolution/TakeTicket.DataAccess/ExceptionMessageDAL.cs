using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TakeTicket.Model;

namespace TakeTicket.DataAccess
{
    public class ExceptionMessageDAL
    {
        public static void Record(Exception ex)
        {
            HttpRequest Request = HttpContext.Current.Request;
            ExceptionModel vEntity = new ExceptionModel();
            vEntity.ThrowTime = DateTime.Now.ToString();
            vEntity.ExMessage = ex.Message;
            vEntity.ExDetail = ex.ToString();

            if (Request != null)
            {
                vEntity.ServerIP = Request.ServerVariables.Get("Local_Addr").ToString();
                vEntity.ClientIP = Request.UserHostAddress;
                vEntity.SiteName = Request.Url.Host;
                vEntity.RequestUrl = Request.Url.ToString();

                if (Request.UrlReferrer != null)
                    vEntity.UrlReferrer = Request.UrlReferrer.ToString();
            }
            else
            {
                vEntity.ServerIP = System.Net.Dns.GetHostName();
                vEntity.ClientIP = System.Net.Dns.GetHostName();
                vEntity.SiteName = "非Web站点产生";
                vEntity.RequestUrl = "无";
                vEntity.UrlReferrer = "无";
            }

            //ExceptionInfo.Save(vEntity);
        }
    }
}
