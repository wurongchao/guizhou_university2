﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GZDXCC
{
    public partial class Two : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchSql = @"select top (27) * from Information 
                            where InformationTypeID =
                            (
                                select ID from InformationType where [Name]='中心概况'
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
                                select ID from InformationType where [Name]='中心概况'
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

                string searchSql3 = "select * from information where id=@id";
                this.Repeater2.DataSource = SqlHelper.GetDataTable(searchSql3, p);
                this.Repeater2.DataBind();
            }
        }
    }
}