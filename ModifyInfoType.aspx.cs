using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace GZDXCC.Admin
{
    public partial class ModifyInfoType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.End();
            }
            if (this.IsPostBack == false)
            {
                string SQL = @"select Name from InformationType where ID = (
                                select  InformationTypeID
                                from Information
                                where ID=@id
                                )";
                string sql = @"SELECT * FROM   InformationType WHERE ID=@ID";

                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("@id", Request.QueryString["id"]);

                DataTable dt = SqlHelper.GetDataTable(sql, p);
                DataTable d = SqlHelper.GetDataTable(SQL, p);

                this.tbName.Text = d.Rows[0]["Name"].ToString();
                DataTable dtForDDL = SqlHelper.GetDataTable("select * from InformationType", null);
                Common.DataBindToDropList(this.ddlParent, dtForDDL, d.Rows[0]["Name"].ToString());
            }
            this.literalAlert.Text = string.Empty;
            this.tbName.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.IsValid == false)
            {
                return;
            }
            string sql = "update Information set InformationTypeID=@InformationTypeID where id=@id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@id", Request.QueryString["id"]);
            p.Add("@InformationTypeID", this.ddlParent.SelectedItem.Value);
            try
            {
                SqlHelper.ExecuteNonQuery(sql, p);
                this.literalAlert.Text = "<script>parent.closeEdit();</script>";
            }
            catch (Exception)
            {
                this.literalAlert.Text = "<script>alert(\"修改失败！\");</script>";
                return;
            }
        }
    }
}