<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Window">
        <div class="PersonNav">
            <span class="logo">
                <img src="images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                    margin-left: 30px" />
            </span>
            <%--<label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>--%>
            <asp:Label ID="lblSayHi" runat="server" Text="Label" CssClass="Set12px" style="margin-left: 500px;">Hi,你好！</asp:Label>
           
          <%--  <a class="Set12px" title="登录" href="Login.htm">登录</a> --%>
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass="Set12px" ToolTip="登录" NavigateUrl ="~/Login.aspx">登录</asp:HyperLink>
           <%-- <a class="Set12px" title="注册" href="SignUp.htm">注册</a> --%>
            <asp:HyperLink ID="hpLkSign" runat="server" CssClass="Set12px" ToolTip="注册" NavigateUrl="~/SignUp.aspx">注册</asp:HyperLink>
           <%-- <a class="Set12px" title="联系我们" href="Index.htm">联系我们</a>--%>
            <asp:HyperLink ID="hpLk" runat="server" CssClass="Set12px" ToolTip="联系我们" NavigateUrl="BrokenPage.aspx">联系我们 </asp:HyperLink>
        </div>
        <div class="MainDiv">
<div class="search">
                <span>
                    <%--<input type="text" class="Text_Search" />--%>
                    <asp:TextBox ID="txtQueryString" runat="server" CssClass="Text_Search"></asp:TextBox>

<%--                   <a href="" style="font-weight: bold; margin-left: 27px;">求科普</a>--%>
                    <asp:LinkButton ID="linkBtnSearch" runat="server" 
                    style="font-weight: bold; margin-left: 27px;" 
                    onclick="linkBtnSearch_Click" >求科普</asp:LinkButton>
                  </span>
            </div>
            <div class="nav">
                <a href="Index.aspx" title="主页"></a>
                <a href="Catalog.aspx" title="分类目录"></a>
            </div>
            <div class="MainBody">
                <div class="LoginDiv">
                    <div class="loginImg">
                    </div>
                    <h4 style="clear: both; position: relative; left: 175px; top: -22px; font-size: 24px;
                        color: #99cc66">
                        登录</h4>
                    <div class="LogInfo">
                        <p style="text-align: left; margin-left: 70px; margin-top: 50px; font-size: 14px;
                            color: #3e3e3e;">
                            用户名：</p>
                       <%-- <input class="InputText" id="Text_UID" type="text" />--%>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="InputText"></asp:TextBox>
                        <p style="text-align: left; margin-left: 70px; margin-top: 0px; font-size: 14px;
                            color: #3e3e3e;">
                            密码：</p>
                        <%--<input class="InputText" id="Text_Password" type="text" />--%>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="InputText" 
                            TextMode="Password"></asp:TextBox>
                        <p class="RememberMe">
                            <%--<input id="Check_Remeber" type="checkbox" style="margin-left: 20px;" />
                            记住我(公用电脑请慎重选择)--%>

                            <asp:CheckBox ID="ckbxRemeber" runat="server" style="margin-left: 20px;" />
                            记住我(公用电脑请慎重选择)
                        </p>
                        <div>
                            <%--<a href="#" style="font-size: 10px; float: right; position: relative; top: 0px; right: 5px;
                                text-decoration: underline;">忘记密码？</a>--%>
                           <%--     <asp:HyperLink ID="linkGetPassword" runat="server" NavigateUrl="~/GetPassword.aspx" >忘记密码？</asp:HyperLink>
                       --%> 
                            <asp:HyperLink ID="hpLkGetPass" runat="server" style="font-size: 10px; float: right; position: relative; top: 0px; right: 5px;
                                text-decoration: underline;" NavigateUrl="~/Retrieve_Password.aspx">忘记密码？</asp:HyperLink>
                        </div>
                       <div class="Login">
                            <%--<a href="#" title="登录" class="LoginButton"></a>--%>
                           <%--<asp:HyperLink ID="hpLogin" runat="server" ToolTip = "登录" CssClass="LoginButton" NavigateUrl="~/Login.aspx"></asp:HyperLink>
                      --%> 
                           <asp:LinkButton ID="lkBtnLogin" runat="server" ToolTip = "登录" 
                                CssClass="LoginButton" NavigateUrl="~/Login.aspx" onclick="lkBtnLogin_Click"></asp:LinkButton>
                      
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
                        <p style="text-align: left; font-size: 14px; color: #999999; margin-left:15px;">
                            >>还没加入UNo？</p>
                        <div class="Sign">
                            <%--<a href="SignUp.htm" title="注册" class="SignButton"></a>--%>
                            <asp:HyperLink ID="hpSign" runat="server" CssClass="SignButton"  ToolTip = "注册" NavigateUrl="~/SignUp.aspx"></asp:HyperLink>
                        
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="tail">
            <%--<a href="#" title="#-Sharp!" class="Bottom_Info">团队介绍</a>--%>
            <asp:HyperLink ID="hpLkIntroduction" runat="server" CssClass="Bottom_Info" ToolTip ="#-Sharp!" NavigateUrl ="BrokenPage.aspx">团队介绍</asp:HyperLink>
            <label class="Bottom_Info" style="color: White; margin-left: 2px; margin-right: 2px;">
                |</label>
           <%-- <a href="#" title="联系我们" class="Bottom_Info">联系我们</a>--%>
            <asp:HyperLink ID="hpLkAbout"  ToolTip = "联系我们" runat="server" CssClass="Bottom_Info" NavigateUrl ="BrokenPage.aspx">联系我们</asp:HyperLink>
        </div>
    </div>
    </form>
</body>
</html>
