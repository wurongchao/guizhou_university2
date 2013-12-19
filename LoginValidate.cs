using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace GZDXCC.Admin
{
    public class LoginValidate : System.Web.UI.Page
    {
        public void CheckValid()
        {
            if (HttpContext.Current.Session["IsValid"] == null)
            {
                HttpContext.Current.Response.Write("用户信息已经丢失，请重新登录");
            }
        }
    }
}