<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalHP_MyEntry.aspx.cs"
    Inherits="PersonalHP_MyEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/CommonPart.css" rel="stylesheet" type="text/css" />
    <link href="css/PersonalHP_MyEntry.css" rel="stylesheet" type="text/css" />
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
            <%--<asp:Label ID="lblHi" runat="server" Text="Hi,你好！" CssClass="Set12px" Style="margin-left: 500px;"></asp:Label>
--%>
            <asp:HyperLink ID="hpLkSayHi" runat="server" CssClass="Set12px" Style="margin-left: 500px;">Hi,你好！</asp:HyperLink>
           <%-- <a class="Set12px" title="登录" href="Login.aspx">登录</a> --%>
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass="Set12px">登录</asp:HyperLink>
           <%-- <a class="Set12px" title="注册" href="Index.aspx">注册</a>--%>
            <%--<asp:HyperLink ID="hpLkSign" runat="server" CssClass="Set12px">注册</asp:HyperLink>
            --%> 
            <asp:LinkButton ID="lkBtnSign" runat="server" CssClass="Set12px" 
                onclick="lkBtnSign_Click">注册</asp:LinkButton>
           
             <a class="Set12px" title="联系我们" href="BrokenPage.aspx">联系我们</a>
        </div>
        <div class="MainDiv">
            <div class="search">
                <span>
                    <%--<input type="text" class="Text_Search" />--%>
                    <asp:TextBox ID="txtQueryString" runat="server" CssClass="Text_Search"></asp:TextBox>

