<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager_IFComment.aspx.cs" Inherits="Admin_Manager_IFComment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>U No.IT -- 超级管理员！</title>
    <link href="../CSS/Manager_IFComment.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Window">
        <div class="PersonNav">
            <span class="logo">
                <img src="../images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                    margin-left: 30px" />
            </span>
           <%-- <label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>--%>
              <asp:HyperLink ID="hpLkSayHi" runat="server" CssClass="Set12px" Style="margin-left: 500px;">Hi,你好！</asp:HyperLink>
           <%-- <a class="Set12px" title="登录" href="Login.aspx">登录</a> --%>
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass="Set12px">登录</asp:HyperLink>
           <%-- <a class="Set12px" title="注册" href="Index.aspx">注册</a>--%>
           <%-- <asp:HyperLink ID="hpLkSign" runat="server" CssClass="Set12px">注册</asp:HyperLink>
           --%> 

            <asp:LinkButton ID="lkBtnSign" runat="server" CssClass="Set12px" 
                onclick="lkBtnSign_Click">注册</asp:LinkButton>      
           
              <a class="Set12px" title="联系我们" href="../BrokenPage.aspx">联系我们</a>
           
           </div>
        <div class="MainDiv">
            <div class="search">
            </div>
                <div class="nav">
                <a href="Manager_Entry.aspx" title="词条审核"></a>
                <a href="Manager_IFComment.aspx" title="举报评论"></a>
                <a href="Manager_IFEntry.aspx" title="举报词条"></a>
                <a href="Manager_ResetKey.aspx" title="修改密码"></a>  
            </div>

            <div class="MainBody">
                <div class="ManageIFCommentView">
                    <p style="float: right; font-size: 18px; font-weight: bold; margin-right: 40px; color: #3e3e3e;">
                        举报评论</p>
                    <div style="clear: both;">

                    <ul class="ManageIFCommentBody">
                        <asp:DataList ID="dtList" runat="server">
                        <ItemTemplate>                  
                        
                            <li class="ManageIFComment">
                                <div class="DefaultAva">
                                    <img src="../images/img_Manager/DefaultAva.png" style="width: 39px; height: 39px;" />
                                   <%-- <p>
                                        FTSamoyed</p>--%>
                                      <asp:Label ID="Label1" runat="server" Text= <%#Eval("proUser") %>></asp:Label>
                                 </div>
                                <div class="IFComment">
                                    <div class="IFCommentTitle">
                                        <label>
                                            举报
                                        </label>
                                        <%--<a class="Title" href="#" title="点击查看" target="_blank">尤塞恩·博尔特</a>
                                        --%>
                                        <asp:HyperLink ID="hpLkTitle" CssClass = "Title" runat="server" ToolTip="点击查看" target="_blank" NavigateUrl=<%#@"../ViewEntry.aspx?title="+Eval("entryName")%> Text = <%#Eval("entryName") %> ></asp:HyperLink>
                                    
                                        <label>
                                            中的评论：</label>
                                    </div>

                                    <div>
                                       <%-- <span class="IFEntryBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                        </span>--%>
                                        <asp:Label ID="lblCommmentContents" runat="server" Text=<%#Eval("commentContents") %> CssClass="IFCommentBody"></asp:Label>
                                        
                                        <span class="IFCommentInfo">日期：

                                        <%--<label>2011-09-01</label>--%>
                                            <asp:Label ID="lblTime" runat="server" Text=<%#Eval("proTime") %>></asp:Label>
                                       <%-- <a href="#" class="scan">通过</a>--%>
                                            <asp:LinkButton ID="lkBtnSubmit" runat="server" CssClass="scan" CommandArgument = <%#Eval("commentID") %>
                                            onclick="lkBtnSubmit_Click">通过</asp:LinkButton>
                                       <%-- <a class="scan" href="#">不通过</a>--%>
                                            <asp:LinkButton ID="lkBtnCancel" runat="server" CssClass="scan" 
                                            CommandArgument = <%#Eval("commentID") %> onclick="lkBtnCancel_Click">不通过</asp:LinkButton>
                                        </span>
                                    </div>

                                </div>
                            </li>
                       <%--     <li class="ManageIFComment">
                                <div class="DefaultAva">
                                    <img src="images/img_Manager/DefaultAva.png" style="width: 39px; height: 39px;" />
                                    <p>
                                        FTSamoyed</p>
                                </div>
                                <div class="IFComment">
                                    <div class="IFCommentTitle">
                                        <label>
                                            举报
                                        </label>
                                        <a class="Title" href="#" title="点击查看" target="_blank">尤塞恩·博尔特</a>
                                        <label>
                                            中的评论：</label>
                                    </div>
                                    <div>
                                        <span class="IFCommentBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                        </span><span class="IFCommentInfo">日期：<label>2011-09-01</label><a href="#" class="scan">通过</a><a
                                            class="scan" href="#">不通过</a></span>
                                    </div>
                                </div>
                            </li>
                            <li class="ManageIFComment">
                                <div class="DefaultAva">
                                    <img src="images/img_Manager/DefaultAva.png" style="width: 39px; height: 39px;" />
                                    <p>
                                        FTSamoyed</p>
                                </div>
                                <div class="IFComment">
                                    <div class="IFCommentTitle">
                                        <label>
                                            举报
                                        </label>
                                        <a class="Title" href="#" title="点击查看" target="_blank">尤塞恩·博尔特</a>
                                        <label>
                                            中的评论：</label>
                                    </div>
                                    <div>
                                        <span class="IFCommentBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                        </span><span class="IFCommentInfo">日期：<label>2011-09-01</label><a href="#" class="scan">通过</a><a
                                            class="scan" href="#">不通过</a></span>
                                    </div>
                                </div>
                            </li>
                            <li class="ManageIFComment">
                                <div class="DefaultAva">
                                    <img src="images/img_Manager/DefaultAva.png" style="width: 39px; height: 39px;" />
                                    <p>
                                        FTSamoyed</p>
                                </div>
                                <div class="IFComment">
                                    <div class="IFCommentTitle">
                                        <label>
                                            举报
                                        </label>
                                        <a class="Title" href="#" title="点击查看" target="_blank">尤塞恩·博尔特</a>
                                        <label>
                                            中的评论：</label>
                                    </div>
                                    <div>
                                        <span class="IFCommentBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                        </span><span class="IFCommentInfo">日期：<label>2011-09-01</label><a href="#" class="scan">通过</a><a
                                            class="scan" href="#">不通过</a></span>
                                    </div>
                                </div>
                            </li>
                            <li class="ManageIFComment">
                                <div class="DefaultAva">
                                    <img src="images/img_Manager/DefaultAva.png" style="width: 39px; height: 39px;" />
                                    <p>
                                        FTSamoyed</p>
                                </div>
                                <div class="IFComment">
                                    <div class="IFCommentTitle">
                                        <label>
                                            举报
                                        </label>
                                        <a class="Title" href="#" title="点击查看" target="_blank">尤塞恩·博尔特</a>
                                        <label>
                                            中的评论：</label>
                                    </div>
                                    <div>
                                        <span class="IFCommentBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                        </span><span class="IFCommentInfo">日期：<label>2011-09-01</label><a href="#" class="scan">通过</a><a
                                            class="scan" href="#">不通过</a></span>
                                    </div>
                                </div>
                            </li>--%>
                        
                        </ItemTemplate>
                         </asp:DataList>
                          <asp:Label ID="pageNav" runat="server"></asp:Label>
                        </ul>
                         
                    </div>
                </div>
            </div>
            <div class="tail" style="margin-top: 36px;">
                <a href="../BrokenPage.aspx" title="#-Sharp!" class="Bottom_Info">团队介绍</a>
                <label class="Bottom_Info" style="color: White; margin-left: 2px; margin-right: 2px;">
                    |</label>
                <a href="../BrokenPage.aspx" title="联系我们" class="Bottom_Info">联系我们</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
