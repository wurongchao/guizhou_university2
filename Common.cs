using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Web.UI.WebControls;
namespace GZDXCC
{
    public class Common
    {
        public static string SHA1(string source)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(source, "SHA1");
        }
        /// <summary>
        /// 绑定数据到下拉列表框
        /// </summary>
        /// <param name="ddl">控件名</param>
        /// <param name="dt">数据源</param>
        /// <param name="selectedValue">应该被选中的的值</param>
        /// <param name="textColumnNane">列名</param>
        /// <param name="valueColumnName">列值</param>
        /// <param name="isHaveTip">是否有提示</param>
        /// <param name="tipItemText">提示内容</param>
        /// <param name="tipItemValue">提示的值</param>
        public static void DataBindToDropList(DropDownList ddl, DataTable dt, string selectedValue = "", string textColumnNane = "Name", string valueColumnName = "ID", bool isHaveTip = true, string tipItemText = "请选择....", string tipItemValue = "")
        {
            ddl.Items.Clear();
            if (isHaveTip) ddl.Items.Add(new ListItem(tipItemText, tipItemValue));
            foreach (DataRow item in dt.Rows)
            {
                ListItem li = new ListItem(item[textColumnNane].ToString(), item[valueColumnName].ToString());
                ddl.Items.Add(li);
            }
            foreach (ListItem item in ddl.Items)
            {
                if (item.Text == selectedValue)
                {
                    item.Selected = true;
                    break;
                }
            }
        }
    }
}