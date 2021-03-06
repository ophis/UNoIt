﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalHP_ResetKey.aspx.cs" Inherits="PersonalHP_ResetKey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>个人主页-修改密码</title>
    <link href="CSS/CommonPart.css" rel="stylesheet" type="text/css" />
    <link href="CSS/PersonalHP_ResetKey.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formResetKey" runat="server">
    <div class="Window">
        <div class="PersonNav">
            <span class="logo">
                <img src="images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                    margin-left: 30px" />
            </span>
           <%-- <label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>--%>
            <asp:Label ID="lblSayHi" runat="server" Text="Label" CssClass="Set12px" style="margin-left: 500px;"> Hi,你好！</asp:Label>
            <%--<a class="Set12px" title="登录" href="Login.htm">登录</a>--%> 
                <asp:HyperLink ID="hpLkLogin" runat="server" CssClass="Set12px" ToolTip = "登录" NavigateUrl="~/Login.aspx">登录</asp:HyperLink>
            <%--<a class="Set12px" title="注册" href="Index.htm">注册</a>--%>
            <%--<asp:HyperLink ID="hpLkSign" runat="server" CssClass="Set12px" ToolTip="注册" NavigateUrl="~/SignUp.aspx">注册</asp:HyperLink>
            --%>
            <asp:LinkButton ID="hpLkSign" runat="server" CssClass="Set12px" 
                onclick="hpLkSign_Click">注册</asp:LinkButton> 
            <a class="Set12px" title="联系我们" href="BrokenPage.aspx">联系我们</a>
                <%--<asp:HyperLink ID="hpLkNotify" runat="server" CssClass="Set12px" ToolTip="联系我们">联系我们</asp:HyperLink>--%>
        </div>
        <div class="MainDiv">
             <div class="search">
                <span>
                    <%--<input type="text" class="Text_Search" />--%>
                    <asp:TextBox ID="txtQueryString" runat="server" CssClass="Text_Search"></asp:TextBox>