<%--                   <a href="" style="font-weight: bold; margin-left: 27px;">求科普</a>--%>
                    <asp:LinkButton ID="linkBtnSearch" runat="server" 
                    style="font-weight: bold; margin-left: 27px;" 
                    onclick="linkBtnSearch_Click2" >求科普</asp:LinkButton>
                  </span>
            </div>
            <div class="nav">
                <a href="Index.aspx" title="主页"></a><a href="Catalog.aspx" title="分类目录"></a>
                <a href="PersonalHP_MyEntry.aspx"
                    title="我的词条" style="position: relative; left: 31px; top: 40px;"></a><a href="PersonalHP_MyComment.aspx"
                        title="我的评论" style="position: relative; left: 12px; top: 40px;"></a><a href="PersonalHP_EditInfo.aspx"
                            title="个人资料设置" style="position: relative; left: 3px; top: 40px;"></a>
                <a href="PersonalHP_ResetKey.aspx" title="修改密码" style="position: relative; left: 0px;
                    top: 40px;"></a><a href="PersonalHP_Message.aspx" title="收件箱" style="width: 25px;
                        position: relative; left: -2px; padding-left: 0px; top: 40px;"></a>
            </div>
            <div class="MainBody">
                <div class="MyInfoDiv">
                    <div class="MyInfoDivTitleImg" style="width: 166px; height: 31px;">
                    </div>
                    <div class="MyInfoImg">
                        <img src="images/img_MyZone/DefaultAva.gif" style="height:82px; width:82px;" />
                        
                    </div>
                    <asp:Label ID="lblUserName" runat="server" Font-Size="16px" ForeColor="#99CC66" Text = "<%#userName %>"></asp:Label>
                    <div style="text-align: left;">
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            职位：</label>--%>
                        <asp:Label ID="lblPosition" runat="server" class="Set12px" Style="text-align: left;
                            margin-left: 15px; margin-top: 8px; margin-bottom: 5px;">
                            职位：</asp:Label>
                        <%--<label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;">
                            学生
                        </label>--%>
                        <asp:Label ID="lblPositionShow" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 0px; margin-top: 8px;" Text="<%#position%>">
                        </asp:Label>
                        <br />
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            生日：</label>--%>
                        <asp:Label ID="lblBirthday" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 15px; margin-top: 8px; margin-bottom: 5px;">
                            生日：</asp:Label>
                        <%--<label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;">
                            1991-08-04
                        </label>--%>
                        <asp:Label ID="lblBirthdayShow" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 0px; margin-top: 8px;" Text="<%#birthday%>">
                        </asp:Label>
                        <br />
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            所在地：</label>--%>
                        <asp:Label ID="lblCity" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 15px; margin-top: 8px; margin-bottom: 5px;">
                            所在地：</asp:Label>
                        <%-- <label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;
                            margin-bottom: 5px;">
                            南京
                        </label>--%>
                        <asp:Label ID="lblCityShow" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 0px; margin-top: 8px; margin-bottom: 5px;" Text="<%#city%>">
                        </asp:Label>
                        <br />
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            擅长领域：</label>--%>
                        <asp:Label ID="lblSkilled" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 15px; margin-top: 8px; margin-bottom: 5px;">
                            擅长领域：</asp:Label>
                        <%--  <label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;
                            margin-bottom: 5px;">
                            杀人放火</label>--%>
                        <asp:Label ID="lblSkilledShow" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 0px; margin-top: 8px; margin-bottom: 5px;" Text="<%#skilledField%>">
                        </asp:Label>
                        <br />
                        <%-- <label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            我的积分：</label>--%>
                        <asp:Label ID="lblScores" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 15px; margin-top: 8px; margin-bottom: 5px;">
                            我的积分：</asp:Label>
                        <%--<label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;">
                            20</label>--%>
                        <asp:Label ID="lblScoresShow" runat="server" CssClass="Set12px" Style="text-align: left;
                            margin-left: 0px; margin-top: 8px;" Text="<%#scores%>">
                        </asp:Label>
                    </div>
                    <div class="Publish">
                        <%--<a class="ReleaseBtn" href="#" title="发布词条"></a>--%>
                        <asp:HyperLink ID="hpLkReleased" runat="server" CssClass="ReleaseBtn" NavigateUrl="Publish_Entry.aspx"></asp:HyperLink>
                    </div>
                    <div style="margin-left: 72px; margin-top: 72px; text-decoration: underline; width: 100px;
                        height: 14px;">
                        <%--<a href="#" class="Set12px" style="text-decoration: underline;">>>积分细则</a>--%>
                        <asp:HyperLink ID="hpLkScoresRule" runat="server" CssClass="Set12px" Style="text-decoration: underline;"
                            NavigateUrl="BrokenPage.aspx">>>积分细则</asp:HyperLink>
                    </div>
                </div>
                <div class="MyEntryView">
                    <p style="float: right; font-size: 18px; font-weight: bold; margin-right: 20px; margin-bottom: 10px;
                        color: #3e3e3e;">
                        我的词条</p>
                    <div>
                        <ul class="MyEntryBody">
                            <asp:DataList ID="dataListMyEntry" runat="server">
                                <ItemTemplate>
                                    <li class="MyEntry">
                                        <div class="EntryTitle">
                                            <a class="Title" href='<%#@"ViewEntry.aspx?title="+Eval("entryName")%>' title="点击查看"
                                                target="_blank">
                                                <%#Eval("entryName") %></a>
                                            <%--<asp:LinkButton ID="linbtnEntryName" runat="server" CssClass="Title" href="#" title="点击查看" target="_blank" Text=<%#Eval("entryName") %>>>LinkButton</asp:LinkButton>--%>
                                        </div>
                                        <div>
                                            <span class="EntryBody">
                                                <%#Eval("content") %>> </span><span class="EntryInfo">赞(<asp:Label ID="lblUpSum"
                                                    runat="server" Text='<%#Eval("upSum") %>'>></asp:Label>) 踩(<asp:Label ID="lblDigSum"
                                                        runat="server" Text='<%#Eval("digSum") %>'>></asp:Label>) 发布时间：<asp:Label ID="lblReleasedTime"
                                                            runat="server" Text='<%#Eval("releasedTime") %>'>></asp:Label></span>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:DataList>
                            <div style="margin-top: 10px; width: 432px; margin-left: -34px;">
                                <asp:Label ID="pageNav" CssClass=" PageNav" runat="server"></asp:Label></div>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="tail" style="margin-top: 36px;">
                <a href="BrokenPage.aspx" title="#-Sharp!" class="Bottom_Info">团队介绍</a>
                <label class="Bottom_Info" style="color: White; margin-left: 2px; margin-right: 2px;">
                    |</label>
                <a href="BrokenPage.aspx" title="联系我们" class="Bottom_Info">联系我们</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
