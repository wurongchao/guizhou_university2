using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GZDXCC.Admin
{
    public partial class DeleteMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["mid"]))
            {
                Response.End();
            }
            string sql = "delete from Message where id=@id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@id",Request["id"]);
            SqlHelper.ExecuteNonQuery(sql,p);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}