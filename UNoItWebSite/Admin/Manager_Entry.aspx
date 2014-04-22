<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager_Entry.aspx.cs" Inherits="Admin_Manager_Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>U No.IT -- 超级管理员！</title>
    <link href="../CSS/Manager_Entry.css" rel="stylesheet" type="text/css" />
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
                 <asp:Label ID="lblSayHi" runat="server" Text="Label" CssClass="Set12px" style="margin-left: 500px;"> Hi,你好！</asp:Label>
            <%-- <label class="Set12px" style="color: #cc0066; font-weight: 500;">
                FTSamoyed</label>--%>
               <%-- <asp:Label ID="lblAdmin" runat="server"  CssClass="Set12px" style="color: #cc0066; font-weight: 500;" Text = <%#"adminName"%>></asp:Label>
--%>
 <asp:HyperLink ID="hpLkAdmin" runat="server" Text = "<%#adminName %>" CssClass="Set12px" style="color: #cc0066; font-weight: 500;"></asp:HyperLink>
            
          <%--  <a class="Set12px" title="注销" href="#">注销</a>--%>
            <asp:LinkButton ID="lkBtnLogOff" runat="server" CssClass = "Set12px" 
                onclick="lkBtnLogOff_Click">注销</asp:LinkButton>
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
                <div class="ManageEntryView">
                    <p style="float: right; font-size: 18px; font-weight: bold; margin-right: 40px; 
                        color: #3e3e3e;">
                        词条审核</p>
                    <div style="clear:both;">
                    <ul class="ManageEntryBody">

                        <asp:DataList ID="dtList" runat="server">        
                        <ItemTemplate>
                        
                            <li class="ManageEntry" >
                                <div class="EntryTitle">
                                    <asp:Label ID="lblEntryName" runat="server" CssClass = "Title" runat="server" Text = <%#Eval("entryName") %>></asp:Label>
                                 <%--  <asp:HyperLink ID="hpLkTitle" CssClass = "Title" runat="server" ToolTip="点击查看" target="_blank" NavigateUrl=<%#@"../ViewEntry.aspx?title="+Eval("entryName")%> Text = <%#Eval("entryName") %> ></asp:HyperLink>
                                 --%>   
                                </div>
                                <div>
                                  <%--  <asp:Label ID="lblReleaser" runat="server" >发布内容：</asp:Label>
                                    --%>
                                    <asp:Label ID="lblEntryContents" runat="server" Text=<%#Eval("entryContents") %> CssClass="EntryBody"></asp:Label>
                                    
                                    <span class="EntryInfo">
                                    发布人
                                   
                                    <%--<label>FTSamoyed</label>--%>
                                        <asp:Label ID="lblUserName" runat="server" Text=<%#Eval("userName") %> ></asp:Label>
                                        发布时间
                                   <%-- <label>2011-09-01</label>--%>
                                        <asp:Label ID="lblReleaseTime" runat="server" Text=<%#Eval("releaseTime")%>></asp:Label>
                                    <%--<a class="scan" href="AuditPublish.aspx">查看</a>--%>
                                  
                                    <asp:LinkButton ID="lkBtnLook" runat="server" CssClass = "Title" runat="server" 
                                        ToolTip="点击查看" target="_blank" onclick="lkBtnLook_Click" CommandArgument = <%#Eval("entryName") %>>查看</asp:LinkButton>
                                    </span>
                                </div>
                            </li>
                           <%-- <li class="ManageEntry">
                                <div class="EntryTitle">
                                    <a class="Title" href="AuditModify.htm" title="点击查看" target="_blank">蓬莱19-3油田溢油事故</a>
                                </div>
                                <div>
                                    <span class="EntryBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                    </span><span class="EntryInfo">发布人：(<label>FTSamoyed</label>) 发布时间：<label>2011-09-01</label><a href="AuditModify.htm" class="scan">查看</a></span>
                                </div>
                            </li>
                            <li class="ManageEntry">
                                <div class="EntryTitle">
                                    <a class="Title" href="#" title="点击查看" target="_blank">尤塞恩·博尔特</a>
                                </div>
                                <div>
                                    <span class="EntryBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                    </span><span class="EntryInfo">发布人：(<label>FTSamoyed</label>) 发布时间：<label>2011-09-01</label><a href="#" class="scan">查看</a></span>
                                    
                                </div>
                            </li>
                            <li class="ManageEntry">
                                <div class="EntryTitle">
                                    <a class="Title" href="#" title="点击查看" target="_blank">尤塞恩·博尔特</a>
                                </div>
                                <div>
                                    <span class="EntryBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                    </span><span class="EntryInfo">发布人：(<label>FTSamoyed</label>) 发布时间：<label>2011-09-01</label><a href="#" class="scan">查看</a></span>
                                </div>
                            </li>
                            <li class="ManageEntry">
                                <div class="EntryTitle">
                                    <a class="Title" href="#" title="点击查看" target="_blank">尤塞恩·博尔特</a>
                                </div>
                                <div>
                                    <span class="EntryBody">2009年博尔特以提高相同的成绩0.11秒打破柏林世锦赛100米、200米世界纪录，成为史上第一人山人海海上明珠珠联璧合
                                    </span><span class="EntryInfo">发布人：(<label>FTSamoyed</label>) 发布时间：<label>2011-09-01</label><a href="#" class="scan">查看</a></span>
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
