using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GZDXCC.Admin
{
    public partial class InformationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Common.DataBindToDropList(this.ddlInfoType, SqlHelper.GetDataTable("select ID,Name from InformationType", null));
                #region 保存首次进入时的数据
                this.tbKey.Text = Request["key"];
                if (Request["isDraft"] != null)
                {
                    foreach (ListItem li in this.rblIsDraft.Items)
                    {
                        li.Selected = false;
                        if (li.Value == Request["isDraft"])
                        {
                            li.Selected = true;
                        }
                    }
                }
                if (Request["informationType"] != null)
                {
                    foreach (ListItem li in ddlInfoType.Items)
                    {
                        li.Selected = true;
                        if (li.Text == Request["informationType"])
                        {
                            li.Selected = true;
                        }
                    }
                }
                #endregion 保存首次进入时的数据

                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    string sql = "delete from Information where id=@id;";
                    Dictionary<string, object> p = new Dictionary<string, object>();
                    p.Add("@id", Request["id"]);
                    SqlHelper.ExecuteNonQuery(sql, p);
                }
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("@key", this.tbKey.Text.Trim());
                string partSql = string.Empty;
                if (this.ddlInfoType.SelectedValue != string.Empty)
                {
                    partSql = "  and ParentName=@ParentName";
                    parameter.Add("@ParentName", this.ddlInfoType.SelectedItem.Text);
                }
                if (this.rblIsDraft.SelectedValue != string.Empty)
                {
                    partSql += "  and IsDraft=@IsDraft";
                    parameter.Add("@IsDraft", this.rblIsDraft.SelectedValue);
                }
                string searchSql = "select count(*) from (select a.*,b.Name as ParentName from Information a left join InformationType b on a.InformationTypeID=b.ID) as T where (Title like '%'+@key+'%' or Author like '%'+@key+'%')" + partSql;
                object o = SqlHelper.ExecuteScalar(searchSql, parameter);
                int recoundCount = int.Parse(o.ToString());
                this.AspNetPager1.RecordCount = recoundCount;
                this.AspNetPager1.PageSize = string.IsNullOrEmpty(Request.QueryString["pageSize"]) ? 2 : int.Parse(Request.QueryString["pageSize"]);
            }
        }

        protected void ddlInfoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx?InformationType" + this.ddlInfoType.SelectedItem.Text + "&isDraft=" + this.rblIsDraft.SelectedValue + "&page=1&pageSize=" + Request["pageSize"] + "&key=" + this.tbKey.Text);
        }

        protected void rblIsDraft_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx?InformationType" + this.ddlInfoType.SelectedItem.Text + "&isDraft=" + this.rblIsDraft.SelectedValue + "&page=1&pageSize=" + Request["pageSize"] + "&key=" + this.tbKey.Text);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx?InformationType" + this.ddlInfoType.SelectedItem.Text + "&isDraft=" + this.rblIsDraft.SelectedValue + "&page=1&pageSize=" + Request["pageSize"] + "&key=" + this.tbKey.Text);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            int pageSize = string.IsNullOrEmpty(Request.QueryString["pageSize"]) ? 2 : int.Parse(Request.QueryString["pageSize"]);
            int currentPage = string.IsNullOrEmpty(Request.QueryString["page"]) ? 1: int.Parse(Request.QueryString["page"]);
           // int currentPage = string.IsNullOrEmpty(Request.QueryString["currentPage"]) ? 5 : int.Parse(Request.QueryString["currentPage"]);
            this.BindDataToPage(pageSize, currentPage);

        }
        public void BindDataToPage(int pageSize, int currentPage)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@pageSize", pageSize);
            p.Add("@currentPage", currentPage);
            p.Add("@key", this.tbKey.Text.Trim());
            string partSql = string.Empty;
            if (this.ddlInfoType.SelectedValue != string.Empty)
            {
                partSql = "  and ParentName=@ParentName";
                p.Add("@ParentName", this.ddlInfoType.SelectedItem.Text);
            }
            if (this.rblIsDraft.SelectedValue != string.Empty)
            {
                partSql += "  and IsDraft=@IsDraft";
                p.Add("@IsDraft", this.rblIsDraft.SelectedValue);
            }
            string sql = "select * from (select ROW_NUMBER()  OVER(ORDER BY ID DESC) as RowNo,* from (select a.*,b.Name as ParentName from Information a left join InformationType b on a.InformationTypeID =b.ID) as Table1 where ( Title like '%'+@key+'%' or Author like '%'+@key+'%')" + partSql + ") as Table2 where RowNo>@PageSize*(@CurrentPage-1) and RowNo<=@PageSize*@CurrentPage";
            this.rpData.DataSource = SqlHelper.GetDataTable(sql, p);
            this.rpData.DataBind();
        }
    }
}