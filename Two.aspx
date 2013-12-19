<%@ Page Title="" Language="C#" MasterPageFile="~/模板页.Master" AutoEventWireup="true" CodeBehind="Two.aspx.cs" Inherits="GZDXCC.Two" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>中心概况</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rpData" runat="server">
        <HeaderTemplate>
            <table id="data-list" style="width: 285px; margin-left: 9px; margin-top: 55px;">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="font-size: 13px; line-height: 1.5;">
                    <a style="text-decoration: none; color: <%#Eval("TitleColor")%>" href="Two.aspx?id=<%#Eval("ID") %>">
                        <img alt="" src="Content/Images/Title_Image.gif" />
                        <%#Eval("Title").ToString().Length >=20? Eval("Title").ToString().Substring(0, 19) + "..." : Eval("Title").ToString()%></a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="position" style="margin-top: 17px; margin-left: 50px; color: #E2E25E;">
        当前位置:<a href="Two.aspx" style="text-decoration: none; color: #E2E25E;">中心概况</a></div>
    <div style="overflow: scroll; width: 660px; height: 500px; margin-left: 7px; margin-top: 48px;">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <div id="Title" style="width: 660px; margin-bottom: 10px; font-size: 20px; color: <%#Eval("TitleColor ")%>;
                    text-align: center;">
                    <%#Eval("Title").ToString()%></div>
                <div id="Information" style="width: 600px; margin-bottom: 10px; height: 20px; margin-left: 60px;">
                    <div>
                        作者:
                        <%#Eval("Author").ToString()%>
                    </div>
                    &nbsp
                    <div>
                        发布时间:
                        <%#Eval("PostTime").ToString()%>
                    </div>
                    &nbsp
                    <div>
                        浏览量:
                        <%#Eval("ViewCount").ToString()%>
                    </div>
                </div>
                <tr>
                    <td style="font-size: 16px;">
                        <img alt="" src="Admin/Images/<%#Eval("Image") %>" />
                        <%#Eval("Content").ToString()%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div id="news-show" class="main-content border">
            <asp:Repeater ID="Repeater2" runat="server">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <div id="Title" style="width: 660px; margin-bottom: 10px; font-size: 20px; color: <%#Eval("TitleColor ")%>;
                        text-align: center;">
                        <%#Eval("Title").ToString()%></div>
                    <div id="Information" style="width: 600px; margin-bottom: 10px; height: 20px; margin-left: 60px;">
                        <div>
                            作者:
                            <%#Eval("Author").ToString()%>
                        </div>
                        &nbsp
                        <div>
                            发布时间:
                            <%#Eval("PostTime").ToString()%>
                        </div>
                        &nbsp
                        <div>
                            浏览量:
                            <%#Eval("ViewCount").ToString()%>
                        </div>
                    </div>
                    <tr>
                        <td style="font-size: 16px;">
                            <img alt="" src="Admin/Images/<%#Eval("Image") %>" />
                            <%#Eval("Content").ToString()%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

