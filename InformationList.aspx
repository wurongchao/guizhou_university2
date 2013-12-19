<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformationList.aspx.cs"
    Inherits="GZDXCC.Admin.InformationList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息列表</title>
    <link href="../Content/Css/Reset.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Css/Common.css" rel="stylesheet" type="text/css" />
    <link href="../Content/ligerUI/skins/Silvery/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />
    <link href="CSS/Edit.css" rel="stylesheet" type="text/css" />
    <link href="CSS/List.css" rel="stylesheet" type="text/css" />
    <script src="../Content/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../Content/ligerUI/js/ligerui.min.js" type="text/javascript"></script>
    <script src="../Content/Scripts/jquery-querystring.js" type="text/javascript"></script>
    <script src="Script/Admin.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(
        function () {
            if ($("#tbKey").val() != "" || $("#ddlInfoType").val() != "" || $("input[name='rblIsDraft']:checked").val() == "1" || $("input[name='rbIsDraft']:checked").val() == 0)
                $("#search").show();
        }
                );
    </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnSearch">
    <div id="list">
        <div id="nav" style="width: 0px; height:0px; visibility: hidden;">
            <a href="#" onclick="DeleteSearched('Infomation');">批量删除</a>|<a href="#" onclick="slideToggle();">搜索</a>
        </div>
        <div id="search" style="width: 0px; height:0px; visibility: hidden;">
            查询关键字：<asp:TextBox ID="tbKey" runat="server"></asp:TextBox>
            所属类别：<asp:DropDownList Width="100px" ID="ddlInfoType" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="ddlInfoType_SelectedIndexChanged">
            </asp:DropDownList>
            是否草稿：<asp:RadioButtonList ID="rblIsDraft" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal"
                AutoPostBack="true" OnSelectedIndexChanged="rblIsDraft_SelectedIndexChanged">
                <asp:ListItem Text="是" Value="1" />
                <asp:ListItem Text="否" Value="0" />
                <asp:ListItem Selected="True" Text="所有" Value="" />
            </asp:RadioButtonList>
            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
        </div>
        <asp:Repeater ID="rpData" runat="server">
            <HeaderTemplate>
                <table id="data-list">
                    <tr>
<%--                        <th style="width: 0px; visibility: hidden;">
                            <input title="全选/取消" onclick="IsSelectAll(this);" id="Checkbox1" type="checkbox" />
                        </th>--%>
                        <th class="id">
                            编号
                        </th>
                        <th style="width: 200px;">
                            标题
                        </th>
                        <th>
                            点击率
                        </th>
                        <th>
                            作者
                        </th>
                        <th>
                            所属类别
                        </th>
                        <th>
                            是否为草稿
                        </th>
                        <th>
                            上传时间
                        </th>
                        <th class="oper">
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
<%--                    <td style="width:0px; visibility:hidden;">
                        <input onclick="SetRowBackGroudColor();" name="DelBox" type="checkbox" value="<%#Eval("ID").ToString() %>" />
                    </td>--%>
                    <td>
                        <%#Eval("RowNo").ToString() %>
                    </td>
                    <td>
                        <span style="color: <%#Eval("TitleColor").ToString()%>">
                            <%#Eval("Title").ToString()%></span>
                    </td>
                    <td>
                        <%#Eval("ViewCount").ToString() %>
                    </td>
                    <td>
                        <%#Eval("Author").ToString() %>
                    </td>
                    <td>
                        <%#Eval("ParentName").ToString() %>
                    </td>
                    <td>
                        <%#Eval("IsDraft").ToString() %>
                    </td>
                    <td>
                        <%#Eval("PostTime","{0:F}").ToString() %>
                    </td>
                    <td>
                        <a onclick="return openEdit(this,456,160);" href="ModifyInfoType.aspx?id=<%#Eval("ID").ToString() %>">
                            <img src="../Content/Images/edit.gif" alt="" title="编辑" /></a>|<a href="#" onclick="deleteData(<%#Eval("ID").ToString() %>);">
                                <img src="../Content/Images/delete.gif" title="删除" alt="" /></a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="pager">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" UrlPaging="true" FirstPageText="首页"
                PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页" OnPageChanged="AspNetPager1_PageChanged"
                ShowPageIndexBox="Always" CustomInfoHTML="页大小：&lt;a href=&quot;#&quot; onclick=&quot;setPageSize(5);&quot;&gt;5&lt;/a&gt;|&lt;a href=&quot;#&quot; onclick=&quot;setPageSize(10);&quot;&gt;10&lt;/a&gt; 第%CurrentPageIndex%/%PageCount%页，共%RecordCount%条数据"
                PageIndexBoxType="DropDownList" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转向第"
                CustomInfoSectionWidth="290px" CustomInfoTextAlign="Right" ShowCustomInfoSection="Right"
                UrlPageSizeName="pageSize" AlwaysShow="True" ShowNavigationToolTip="True" ViewStateMode="Enabled"
                PagingButtonSpacing="3px">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
