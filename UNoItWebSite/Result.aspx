<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Result.aspx.cs" Inherits="Result" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
        <link href="CSS/Result.css" rel="stylesheet" type="text/css" />
</head>
<body>
 <form id="resultForm" runat="server">
<div class="Window">
        <div class="PersonNav">
            <span class="logo">
                <img src="images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                    margin-left: 30px" />
            </span>
            <label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>
            <a class="Set12px" title="登录" href="Login.htm">登录</a> <a class="Set12px" title="注册"
                href="SignUp.htm">注册</a> 
                <a class="Set12px" title="联系我们" href="BrokenPage.aspx">联系我们</a>
        </div>
        <div class="MainDiv">
            <div class="search">
                     <span>
                    <%--<input type="text" class="Text_Search" />--%>
                    <asp:TextBox ID="txtQueryString" runat="server" CssClass="Text_Search"></asp:TextBox>

<%--                   <a href="" style="font-weight: bold; margin-left: 27px;">求科普</a>--%>
                    <asp:LinkButton ID="linkBtnSearch" runat="server" 
                    style="font-weight: bold; margin-left: 27px;" onclick="linkBtnSearch_Click">求科普</asp:LinkButton>
                  </span>
            </div>
            <div class="nav">
                <a href="Index.aspx" title="主页"></a>
                <a href="Catalog.aspx" title="分类目录"></a>
            </div>
            <div class="MainBody">
                <div class="ResultDiv">
                    <h4 style="clear: both; position: relative; left: 48px; top: -20px; font-size: 24px;
                        color: #99cc66">
                        抱歉，没有找到您搜索的词条</h4>
                    <div class="ResultInfo">
                        <p style="text-align:left; font-weight:bold; margin-top:18px; margin-left:5px;">它们或许也能帮到您……</p>
                        <asp:DataList ID="entryDataList" runat="server">
                        <ItemTemplate>
                         <div class="ResultEntry">
                            <a href='<%#@"ViewEntry.aspx?title="+Eval("EntryName")%>' title="点击查看" target="_blank"><%#Eval("EntryName")%></a>
                                <br />
                            <span class="EntryBody"><%#Eval("Content")%></span>                            
                        </div>
                        </ItemTemplate>
                        </asp:DataList>     
                         <asp:Label ID="pageNav" CssClass=" PageNav" runat="server" style="position:relative; top:20px;" ></asp:Label>                                                                    
                    </div>
                </div>
                <div class="WelcomDiv">
                    <div class="ProblemLogo">
                        <a href="BrokenPage.aspx" style="display:inline-block; width:166px; height :22px;">
                        </a>
                    </div>
                    <p style="text-align:left; font-weight:bold; margin-top:45px; margin-left:20px;">找不到？词库弱爆了？</p>
                    
                    <div class="PublishEntry">
                        <%--<a href="#" title="我来发布" class="PublishBtn"></a>--%>
                        <asp:LinkButton ID="linkBtnRelease" runat="server"  title="我来发布" CssClass="PublishBtn"
                            onclick="linkBtnRelease_Click"></asp:LinkButton>
                    </div>
                    <div>                    <p style="text-align:left; color:#3e3e3e; font-size:14px;  margin-top:95px; margin-left:20px;">或者去朋友家看看：</p>                    <%--<a id="aWiki" runat="server" href="#" title="UNo还在成长……" class="LinkOtherBtn"></a>--%>
                    <asp:HyperLink ID="hyperLinkWiki" runat="server" title="UNo还在成长……" class="LinkOtherBtn"></asp:HyperLink>                    </div>
                </div>
            </div>
        </div>
        <div class="tail">
            <a href="BrokenPage.aspx" title="#-Sharp!" class="Bottom_Info">团队介绍</a>
            <label class="Bottom_Info" style="color: White; margin-left: 2px; margin-right: 2px;">
                |</label>
            <a href="BrokenPage.aspx" title="联系我们" class="Bottom_Info">联系我们</a>
        </div>
    </div>
</form>
</body>
</html>
