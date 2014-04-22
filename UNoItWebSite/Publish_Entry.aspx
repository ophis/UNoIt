<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Publish_Entry.aspx.cs" Inherits="Publish_Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/jquery-1.6.2.js" type="text/javascript"></script>
    <title>U No.IT -- 发布词条</title>
    <link href="CSS/Publish_Entry.css" rel="stylesheet" type="text/css" />

   <script type="text/javascript" src="xheditor-1.1.10/jquery/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="xheditor-1.1.10/xheditor-1.1.10-zh-cn.min.js"></script>
    <script type="text/javascript">

        $(pageInit);
        var editor;
        function pageInit() {
            editor = $('#TextArea1').xheditor({ tools: 'simple' });   //交互方式1
        }
        function submitForm() { $('#frmDemo').submit(); }

        function source() {
            var str = editor.getSource();
//            document.getElementById("lblXhEditorContent").value = str;
        }

        $(document).ready(function () {
            $("#Select1").change(function () {
                test();
            });
        });
        function test() {
            var catagoryName = $("#Select1").children('option:selected').val();
            $.ajax({
                url: "Publish_Entry.aspx/GetSecondCatagory",
                data: '{"catagoryName":"' + catagoryName + '"}', /*"name":"' + userName + '"*/
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                success: function (result) {
                    getOptions(result.d);
                }
            });
        }
        function getOptions(result) {
            $("#Select2").empty();
            for (i = 0; i < result.length; i++) {
                var o = document.createElement("option");
                o.value = result[i];
                o.text = result[i];
                $("#Select2")[0].options.add(o);
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Window">
        <%--<div class="PersonNav">
            <span class="logo">
                <img src="images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                    margin-left: 30px" />
            </span>
            <%--<label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>--%>
            <asp:HyperLink ID="hpLkSayHi" runat="server" CssClass="Set12px" style="margin-left: 500px;"> Hi,你好！</asp:HyperLink>
           <%-- <a class="Set12px" title="登录" href="Login.aspx">登录</a>--%>
        <asp:HyperLink ID="hpLkLogin" runat="server" CssClass = "Set12px" NavigateUrl ="~/Login.aspx">登录</asp:HyperLink>
       <%--      <a class="Set12px" title="注册"href="SignUp.aspx">注册</a>--%>
     <%--   <asp:HyperLink ID="hpLkSign" runat="server" CssClass = "Set12px" NavigateUrl="~/SignUp.aspx">注册</asp:HyperLink>
     --%>    

        <asp:LinkButton ID="lkBtnSign" runat="server" CssClass = "Set12px" OnClick = "hpLkSign_Click">注册</asp:LinkButton>   

              <a class="Set12px" title="联系我们" href="BrokenPage.aspx">联系我们</a>
        </div>--%>
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
                <a href="Index.aspx" title="主页"></a><a href="Catalog.aspx" title="分类目录"></a>
            </div>
            <div class="MainBody">
                <div class="PublishDiv">
                    <div class="PublishImg">
                    </div>
                    <h4 style="clear: both; position: relative; left: 155px; top: -22px; font-size: 24px;
                        color: #99cc66">
                        发布词条</h4>
                    <div class="PublishInfo">
                        <p>
                            词条名称：</p>
                        <input class="InputText" id="Text_UID"  runat="server" type="text" />
                        <p>
                            词条内容</p>
                        <textarea id="TextArea1" cols="47" rows="12" runat="server"
                            style="border: 1px solid #99cc67;resize: none;"></textarea>
                        <p>
                            参考链接：</p>
                        <input class="InputText" id="Text_Password" type="text"  runat="server"/>
                        <div class="Publish">
<%--                            <a href="#" title="确认发布" class="PublishButton"></a>--%>
                            <asp:LinkButton ID="linkBtnPublish" runat="server" CssClass="PublishButton" 
                                onclick="linkBtnPublish_Click" OnClientClick = "source()"></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="WelcomDiv">
                    <div class="SharpLogo">
                        <img src="images/sharplogo.png" style="height: 111px; width: 137px;" />
                    </div>
                    <p style="font-size: 14px; color: #66cccc;">
                        开发团队：#(Sharp)</p>
                    <div class="SelectClass" style="margin-top: 28px;">
                        <p>
                            选择所属目录:</p>
                        <div class="Select">
                            <%--<select id="Select1">
                                <option></option>
                            </select>
                            <select id="Select2" style="margin-top: 28px;">
                                <option></option>
                            </select>--%>
                            <asp:DropDownList ID="Select1" runat="server">
                                <asp:ListItem>自然</asp:ListItem>
                                <asp:ListItem>科技</asp:ListItem>
                                <asp:ListItem>文化</asp:ListItem>
                                <asp:ListItem>生活</asp:ListItem>
                                <asp:ListItem>社会</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="Select2" runat="server" style="margin-top: 28px;">
                            </asp:DropDownList>
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
    </form>
   <%--<label id="lblXhEditorContent" runat="server" visible="false"></label>--%>

</body>
</html>
