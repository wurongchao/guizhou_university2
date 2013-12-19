<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyInfoType.aspx.cs" Inherits="GZDXCC.Admin.ModifyInfoType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改信息</title>
    <link href="../Content/Css/Reset.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Css/Common.css" rel="stylesheet" type="text/css" />
    <link href="../Content/ligerUI/skins/Silvery/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />
    <link href="CSS/Edit.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1" >
<div id="edit">
        <table>
            <tr>
                <th>
                    发布信息类别
                </th>
                <td>
                    &nbsp;<asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbName" ErrorMessage="请选择类别" ForeColor="Red" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    修改类别为</th>
                <td>
                    <asp:DropDownList ID="ddlParent" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td id="btn">
                    <asp:Button class="l-button" ID="Button1" runat="server" Text="提交" onclick="Button1_Click" 
                       />
                    <input id="Reset1" class="l-button" type="reset" value="重置" /></td>
            </tr>
        </table>
    </div>
    <div>
    <asp:Literal ID="literalAlert" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
