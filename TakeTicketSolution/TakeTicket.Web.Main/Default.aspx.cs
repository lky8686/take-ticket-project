using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakeTicket.Common.SiteConfig;
using TakeTicket.Common.SiteConfig.Model;
using TakeTicket.Common.FileStore;

namespace TakeTicket.Web.Main
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (DBInfo item in SiteConfigManager.Intance.DatabaseSettings)
            {
                Response.Write(SiteConfigManager.Intance.DatabaseSettings[item.ConnectionKey]);
                Response.Write("<br/>");
                Response.Write(item.ConnectionString + "<br/>");
            }
        }
    }
}
