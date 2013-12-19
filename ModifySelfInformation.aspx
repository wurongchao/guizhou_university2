<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifySelfInformation.aspx.cs"
    Inherits="GZDXCC.Admin.ModifySelfInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人信息修改</title>
    <link href="../Content/Css/Reset.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Css/Common.css" rel="stylesheet" type="text/css" />
    <link href="../Content/ligerUI/skins/Silvery/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />
    <link href="CSS/Edit.css" rel="stylesheet" type="text/css" />
    <script src="../Content/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../Content/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <style type="text/css">
        table
        {
            background: #78E0F9;
            width: 600px;
        }
        
        input
        {
            width: 150px;
        }
        button
        {
            width: 100px;
        }
        .style1
        {
            width: 90px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="edit">
        <table>
            <tr>
                <td class="style1">
                    登&nbsp 录&nbsp 名：
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="tbLoginName" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    密&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 码：
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="tbPassword" runat="server" TextMode="Password" ToolTip="不输入表示不修改"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="密码只能在3-16个字符之间" 
                        ForeColor="Red" SetFocusOnError="True" ValidationExpression="^(\s|\S){3,16}$"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="tbPassword" ControlToValidate="tbPasswordSure" 
                        Display="Dynamic" ErrorMessage="密码匹配不正确" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    确认密码：
                </td>
                <td>
                    &nbsp;<asp:TextBox 
                        ID="tbPasswordSure" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="tbPasswordSure" Display="Dynamic" 
                        ErrorMessage="密码只能在3-16个字符之间" ForeColor="Red" 
                        ValidationExpression="^(\s|\S){3,16}$"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToCompare="tbPasswordSure" ControlToValidate="tbPassword" 
                        Display="Dynamic" ErrorMessage="密码匹配不正确" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    真实名字：
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="tbRealName" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="tbRealName" Display="Dynamic" 
                        ErrorMessage="真实名字只能在2-10个字符之间" ForeColor="Red" SetFocusOnError="True" 
                        ValidationExpression="^(\s|\S){2,10}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="Submit" runat="server" Text="提  交" Width="92px" 
                        onclick="Submit_Click" />
                </td>
                <td>
                    <input id="Reset" type="reset" name="MyReset" value="重  置" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