<%--                   <a href="" style="font-weight: bold; margin-left: 27px;">求科普</a>--%>
                    <asp:LinkButton ID="linkBtnSearch" runat="server" 
                    style="font-weight: bold; margin-left: 27px;" 
                      >求科普</asp:LinkButton>
                  </span>
            <div class="nav">
                <a href="Index.aspx" title="主页"></a>
                <a href="Index.aspx" title="分类目录"></a>
                <a href="PersonalHP_MyEntry.aspx" title="我的词条" style="position: relative; left: 28px; top: 40px;"></a>
                <a href="PersonalHP_MyComment.aspx" title="我的评论" style="position: relative; left: 15px; top: 40px;"></a>
                <a href="PersonalHP_EditInfo.aspx" title="个人资料设置" style="position: relative; left: 5px; top: 40px;"></a>
                <a href="PersonalHP_ResetKey.aspx" title="修改密码" style="position: relative; left: -5px; top: 40px;"></a>
                <a href="PersonalHP_Message.aspx" title="收件箱" style=" width: 25px; position: relative; left: -12px; padding-left: 0px; top: 40px;"></a>
            </div>
            <div class="MainBody">
                <div class="MyInfoDiv">
                    <div class="MyInfoDivTitleImg" style="width: 166px; height: 31px;">
                    </div>
                    <div class="MyInfoImg">
                        <img src="images/img_MyZone/DefaultAva.gif" style="height:82px; width:82px;" />
                    </div>
                        <asp:Label ID="lblUserName" runat="server"  
                            Font-Size="16px" ForeColor="#99CC66" ></asp:Label>
                    <div style="text-align: left;">
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            职位：</label>--%>
                        <asp:Label ID="lblPosition" runat="server" class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;margin-bottom: 5px;">
                            职位：</asp:Label>
                        <%--<label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;">
                            学生
                        </label>--%>
                        <asp:Label ID="lblPositionShow" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;" Text =  "<%#position%>">
                           </asp:Label>

                        <br />
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            生日：</label>--%>
                        <asp:Label ID="lblBirthday" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            生日：</asp:Label>
                        <%--<label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;">
                            1991-08-04
                        </label>--%>
                        <asp:Label ID="lblBirthdayShow" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;" Text = "<%#birthday%>">
                           </asp:Label>

                        <br/>
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            所在地：</label>--%>
                        <asp:Label ID="lblCity" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            所在地：</asp:Label>
                       <%-- <label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;
                            margin-bottom: 5px;">
                            南京
                        </label>--%>
                        <asp:Label ID="lblCityShow" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;
                            margin-bottom: 5px;" Text = "<%#city%>">
                            </asp:Label>

                        <br />
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            擅长领域：</label>--%>
                        <asp:Label ID="lblSkilled" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            擅长领域：</asp:Label>
                      <%--  <label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;
                            margin-bottom: 5px;">
                            杀人放火</label>--%>
                        <asp:Label ID="lblSkilledShow" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;
                            margin-bottom: 5px;" Text = "<%#skilledField%>">
                            </asp:Label>

                        <br />
                       <%-- <label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            我的积分：</label>--%>
                        <asp:Label ID="lblScores" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            我的积分：</asp:Label>
                        <%--<label class="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;">
                            20</label>--%>
                        <asp:Label ID="lblScoresShow" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 0px; margin-top: 8px;" Text ="<%#scores%>">
                            </asp:Label>
                    </div>
                    <div class="Publish">
                        <%--<a class="ReleaseBtn" href="#" title="发布词条"></a>--%>
                        <asp:HyperLink ID="hpLkReleased" runat="server" CssClass="ReleaseBtn" NavigateUrl="Publish_Entry.aspx"></asp:HyperLink>
                    </div>
                    <div style="margin-left: 72px; margin-top: 72px; text-decoration: underline; width: 100px;
                        height: 14px;">
                        <%--<a href="#" class="Set12px" style="text-decoration: underline;">>>积分细则</a>--%>
                        <asp:HyperLink ID="hpLkScoresRule" runat="server" CssClass="Set12px" style="text-decoration: underline;" NavigateUrl="BrokenPage.aspx">>>积分细则</asp:HyperLink>
                    </div>
                </div>
                <div class="EditPasswordView">
                    <div class="EditPasswordImg">
                        <p style="float: right; font-size: 18px; font-weight: bold; margin-right: 20px; margin-bottom: 10px;
                            color: #3e3e3e;">
                            修改密码</p>
                    </div>
                    <div class="EditPassword">
                        <p style="margin-top: 40px;">
                            用户名： 
                        <asp:Label ID="lblUserNameShow" runat="server"></asp:Label>
                        </p>
                        <p style="margin-top: 40px;">
                            原始密码：
                        </p>
                        <%--<input class="InputText" type="text" />--%>
                        <asp:TextBox ID="txtOldPass" runat="server" CssClass="InputText"></asp:TextBox>
                        <p>
                            新密码：
                        </p>
                    <%--    <input class="InputText" type="text" />--%>
                        <asp:TextBox ID="txtNewPass" runat="server" CssClass="InputText" 
                            TextMode="Password"></asp:TextBox>
                        <p>
                            确认密码：
                        </p>
                        <%--<input class="InputText" type="text" />--%>
                        <asp:TextBox ID="txtEnsurePass" runat="server" CssClass="InputText" 
                            TextMode="Password"></asp:TextBox>
                        <div style="clear: both;">
                        </div>
                        <div>
                            <div class="ResetBtn">
                               <%-- <a href="#"></a>--%>
                                <asp:LinkButton ID="lkBtnReset" runat="server" onclick="lkBtnReset_Click"></asp:LinkButton>
                            </div>
                            <div class="CancelBtn">
                               <%-- <a href="#"></a>--%>
                                <asp:LinkButton ID="lkBtnCancel" runat="server" onclick="lkBtnCancel_Click"></asp:LinkButton>
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
                <%--<a href="#" title="联系我们" class="Bottom_Info">联系我们</a>--%>
                <asp:HyperLink ID="hpLkNotyify" runat="server" CssClass="Bottom_Info" ToolTip="联系我们" NavigateUrl ="BrokenPage.aspx">联系我们</asp:HyperLink>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
