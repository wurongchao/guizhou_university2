using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace GZDXCC.Admin
{
    public partial class ModifySelfInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginName"] == null)
            {
                Response.End();
            }
            if (this.IsPostBack==false)
            {
                string sql = @"select * from Admin where LoginName=@LoginName";
                Dictionary<string, object> p = new Dictionary<string, object>();
               p.Add("@LoginName",Session["LoginName"].ToString());
                DataTable dt = SqlHelper.GetDataTable(sql,p);
                this.tbLoginName.Text = dt.Rows[0]["LoginName"].ToString();
                this.tbRealName.Text = dt.Rows[0]["RealName"].ToString();
            }
            //this.tbRealName.Focus();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            this.tbRealName.Focus();

            if (this.IsValid==false)
            {
                return;
            }
            string sql = "update [Admin] set {0} RealName=@RealName where LoginName=@LoginName";
            Dictionary<string, object> p = new Dictionary<string, object>();
            //if (this.tbRealName.ToString()==null||this.tbRealName.ToString().Length>10)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"jj","alert('真实名字不合法！');",true);
            //}
            p.Add("@RealName",this.tbRealName.ToString());
            p.Add("@LoginName", this.tbLoginName.Text.Replace(" ",""));
            if (!string.IsNullOrEmpty(this.tbPassword.Text) && !string.IsNullOrEmpty(this.tbPasswordSure.Text))
            {
                sql = string.Format(sql, "[Password]=@Password");
                p.Add("@Password", this.tbPasswordSure.Text);
            }
            else sql = string.Format(sql," ");
            try
            {
                SqlHelper.ExecuteNonQuery(sql,p);
                ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"jj","alert('修改成功！');",true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ii", "alert('修改失败！');", true);
            }
        }
    }
}