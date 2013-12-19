using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
namespace GZDXCC.Admin
{
    public partial class AdministerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginName = Request.Form["LoginName"];
            string userPassword = Request.Form["UserPassword"];
            string validCode = Request.Form["ValidCode"];
            //if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(userPassword)||string.IsNullOrEmpty(validCode))
            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(userPassword))
            {
                return;
            }
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@LoginName", loginName);
            // p.Add("@UserPassword", Common.SHA1(userPassword));
            p.Add("@UserPassword", userPassword);
            string sql1 = @"select count(*) from Admin where LoginName=@LoginName and [Password]=@UserPassword";
            int count = int.Parse(SqlHelper.ExecuteScalar(sql1, p).ToString());
            if (count > 0)
            {
                Session["IsValid"] = true;
                Session.Add("LoginName", loginName);//=Session["LoginName"]=loginName;
                string sql2 = @"update Admin set LastLoginIP=@LastLoginIP where LoginName=@LoginName";
                p.Remove("@password");
                p.Add("@LastLoginIp", Request.UserHostAddress);
                SqlHelper.ExecuteNonQuery(sql2, p);
                HttpCookie loginCookie = new HttpCookie("dd");
                loginCookie["LoginName"] = loginName;
                loginCookie["Password"] = userPassword;
                loginCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(loginCookie);
                Response.Redirect("Frame.aspx");
            }
            else
            {
                Response.Write("<script>alert(\"登录信息有误，请重新登录！\");window.history.back();</script>");
            }
        }

        //protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    HttpCookie cookie = Request.Cookies["CheckCode"];
        //    if (cookie == null)
        //    {
        //        args.IsValid = false;
        //        return;
        //    }
        //    string cookieCheckCode = cookie.Value;
        //    if (cookieCheckCode != this.tbValidate.Text.ToUpper())
        //    {
        //        args.IsValid = false;
        //        return;
        //    }
        //    args.IsValid = true;
        //}

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
           
        //}


    }
}