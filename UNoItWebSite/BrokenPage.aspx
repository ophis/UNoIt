<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrokenPage.aspx.cs" Inherits="BrokenPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>U No.IT 杯具你懂的。</title>
    <link href="CSS/SignUp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Window">
        <div class="PersonNav">
            <span class="logo">
                <img src="images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                    margin-left: 30px" />
            </span>
            <%--<label class="Set12px" style="margin-left: 500px;"></label>--%>
            <asp:Label ID="lblSayHi" runat="server" Text="Hi,你好！" Style="margin-left: 500px;"
                CssClass="Set12px"></asp:Label>
            <%--<a class="Set12px" title="登录" href="Login.htm">登录</a>--%>
            <%--//TODO--%>
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass="Set12px" title="登录" NavigateUrl="#######">登录</asp:HyperLink>
            <%--<a class="Set12px" title="注册" href="SignUp.htm">注册</a> --%>
            <asp:HyperLink ID="hpLkSignUp" runat="server" CssClass="Set12px" title="注册" NavigateUrl="#######">注册</asp:HyperLink>
            <%-- <a class="Set12px" title="联系我们" href="Index.htm">联系我们</a>--%>
            <asp:HyperLink ID="hpLkAbout" runat="server" CssClass="Set12px" title="联系我们" NavigateUrl="#######">联系我们</asp:HyperLink>
        </div>
        <div class="MainDiv">
                <div class="search">
                <span>
                    <%--<input type="text" class="Text_Search" />--%>
                    <asp:TextBox ID="txtQueryString" runat="server" CssClass="Text_Search"></asp:TextBox>

<%--                   <a href="" style="font-weight: bold; margin-left: 27px;">求科普</a>--%>
                    <asp:LinkButton ID="linkBtnSearch" runat="server" 
                    style="font-weight: bold; margin-left: 27px;" onclick="linkBtnSearch_Click" >求科普</asp:LinkButton>
                  </span>
            </div>
                <div class="nav">
                <a href="Index.aspx" title="主页"></a>
                <%--<asp:HyperLink ID="hpLkHomepage" runat="server" NavigateUrl ="######">主页</asp:HyperLink>--%>
                <a href="Catalog.aspx" title="分类目录"></a>
                <%--<asp:HyperLink ID="hpLkCategory" runat="server" NavigateUrl ="######">分类目录</asp:HyperLink>--%>
            </div>
                <div class="MainBody">

                <div class="SignDiv">
                    <h4 style="clear: both; position: relative; left: 155px; top: -22px; font-size: 24px;
                        color: #99cc66">
                        杯具了吧</h4>
                    <div class="SignInfo">
                    <p style=" width:320px; margin:120px auto; color:Red; font-size:20px; font-weight:700;">手贱乱戳神马啊！“团队介绍”“联系我们”“积分细则”这种东西显然没人做嘛！</p>
                    </div>
                </div>
                <div class="WelcomDiv">
                    <div class="SharpLogo">
                        <img src="images/sharplogo.png" style="height: 111px; width: 137px;" />
                    </div>
                    <p style="font-size: 14px; color: #66cccc;">
                        开发团队：#(Sharp)</p>
                </div>
            </div>
        </div>
        <div class="tail">
            <%--<a href="#" title="#-Sharp!" class="Bottom_Info">团队介绍</a>--%>
            <asp:HyperLink ID="hpLkSharp" runat="server" CssClass="Bottom_Info" ToolTip="#-Sharp!"
                NavigateUrl="#####"></asp:HyperLink>
            <%--<label class="Bottom_Info" style="color: White; margin-left: 2px; margin-right: 2px;"></label>--%>
            <%-- <asp:Label ID="lbl" runat="server" Text="Label" style="color: White; margin-left: 2px; margin-right: 2px;" CssClass="Bottom_Info"></asp:Label>
            --%>
            <a href="#" title="联系我们" class="Bottom_Info">联系我们</a>
        </div>
    </div>
    </form>
</body>
</html>
