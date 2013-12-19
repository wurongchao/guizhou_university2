using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GZDXCC
{
    public partial class Three : System.Web.UI.Page
    {
        #region 可以不要
        public string BigTitle;
        public string TitleColor;
        public string Author;
        public string PostTime;
        public string Content;
        public string ViewCount;
        #endregion 
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchSql = @"select top (27) * from Information 
                            where InformationTypeID =
                            (
                                select ID from InformationType where [Name]='公益活动'
                            ) 
                            order by ID desc;";
            this.rpData.DataSource = (SqlHelper.GetDataTable(searchSql, null));
            this.rpData.DataBind();

            int id;
            int.TryParse(Request["id"], out id);
            if (id == 0)
            {
                if (!this.IsPostBack)
                {
                    string searchSql2 = @"select top (1) * from Information 
                            where InformationTypeID =
                            (
                                select ID from InformationType where [Name]='公益活动'
                            ) 
                            order by ID desc;";
                    this.Repeater1.DataSource = (SqlHelper.GetDataTable(searchSql2, null));
                    this.Repeater1.DataBind();
                }
            }

            else
            {
                Dictionary<string, object> p = new Dictionary<string, object>() { { "@id", id } };
                HttpCookie cookie = Request.Cookies["IsFirst"];
                if (cookie == null)
                {
                    SqlHelper.ExecuteNonQuery("update information set viewcount=viewcount+1 where id=@id", p);
                    cookie = new HttpCookie("IsFirst", "No");
                    cookie.Expires = DateTime.Now.AddSeconds(5);
                    Response.Cookies.Add(cookie);
                }

                string searchSql3="select * from information where id=@id";

                DataTable dt = SqlHelper.GetDataTable(searchSql3, p);

                //  string sql = "select ";
                //  this.TypeName = SqlHelper.ExecuteScalar(sql, p).ToString();
                #region  此处可以不要
                this.BigTitle = dt.Rows[0]["Title"].ToString();
                this.TitleColor = dt.Rows[0]["TitleColor"].ToString();
                this.Author = dt.Rows[0]["Author"].ToString();
                this.PostTime = dt.Rows[0]["PostTime"].ToString();
                this.Content = dt.Rows[0]["Content"].ToString();
                this.ViewCount = dt.Rows[0]["ViewCount"].ToString();
                #endregion  
                this.Repeater2.DataSource = SqlHelper.GetDataTable(searchSql3,p);
                this.Repeater2.DataBind();
            }
        }
    }
}