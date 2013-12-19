<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frame.aspx.cs" Inherits="GZDXCC.Admin.Frame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Css/Reset.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Css/Common.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Frame.css" rel="stylesheet" type="text/css" />
    <link href="../Content/ligerUI/skins/ligerui-icons.css" rel="stylesheet" type="text/css" />
    <link href="../Content/ligerUI/skins/Silvery/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />
    <link href="../Content/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="../Content/Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="../Content/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tab;

        function heightChanged(obj) {
            if (tab) tab.addHeight(obj.diff);
        }

        function init() {
            var obj = {
                topHeight: $("#top").height(),
                bottomHeight: $("#bottom").height(),
                leftWidth: 200,
                onHeightChanged: heightChanged
            };
            $("#container").ligerLayout(obj);
            $("#nav").ligerTree({
                checkbox: false
            });

            var height = $(".l-layout-center").height();
            $("#tab").ligerTab({ height: height });
            tab = $("#tab").ligerGetTabManager();

            $("#nav a").click(function () {
                if (this.target == "dialog") {
                    $.ligerDialog.open({
                        url: this.href,
                        title: this.innerHTML,
                        width: this.attributes["w"].value,
                        height: $(this).attr("h"),
                        isResize: true
                    });
                }
                else {
                    tab.addTabItem({
                        tabid: this.target,
                        url: this.href,
                        text: this.innerHTML
                    });
                }
                return false;
            });
        }
        $(init);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="top" position="top">
            <h1 style="font-size: 30px; color: #0F72C7; text-align: center;">
                贵州大学慈善中心</h1>
        </div>
        <div id="left" title="系统菜单" position="left">
            <ul id="nav">
                <li><span>个人信息管理</span>
                    <ul>
                        <li><span><a h="240" w="500" href="ModifySelfInformation.aspx" target="ModifySelfInformation">
                            个人信息修改</a></span></li>
                    </ul>
                </li>
              <%--   <li><span>留言板类别管理</span>
                    <ul>
                        <li><span><a href="#" target="AddMessageType">添加类别信息</a></span></li>
                        <li><span><a href="#" target="MessageTypeList">类别信息列表</a></span></li>
                    </ul>
                </li>
                 <li><span>发布信息类别管理</span>
                    <ul>
                        <li><span><a href="#" target="AddInfoType">添加信息类别</a></span></li>
                        <li><span><a href="#" target="InfoTypeList">信息类别列表</a></span></li>
                    </ul>
                </li>--%>
                <li><span>发布信息管理</span>
                    <ul>
                        <li><span><a href="AddInformation.aspx" target="AddInformation">发布信息</a></span></li>
                        <li><span><a href="InformationList.aspx" target="InformationList">发布信息列表</a></span></li>
                    </ul>
                </li>
                <li><span>用户管理</span>
                    <ul>
                        <li><span><a href="AddAdminister.aspx" target="AddAdminister">添加用户</a></span></li>
                        <li><span><a href="AdministerList.aspx" target="AdministerList">用户列表</a></span></li>
                    </ul>
                </li>
               <%-- <li><span>留言板管理</span>
                    <ul>
                        <li><span><a href="#" onclick="javascript:location.href='LeaveMessage.aspx" target="_parent">
                            留言板</a></span></li>
                    </ul>
                </li>--%>
                <li><span>登录首页</span>
                    <ul>
                        <li><span><a href="#" onclick="javascript:location.href='AdministerLogin.aspx'" target="_parent">
                            管理员登录</a></span></li>
                    </ul>
                </li>
            </ul>
        </div>
        <div id="center" position="center">
            <div id="tab">
                <div tabid="home" title="我的主页">
                    主页
                </div>
            </div>
        </div>
        <div id="bottom" position="bottom" style="text-align: center; color: #0F72C7">
            <br />
            地址：贵州省贵阳市花溪区&nbsp&nbsp 邮编：550025 &nbsp&nbsp Email:741750152@qq.com &nbsp&nbsp 贵州大学慈善中心中心制作
            &nbsp&nbsp <a id="firstPage" href="../One.aspx">网站首页</a>
            <br />
            &nbsp
        </div>
    </div>
    </form>
</body>
</html>
