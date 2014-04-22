<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalHP_EditInfo.aspx.cs" Inherits="PersonalHP_EditInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>个人主页-个人资料设置</title>
    <link href="CSS/PersonalHP_EditInfo.css" rel="stylesheet" type="text/css" />
    <link href="CSS/CommonPart.css" rel="stylesheet" type="text/css" />
    <link href="css/custom-theme/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script>        
    $(function () {
        $("#txtBirthdate").datepicker({
                changeMonth: true,
                changeYear: true
            });
        });	</script>
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
               <%-- <asp:Label ID="lblHi" runat="server" Text="Hi,你好！"  CssClass="Set12px" style="margin-left: 500px;"></asp:Label>
            <a class="Set12px" title="登录" href="Login.aspx">登录</a>
             <a class="Set12px" title="注册" href="Index.aspx">注册</a> --%>
               <asp:HyperLink ID="hpLkSayHi" runat="server" CssClass="Set12px" Style="margin-left: 500px;">Hi,你好！</asp:HyperLink>
           <%-- <a class="Set12px" title="登录" href="Login.aspx">登录</a> --%>
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass="Set12px">登录</asp:HyperLink>
           <%-- <a class="Set12px" title="注册" href="Index.aspx">注册</a>--%>
          <%--  <asp:HyperLink ID="hpLkSign" runat="server" CssClass="Set12px">注册</asp:HyperLink>
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
                    style="font-weight: bold; margin-left: 27px;" onclick="linkBtnSearch_Click1">求科普</asp:LinkButton>
                  </span>
            <div class="nav">
                <a href="Index.aspx" title="主页"></a><a href="Index.aspx" title="分类目录"></a><a href="PersonalHP_MyEntry.aspx"
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
                        <asp:Label ID="lblUserName" runat="server"  
                            Font-Size="16px" ForeColor="#99CC66" ></asp:Label>
                    <div style="text-align: left;">
                        <%--<label class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;
                            margin-bottom: 5px;">
                            职位：</label>--%>
                        <asp:Label ID="lblPosition" runat="server" CssClass="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px;margin-bottom: 5px;">
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
                <div class="EditinfoView">
                    <div>
                        <p style="float: right; font-size: 18px; font-weight: bold; margin-right: 20px; margin-bottom: 10px;
                            color: #3e3e3e;">
                            个人资料设置</p>
                    </div>
                    <div class="EditInfo" style="border-top: 2px dashed #99cc67; margin-top: 56px;">
                        <p style="margin-top: 25px;">
                            用户名：</p>
                        <%--<label style=" position:relative; top:-20px; left:-35px;">
                            FTSamoyed</label>--%>                            
                        <asp:Label ID="lblUserName2" runat="server" style=" position:relative; top:-20px; left:-35px;" Text = "<%#userName %>"></asp:Label>
                        <p>
                            头像设置：</p>
                        <%--<input class="InputText" type="text" style=" position:relative; left:78px;" />--%>
                        <asp:TextBox ID="txtPhotoUrl" runat="server" CssClass="InputText" type="text" style=" position:relative; left:78px;"></asp:TextBox>
                        <span style="  float: right; font-size: 10px; color: #cccccc; position:relative; top:10px; right:30px;">
                            (图片url，推荐使用100x100)</span>

                            <form>
                        <p>
                            性 别：</p>
                        <ul style="margin-top: -35px;margin-bottom:30px;">
                            
                            <li class="Select" >                           
                                <%--<input id="Radio1" type="radio" style="position: relative; margin-right: 10px;" name="sex" />男--%>
                                <%--<asp:CheckBox ID="checkGender1" runat="server" type="radio" style="position: relative; margin-right: 10px;" name="sex" />男--%>
                                <asp:RadioButton ID="rdGender1" runat="server" type="radio" style="position: relative; margin-right: 10px;" GroupName="sex" />男
                            </li>
                            <li class="Select">
                                <%--<input id="Radio2" type="radio" style="position: relative; margin-right: 10px;" name="sex" />女--%>
                                <%--<asp:CheckBox ID="checkGender2" runat="server" type="radio" style="position: relative; margin-right: 10px;" name="sex" />女--%>
                                <asp:RadioButton ID="rdGender2" runat="server" type="radio" style="position: relative; margin-right: 10px;" GroupName="sex" />女
                            </li>
                           
                            <li class="Select">
                                <%--<input id="Radio3" type="radio" style="position: relative; margin-right: 10px;" name="sex"; checked="checked" />保密--%>
                                <%--<asp:CheckBox ID="checkGender3" runat="server" type="radio" style="position: relative; margin-right: 10px;" name="sex" />保密--%>
                                <asp:RadioButton ID="rdGender3" runat="server" type="radio" style="position: relative; margin-right: 10px;" GroupName="sex" />保密
                            </li>                           
                       
                            
                        </ul>
                        </form>
                        <p>
                            生 日：
                        </p>
                        <%--<input class="InputText" type="text" />--%>
                        <asp:TextBox ID="txtBirthdate" runat="server" CssClass="InputText"></asp:TextBox>
                        <p>
                            所在地：
                        </p>
                        <%--<input class="InputText" type="text" />--%>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="InputText"></asp:TextBox>
                        <p>
                            擅长领域：
                        </p>
                        <%--<input class="InputText" type="text" />--%>
                        <asp:TextBox ID="txtSkilledField" runat="server" CssClass="InputText"></asp:TextBox>
                        <div style="clear: both;">
                        </div>
                        <div>
                      <%--    TODO 页面跳转--%>
                            <div class="EditBtn">
                               <%-- <a href="#"></a>--%>
                                <asp:LinkButton ID="linkBtnEdit" runat="server" onclick="linkBtnEdit_Click"></asp:LinkButton>
                            </div>
                            <div class="CancelBtn">
                                <%--<a href="#"></a>--%>
                                <asp:LinkButton ID="linkBtnCancel" runat="server" onclick="linkBtnCancel_Click"></asp:LinkButton>
                            </div>
                        </div>
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
    </div>
    </form>
</body>
</html>
