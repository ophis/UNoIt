<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>U No.IT -- 百科，你懂的。</title>
    <link href="css/Index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Window">
        <div class="PersonNav">
            <span class="logo">
                <img src="images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                     margin-left: 30px" />
            </span>
         <%--   <label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>--%>
            <asp:Label ID="lblHi" runat="server" Text="Hi,你好！" CssClass="Set12px" style="margin-left: 500px;"></asp:Label>

            <%--<a class="Set12px" title="登录" href="Login.aspx">登录</a> --%>  
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass = "Set12px" NavigateUrl="~/Login.aspx">登录</asp:HyperLink>              
           <%-- <a class="Set12px" title="注册" href="Index.aspx">注册</a> --%>

            <%--<asp:LinkButton ID="lkBtnSign" runat="server" CssClass = "Set12px" 
                onclick="lkBtnSign_Click">注册</asp:LinkButton>--%>

                  <asp:LinkButton ID="lkBtnSign" runat="server" CssClass = "Set12px">注册</asp:LinkButton>
           
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
                <div class="ImgFlash">
                    <script>
                        var widths = 443;  //这个数值是效果显示的宽度   
                        var heights = 222;    //这个数值是效果显示的高度           
                        var counts = 5;   //这个数值是共有几张图片
                        //以下是图片地址和链接地址 请注意每个图片都对应一个链接地址
                        img1 = new Image(); img1.src = 'images/FlashImg/Cat.jpg';    //把src=''之内的地址换成您自己的图片地址
                        img2 = new Image(); img2.src = 'images/FlashImg/Cat2.jpg';  //把src=''之内的地址换成您自己的图片地址
                        img3 = new Image(); img3.src = 'images/FlashImg/miku.jpg';  //把src=''之内的地址换成您自己的图片地址
                        img4 = new Image(); img4.src = 'images/FlashImg/Q.jpg';  //把src=''之内的地址换成您自己的图片地址
                        img5 = new Image(); img5.src = 'images/FlashImg/Dream.jpg';  //把src=''之内的地址换成您自己的图片地址
                        /*img6 = new Image(); img6.src = 'http://www.yesky.com/imagelist/2007/015/67vtz4ew2m5s.jpg';  //把src=''之内的地址换成您自己的图片地址*/
                        url1 = new Image(); url1.src = 'http://www.w3school.com.cn'; //把src=''之内的地址换成您自己的链接地址
                        url2 = new Image(); url2.src = 'http://www.youku.com'; //把src=''之内的地址换成您自己的链接地址
                        url3 = new Image(); url3.src = 'http://www.seu.edu.cn'; //把src=''之内的地址换成您自己的链接地址
                        url4 = new Image(); url4.src = 'http://www.bjnets.com'; //把src=''之内的地址换成您自己的链接地址
                        url5 = new Image(); url5.src = 'http://www.bjnets.com'; //把src=''之内的地址换成您自己的链接地址
                        /* url6 = new Image(); url6.src = 'http://www.bjnets.com'; //把src=''之内的地址换成您自己的链接地址 */
                        var nn = 1;
                        var key = 0;
                        function change_img() {
                            if (key == 0) { key = 1; }
                            else if (document.all)
                            { document.getElementById("pic").filters[0].Apply(); document.getElementById("pic").filters[0].Play(duration = 2); }
                            eval('document.getElementById("pic").src=img' + nn + '.src');
                            eval('document.getElementById("url").href=url' + nn + '.src');
                            for (var i = 1; i <= counts; i++) { document.getElementById("xxjdjj" + i).className = 'axx'; }
                            document.getElementById("xxjdjj" + nn).className = 'bxx';
                            nn++; if (nn > counts) { nn = 1; }
                            tt = setTimeout('change_img()', 4000);
                        }
                        function changeimg(n) { nn = n; window.clearInterval(tt); change_img(); }
                        document.write('<style>');
                        document.write('.axx{padding:1px 7px;border-left:#cccccc 1px solid;}');
                        document.write('a.axx:link,a.axx:visited{text-decoration:none;color:#fff;line-height:12px;font:9px sans-serif;background-color:#666;}');
                        document.write('a.axx:active,a.axx:hover{text-decoration:none;color:#fff;line-height:12px;font:9px sans-serif;background-color:#999;}');
                        document.write('.bxx{padding:1px 7px;border-left:#cccccc 1px solid;}');
                        document.write('a.bxx:link,a.bxx:visited{text-decoration:none;color:#fff;line-height:12px;font:9px sans-serif;background-color:#D34600;}');
                        document.write('a.bxx:active,a.bxx:hover{text-decoration:none;color:#fff;line-height:12px;font:9px sans-serif;background-color:#D34600;}');
                        document.write('</style>');
                        document.write('<div style="width:' + widths + 'px;height:' + heights + 'px;overflow:hidden;text-overflow:clip;">');
                        document.write('<div><a id="url"><img id="pic" style="border:0px;filter:progid:dximagetransform.microsoft.wipe(gradientsize=1.0,wipestyle=4, motion=forward)" width=' + widths + ' height=' + heights + ' /></a></div>');
                        document.write('<div style="filter:alpha(style=1,opacity=10,finishOpacity=80);background: #888888;width:100%-2px;text-align:right;top:-12px;position:relative;margin:1px;height:12px;padding:0px;margin:0px;border:0px;">');
                        for (var i = 1; i < counts + 1; i++) { document.write('<a href="javascript:changeimg(' + i + ');" id="xxjdjj' + i + '" class="axx" target="_self">' + i + '</a>'); }
                        document.write('</div></div>');
                        change_img();
                    </script>
                </div>
                
                <div class="LoginDiv" id="loginDiv" runat="server">
                    <div class="loginImg">
                    </div>
                    <p class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 8px; margin-bottom: 5px;">
                        用户名：</p>
                    <%--<input class="InputText" id="Text_UID" type="text" />--%>

                    <asp:TextBox ID="Text_UID" CssClass="InputText" runat="server"></asp:TextBox>

                    <p class="Set12px" style="text-align: left; margin-left: 15px; margin-top: 5px; margin-bottom: 5px;">
                        密码：</p>
                   <%-- <input class="InputText" id="Text_Password" type="text" />--%>
                    <asp:TextBox ID="Text_Password" CssClass="InputText" runat="server" 
                        TextMode="Password"></asp:TextBox>

                    <p style="font-size: 12px; vertical-align: text-bottom;">
                        <%--<input class="Check_Remeber" type="checkbox" style="margin-left: 20px;" />--%>
                        <asp:CheckBox ID="checkRememberMe" CssClass="Check_Remeber" runat="server" style="margin-left: 20px;" />
                        记住我</p>
                    <div>
                        <a href="#" style="font-size:10px; float: right; position: relative; top: -30px;
                            right: 20px; text-decoration: underline;">忘记密码？</a></div>
                    <div class="Join">
                        <a href="SignUp.aspx" title="注册一个账号">立即加入UNo</a></div>
                    <div class="Login">
                        <%--<a href="#" title="登录" class="LoginButton"></a>--%>
                        <asp:LinkButton ID="LinkBtnLogin"  CssClass="LoginButton" runat="server" OnClick = "LinkBtnLogin_Click"></asp:LinkButton>
                    </div>
                </div>
                <div class="UserInfoDiv" id="userInfoDiv" runat="server">
                    <div class="InfoImg">
                    </div>
                    <div class="UserAva">
                        <img src="images/img_Home/DefaultAva.png" style="height: 64px; width: 64px;" />
                    </div>
                    <label id="lblUserName" runat="server" style="font-size: 14px; color: #99cc66; text-align: left; position: relative;
                        top: -65px; left: 90px; display: inline;">
                        </label>
                    <label style="font-size: 12px; color: #3e3e3e; text-align: left; position: relative;
                        top: -45px; left: 8px; display: inline;">
                        <%--我的积分：<label id="lblMyScore" runat="server"></label>--%></label>
                    <a href="PersonalHP_MyEntry.aspx" style="font-size: 14px; color: #FFcc66; float: right;
                        position: relative; top: 10px; right: 53px; text-decoration: underline;">进入我的主页</a>
                    <%--<a href="Publish_Entry.aspx" title="发布词条" class="PublishButton"></a>--%>
                    <asp:HyperLink ID="hpLkGetPass" runat="server" style="font-size: 10px; float: right; position: relative; top: 0px; right: 5px;
                                text-decoration: underline;" NavigateUrl="~/Retrieve_Password.aspx">忘记密码？</asp:HyperLink>
                </div>  
                <div style="height: 30px; clear: both;">
                </div>
                <div class="HotView">
                    <div class="HotImg">
                    </div>
                    <ul class="HotBody">

                        <asp:DataList ID="dataListHotEnties" runat="server">
                        <ItemTemplate>
                         <li class="HotEntry">
                            <div class="EntryTitle">                           
                                <a class="Title" href='<%#@"ViewEntry.aspx?title="+BLL.EntryUtility.GetEntryNameById((int)Eval("EntryId"))%>' title="点击查看" target="_blank"><%#BLL.EntryUtility.GetEntryNameById((int)Eval("EntryId"))%></a>
                            </div>
                            <div>
                                <span class="EntryBody"><%#Eval("Content")%>
                                </span>
                            </div>
                        </li>                       
                        </ItemTemplate>
                        </asp:DataList>

                    </ul>
                </div>
            </div>
            <div class="tail">
                <a href="BrokenPage.aspx" title="#-Sharp!" class="Bottom_Info">团队介绍</a>
                <label class="Bottom_Info" style="color:White; margin-left:2px; margin-right: 2px;">
                    |</label>
                <a href="BrokenPage.aspx" title="联系我们" class="Bottom_Info">联系我们</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
