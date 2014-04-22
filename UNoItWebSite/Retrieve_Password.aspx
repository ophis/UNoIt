<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Retrieve_Password.aspx.cs" Inherits="Retrieve_Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>U No.IT -- 找回密码</title>
    
    <link href="CSS/Retrieve_Password.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Window">
        <div class="PersonNav">
            <span class="logo">
                <img src="images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                    margin-left: 30px" />
            </span>
           <%-- <label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>--%>
            <asp:Label ID="lblSayHi" runat="server" Text="Label" style="margin-left: 500px;" CssClass="Set12px">Hi,你好！</asp:Label>
         
           <%-- <a class="Set12px" title="登录" href="Login.htm">登录</a>--%>
            <asp:HyperLink ID="hpLkSign" runat="server" CssClass="Set12px" ToolTip="登录" NavigateUrl="~/Login.aspx">登录</asp:HyperLink>
         <%--    <a class="Set12px" title="注册"href="SignUp.htm">注册</a> --%>
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass="Set12px" ToolTip="注册" NavigateUrl="~/SignUp.aspx">注册</asp:HyperLink>
           <%--  <a class="Set12px" title="联系我们" href="Index.htm">联系我们</a>--%>
            <asp:HyperLink ID="hpLkNotify" runat="server" CssClass="Set12px" ToolTip="联系我们" NavigateUrl="BrokenPage">联系我们</asp:HyperLink>
        </div>
        <div class="MainDiv">
        <div class="search">
                <span>
                    <%--<input type="text" class="Text_Search" />--%>
                    <asp:TextBox ID="txtQueryString" runat="server" CssClass="Text_Search"></asp:TextBox>

<%--                   <a href="" style="font-weight: bold; margin-left: 27px;">求科普</a>--%>
                    <asp:LinkButton ID="linkBtnSearch" runat="server" 
                    style="font-weight: bold; margin-left: 27px;" 
                    onclick="linkBtnSearch_Click">求科普</asp:LinkButton>
                  </span>
            </div>
            <div class="nav">
                <a href="Index.htm" title="主页"></a><a href="Catalog.aspx" title="分类目录"></a>
            </div>
            <div class="MainBody">
                <div class="RetrieveDiv">
                    <div class="RetrieveImg">
                    </div>
                    <h4 style="clear: both; position: relative; left: 155px; top: -22px; font-size: 24px;
                        color: #99cc66">
                        找回密码</h4>
                    <div class="RetrieveInfo">
                        <p style="text-align: left; margin-left: 50px; margin-top: 50px; font-size: 14px;
                            color: #3e3e3e; font-weight:bold;">
                            需找回的用户名：</p>
                        <%--<input class="InputText" id="Text_UID" type="text" />--%>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="InputText"></asp:TextBox>
                        <p style="text-align: left; margin-left: 50px; margin-top: 0px; font-size: 14px;
                            color: #3e3e3e;font-weight:bold;">
                            注册时所填邮箱：</p>
                       <%-- <input class="InputText" id="Text_Password" type="text" />--%>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="InputText"></asp:TextBox>
                        <div class="Retrieve" style="margin-top:40px">
                            <%--<a href="#" title="确认" class="RetrieveButton"></a>--%>
                            <%--<asp:HyperLink ID="hpLk" runat="server" CssClass="RetrieveButton" NavigateUrl="#####"></asp:HyperLink>--%>
                            <asp:LinkButton ID="lkBtnSubmit" runat="server" CssClass="RetrieveButton" NavigateUrl="#####"
                                onclick="lkBtnSubmit_Click" ></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="WelcomDiv">
                    <div class="SharpLogo">
                        <img src="images/sharplogo.png" style="height: 111px; width: 137px;" />
                    </div>
                    <p style="font-size: 14px; color: #66cccc;">
                        开发团队：#(Sharp)</p>
                    <div class="SignUp">
                        <p style="text-align: left; font-size: 14px; color: #999999; margin-left: 15px;">
                            >>还没加入UNo？</p>
                        <div class="Sign">
                            <a href="SignUp.aspx" title="注册" class="SignButton"></a>
                           </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="tail">
            <%--<a href="#" title="#-Sharp!" class="Bottom_Info">团队介绍</a>--%>
            <asp:HyperLink ID="hpIntroduction" runat="server" ToolTip="#-Sharp!" CssClass="Bottom_Info" NavigateUrl="BrokenPage.aspx">团队介绍</asp:HyperLink>
            <label class="Bottom_Info" style="color: White; margin-left: 2px; margin-right: 2px;">
                |</label>
           <%-- <a href="#" title="联系我们" class="Bottom_Info">联系我们</a>--%>
            <asp:HyperLink ID="hpLkAbout" runat="server" ToolTip= "联系我们" CssClass="Bottom_Info" NavigateUrl = "BrokenPage.aspx">联系我们</asp:HyperLink>
        </div>
    </div>
    </form>
</body>
</html>
