using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZDXCC.Admin
{
    /// <summary>
    /// DeleteAll 的摘要说明
    /// </summary>
    public class DeleteAll : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string ids=context.Request["ids"];
            if (string.IsNullOrEmpty(ids))
            {
                context.Response.End();
            }
            string tableName=context.Request["t"];
            if (string.IsNullOrEmpty(tableName))
            {
                context.Response.End();
            }
            ids = ids.Remove(ids.Length-1);
            string sql = string.Format("delete from {0} where id in ({1})",tableName,ids);
            SqlHelper.ExecuteNonQuery(sql,null);
            context.Response.Redirect(context.Request.UrlReferrer.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}