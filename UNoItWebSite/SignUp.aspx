<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/SignUp.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Click = document.getElementById("Click_Rule");
        function displayRule() {
            alert("这里是守则啊哈哈。");
        }
        var SignLink;
        var userNameRight = false,emailRight=false,passwordRight=false;
        $(document).ready(function () {
            $("#inputPass").hide();
            $("#inputPass1").hide();
            $("#inputUserName").hide();
            $("#inputEmail").hide();
            SignLink = $("#lkBtnSign").attr("href");
            $("#txtUserName").blur(function () {
                validateUserName();
            });
            $("#txtEmail").blur(function () {
                validateEmail();
            });
            $("#txtPassword").blur(function () {
                var pass1 = document.getElementById("txtPassword").value;

                if (pass1 == "") {
                    $("#inputPass1").html("密码不能为空");
                    $("#inputPass1").show();
                    passwordRight = false; canSignUp();
                }
                else {
                    re = /^\w{6,18}$/;
                    if(!re.test(pass1)){
                        $("#inputPass1").html("必须为6-18位");
                        $("#inputPass1").show();
                        passwordRight = false;
                        return;
                    }
                    $("#inputPass1").hide();
                    passwordRight = true; canSignUp();
                }
            });
            $("#txtPassEnsure").blur(function () {
                var pass1 = document.getElementById("txtPassword").value;
                var pass2 = document.getElementById("txtPassEnsure").value;
                if (pass1 != pass2) {
                    $("#inputPass").show();
                    passwordRight = false; canSignUp();
                }
                else {
                    $("#inputPass").hide();
                    passwordRight = true; canSignUp();
                }
            });

        });

        function validateUserName() {
            var userName = document.getElementById("txtUserName").value;
            if (userName == "") {
                var attr0 = document.getElementById("inputUserName").attributes["style"].nodeValue;
                attr0 = attr0 + ";color:red";
                $("#inputUserName").attr("style", attr0);
                $("#inputUserName").html("用户名不可为空");
                $("#inputUserName").show();
                userNameRight = false; canSignUp();
                return;
            }
            $.ajax({
                url: "SignUp.aspx/ValidateUserName",
                data: '{"userName":"' + userName + '"}', /*"name":"' + userName + '"*/
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                success: function (result) {
                    setUserName(result.d);
                }
            });
        }

        function setUserName(isExsit) {
            if (isExsit) {
                var attr0 = document.getElementById("inputUserName").attributes["style"].nodeValue;
                attr0 = attr0 + ";color:red";
                $("#inputUserName").attr("style", attr0);
                $("#inputUserName").html("用户名已存在");
                $("#inputUserName").show();
                userNameRight = false; canSignUp();
            }
            else {
                var attr0 = document.getElementById("inputUserName").attributes["style"].nodeValue;
                attr0 = attr0 + ";color:green";
                $("#inputUserName").attr("style", attr0);
                $("#inputUserName").html("用户名可使用");
                $("#inputUserName").show();
                userNameRight = true; canSignUp();
            }
        }

        function validateEmail() {
            var email = document.getElementById("txtEmail").value;
            var re = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
            var attr0 = document.getElementById("inputEmail").attributes["style"].nodeValue;
            if (email == "") {        
                attr0 = attr0 + ";color:red";
                $("#inputEmail").attr("style", attr0);
                $("#inputEmail").html("邮箱不可为空");
                $("#inputEmail").show();
                emailRight = false; canSignUp();
            }
            else {
                if (!re.test(email)) {
                    attr0 = attr0 + ";color:red";
                    $("#inputEmail").attr("style", attr0);
                    $("#inputEmail").html("邮箱格式不正确");
                    $("#inputEmail").show();
                    emailRight = false;
                    canSignUp();
                }
                else {
                    $.ajax({
                        url: "SignUp.aspx/ValidateEmail",
                        data: '{"email":"' + email + '"}',
                        type: "POST",
                        contentType: "application/json",
                        dataType: "json",
                        success: function (result) {
                            setEmail(result.d);
                        }
                    });
                }
            }
            
        }

        function setEmail(isExsit) {
            var attr0 = document.getElementById("inputEmail").attributes["style"].nodeValue;
            
            if (isExsit) {
                //var attr0 = document.getElementById("inputEmail").attributes["style"].nodeValue;
                attr0 = attr0 + ";color:red";
                $("#inputEmail").attr("style", attr0);
                $("#inputEmail").html("邮箱已被注册");
                $("#inputEmail").show();
                emailRight = false;
                canSignUp();
            }
            else {
                //var attr0 = document.getElementById("inputEmail").attributes["style"].nodeValue;
                attr0 = attr0 + ";color:green";
                $("#inputEmail").attr("style", attr0);
                $("#inputEmail").html("邮箱可使用");
                $("#inputEmail").show();
                emailRight = true;
                canSignUp();
            }
        }

        function canSignUp() {
            if (userNameRight && emailRight && passwordRight) {
                $("#lkBtnSign").attr("href", SignLink);
                return;
            }
            $("#lkBtnSign").attr("href", "#");
        }

    </script>
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
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass="Set12px" title="登录" NavigateUrl="Login.aspx">登录</asp:HyperLink>
            <%--<a class="Set12px" title="注册" href="SignUp.htm">注册</a> --%>
            <asp:HyperLink ID="hpLkSignUp" runat="server" CssClass="Set12px" title="注册" NavigateUrl="SignUp.aspx">注册</asp:HyperLink>
            <%-- <a class="Set12px" title="联系我们" href="Index.htm">联系我们</a>--%>
            <asp:HyperLink ID="hpLkAbout" runat="server" CssClass="Set12px" title="联系我们" NavigateUrl="BrokenPage.aspx">联系我们</asp:HyperLink>
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
                <a href="Index.aspx" title="主页"></a>
                <%--<asp:HyperLink ID="hpLkHomepage" runat="server" NavigateUrl ="######">主页</asp:HyperLink>--%>
                <a href="Catalog.aspx" title="分类目录"></a>
                <%--<asp:HyperLink ID="hpLkCategory" runat="server" NavigateUrl ="######">分类目录</asp:HyperLink>--%>
            </div>
            <div class="MainBody">
                <div class="SignDiv">
                    <div class="SignImg">
                    </div>
                    <h4 style="clear: both; position: relative; left: 175px; top: -22px; font-size: 24px;
                        color: #99cc66">
                        注册</h4>
                    <div class="SignInfo">
                        <div style="text-align: left; margin-left: 70px; margin-top: 35px; font-size: 14px;
                            color: #3e3e3e;">
                            用户名：</div>
                        <%--  <input CssClass="InputText" id="Text_UID" type="text" style="top: -25px;" />--%>
                        <asp:TextBox ID="txtUserName" runat="server" Style="top: -25px;" CssClass="InputText"></asp:TextBox>
                        <label id="inputUserName" style="clear: both; float:right;font-size:10px;margin-top: -15px; text-align:right; ">
                            </label>
                        <p class="Tip" style="top: -35px; left:0px;">
                            （请注意不区分大小写）</p>
                        <div style="text-align: left; margin-left: 70px; font-size: 14px; color: #3e3e3e;
                            position: relative; top: -20px;">
                            邮箱：</div>
                        <%--<input CssClass="InputText" id="Text_Email" type="text" style="top: -45px;" />--%>
                        <asp:TextBox ID="txtEmail" runat="server" Style="top: -45px;" CssClass="InputText"></asp:TextBox>
                        <label id="inputEmail"" style="clear: both; float:right;font-size:10px;margin-top: -35px; text-align:right;">
                            </label>
                        <p class="Tip" style="top: -55px; left:0px">
                            （我们会通过邮箱进行验证，请填写真实邮箱）</p>
                        <div style="text-align: left; margin-left: 70px; font-size: 14px; color: #3e3e3e;
                            position: relative; top: -40px;">
                            密码：</div>
                        <%--<input CssClass="InputText" id="Text_Password" type="text" style="top: -65px;" />--%>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="InputText" 
                            Style="top: -65px;" TextMode="Password"></asp:TextBox>
                        <label id="inputPass1"" style="color:red;clear: both; float:right;font-size:10px;margin-top: -55px; text-align:right;">
                            密码不能为空</label>
                        <p class="Tip" style="top: -75px;">
                            （6-12位英文与数字的组合）</p>
                        <div style="text-align: left; margin-left: 70px; font-size: 14px; color: #3e3e3e;
                            position: relative; top: -60px;">
                            确认密码：</div>
                        <%--  <input CssClass="InputText" id="Text_PassAgain" type="text" style="top: -85px;" />--%>
                        <asp:TextBox ID="txtPassEnsure" runat="server" Style="top: -85px;" 
                            CssClass="InputText" TextMode="Password"></asp:TextBox>
                        <label id="inputPass"" style="color:red;clear: both; float:right;font-size:10px;margin-top: -75px; text-align:right;">
                            两次密码不一致</label>
                        <p class="Tip" style="top: -95px;">
                            （再输入一次密码）</p>
                        <a id="Click_Rule" href="BrokenPage.aspx" style="font-size: 12px;
                            float: right; position: relative; top: -95px; text-decoration: underline; right: 30px;">
                            点击查看Uno守则</a>
                        <div class="Sign" style="clear: both;">
                            <%--<a href="#" title="注册" class="SignButton"></a>--%>
                            <%--<asp:HyperLink ID="hpLkSign" runat="server" CssClass="SignButton"></asp:HyperLink>--%>
                            <asp:LinkButton ID="lkBtnSign" runat="server" CssClass="SignButton" OnClick="lkBtnSign_Click"></asp:LinkButton>
                            
                        </div>
                        <div class="Cancel">
                            <%--<a href="#" title="取消" class="CancelButton"></a>--%>
                            <%--<asp:HyperLink ID="hpLkCancel" runat="server" CssClass="CancelButton"></asp:HyperLink>--%>
                            <asp:LinkButton ID="lkBtnCancel" runat="server" CssClass="CancelButton"></asp:LinkButton>
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
                            >>已经有UNo账号了？</p>
                        <div class="Login">
                            <a href="Login.aspx" title="登录" class="LoginButton"></a>   
                            <%--<asp:HyperLink ID="hpLogin" runat="server" CssClass="LoginButton"></asp:HyperLink>--%>
                        </div>
                    </div>
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
            <a href="BrokenPage.aspx" title="联系我们" class="Bottom_Info">联系我们</a>
        </div>
    </div>
    </form>
</body>
</html>
