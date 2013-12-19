<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministerLogin.aspx.cs"
    Inherits="GZDXCC.Admin.AdministerLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员登录</title>
    <link href="../Content/Css/Common.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Css/Reset.css" rel="stylesheet" type="text/css" />
    <link href="CSS/AdministerLogin.css" rel="stylesheet" type="text/css" />
    <script src="Script/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="head">
            贵州大学慈善中心
        </div>
        <div id="main">
            <table style="margin: 0; width: 473px; height: 200px;">
                <tr>
                    <td>
                        &nbsp
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 登录名：
                    </td>
                    <td>
                        <input id="LoginName" name="LoginName" type="text" value="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 密&nbsp; 码：
                    </td>
                    <td>
                        <input id="UserPassword" name="UserPassword" type="password" value="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp
                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 验证码：
                    </td>
                    <td>
                        <asp:TextBox ID="tbValidate" runat="server" AutoPostBack="True" CausesValidation="True"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <th>
                        &nbsp &nbsp
                    </th>
                    <td>
                        <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="验证码错误" ControlToValidate="tbValidate"
                            Display="Dynamic" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"
                            SetFocusOnError="True" ValidateEmptyText="false"></asp:CustomValidator>
                        --%>
                    </td>
                </tr>
               <%-- <tr>
                    <th>
                    </th>
                    <td>
                        <img alt="验证码" src="../valid.ashx" /><asp:CustomValidator ID="CustomValidator1" runat="server"
                            ControlToValidate="tbValidate" ErrorMessage="验证码错误" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"
                            ValidateEmptyText="True" SetFocusOnError="True"></asp:CustomValidator>
                        &nbsp;
                    </td>
                </tr>--%>
                <tr id="SubmitAndReset">
                    <td>
                        <button type="submit" >
                            登&nbsp&nbsp 录</button>
                       <%-- <asp:Button ID="Button1" runat="server" Text="登陆" 
                            onclick="Button1_Click1" />--%>
                    </td>
                    <td>
                        <button type="reset">
                            重&nbsp&nbsp 置</button>
                    </td>
                </tr>
            </table>
        </div>
        <%--  <div id="foot">
        </div>--%>
    </div>
    </form>
</body>
</html>
