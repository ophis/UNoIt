<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modify_Entry.aspx.cs" Inherits="Modify_Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>U No.IT -- 修改词条</title>
    <link href="CSS/Modify_Entry.css" rel="stylesheet" type="text/css" />
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
                    style="font-weight: bold; margin-left: 27px;" onclick="linkBtnSearch_Click">求科普</asp:LinkButton>
                  </span>
            </div>
            <div class="nav">
                <a href="Index.aspx" title="主页"></a><a href="Catalog.aspx" title="分类目录"></a>
            </div>
            <div class="MainBody">
                <div class="ModifyDiv">
                    <div class="ModifyImg">
                    </div>
                    <h4 style="clear: both; position: relative; left: 155px; top: -22px; font-size: 24px;
                        color: #99cc66">
                        修改词条</h4>
                    <div class="ModifyInfo">
                        <p>
                            词条名称：</p>
                        <h4 id="hEntryName" runat="server" style="font-size:18px; text-align:left; margin-left:60px; top:-10px; position:relative; color:#66cccc">                            
                        </h4>
                        <p style="margin-top: -8px;">
                            词条内容：</p>
                        <textarea id="TextArea1" runat="server" cols="47" rows="12" style="border: 1px solid #99cc67;resize: none;"></textarea>
                        <p>
                            参考链接：</p>
                        <input class="InputText" id="Text_Password" runat="server" type="text" />
                        <div class="Modify">
                           <%-- <a href="#" title="提交修改" class="ModifyButton"></a>--%>
                            <asp:LinkButton ID="linkBtnEdit" runat="server" class="ModifyButton" onclick="linkBtnEdit_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="WelcomDiv">
                    <p style="margin-top: 60px;  text-align: left;margin-left: 33px;font-size: 14px;font-weight:bold; color: #3e3e3e;">
                        原发布人：</p>
                    <div class="DefaultAva">
                        <img src="images/img_Entry/DefaultAva.gif" />
                        <%--<asp:Image ID="ImagePublisher" runat="server" />--%>
                    </div>
                    <p id="publisherUseName" style=" font-size: 12pt; color: #99d35f;font-weight:bold; margin:17px auto auto auto;">                        
                    </p>
                    <p id="pReleaseTime"  runat="server" style=" font-size: 10pt; color: #99d35f;font-weight:bold; margin:6px auto auto auto;">                        
                    </p>
                    <div class="SelectClass" style="margin-top: 35px;">
                        <p>
                            词条所属目录:</p>
                        <div class="Select">
                            <%--<select id="Select1">
                                <option></option>
                            </select>
                            <select id="Select2" style="margin-top: 28px;">
                                <option></option>
                            </select>--%>
                           <label  id="lblFirstCatagory" runat="server" style="margin-left:5px; font-size:14px;"></label>
                           <label>>></label>
                           <label id="lblSecondCatagory" runat="server" style="font-size:14px;" ></label>
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
</body>
</html>
