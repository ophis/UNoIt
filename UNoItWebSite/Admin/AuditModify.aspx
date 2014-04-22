<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditModify.aspx.cs" Inherits="Admin_AuditModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-
transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>U No.IT -- 百科，你懂的。</title>
    <link href="../css/AuditModify.css" rel="stylesheet" type="text/css" />
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
            <asp:Label ID="lblSayHi" runat="server" CssClass="Set12px" style="margin-left: 500px;">Hi,你好！
</asp:Label>
           <%-- <label class="Set12px" style="color: #cc0066; font-weight: 500;">
                FTSamoyed</label>--%>
                <%--Text=<%#Eval("adminName") %>--%>
           <asp:HyperLink ID="hpLkAdmin" runat="server" Text = "<%#adminName %>" CssClass="Set12px" style="color: #cc0066; font-weight: 500;"></asp:HyperLink>
            
            
           <%-- <a class="Set12px" title="注销" href="Login.aspx">注销</a>--%>
            <asp:LinkButton ID="lkBtnLogOff" runat="server" CssClass = "Set12px" 
                onclick="lkBtnLogOff_Click">注销</asp:LinkButton>

        </div>
        <div class="MainDiv">
            <div class="nav">
                <a href="Manager_Entry.aspx" title="词条审核"></a>
                <a href="Manager_IFComment.aspx" title="举报评论"></a>
                <a href="Manager_IFEntry.aspx" title="举报词条"></a>
                <a href="Manager_ResetKey.aspx" title="修改密码"></a>  
            </div>
            <div class="MainBody">
                <div class="MainTitle">

                    <asp:Label ID="lblEntryName" Text = "<%#entryName%>" runat="server" style="clear: both; 
text-align: right; position: relative; left: -20px; top: -22px;
                        font-size: 24px; color: #99cc66"></asp:Label>

                    <p style="font-size: 12px; color: #cccccc; float: left; margin-top: -60px; margin-left: 
15px;">
                        所属分类：
                        <%--<label>父目录</label>--%>
                        <asp:Label ID="lblUpCategory" runat="server" ></asp:Label>       
                        >>
                        
                        <%--<label>子目录</label></p>--%>
                        <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="B_EntryDiv">
                    <div class="EntryBody">
                        <p class="SmallTitle">
                            原词条内容：</p>

                        <asp:Label ID="lblOldContents" runat="server" Text="<%#oldContents%>" style="clear: both; text-align: right; position: relative; left: -20px; top: -22px;
                        font-size: 24px; color: #99cc66"></asp:Label>
  
                    </div>
                </div>
                <div class="A_EntryDiv">
                    <div class="EntryBody">
                        <p class="SmallTitle">
                            修改后内容：</p>
                  
                    
<asp:Label ID="lblNewContents" runat="server" Text="<%#newContents%>" style="clear: both; text-align: right; position: relative; left: -20px; top: -22px;
                        font-size: 24px; color: #99cc66"></asp:Label>
                    </div>
                </div>
                <div style="clear:both;"></div>
                <div class="Check">
                    <%--<a class="Reject" href="#" title="驳回"></a>--%>
                    <asp:LinkButton ID="lkBtnReject" runat="server" CssClass="Reject" 
                        onclick="lkBtnReject_Click" ></asp:LinkButton>
                   
                  <%-- <a class="Pass" href="#" title="通过"></a>--%>
                    <asp:LinkButton ID="lkBtnPass" runat="server" CssClass = "Pass" 
                        onclick="lkBtnPass_Click" ></asp:LinkButton>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
    </div>
    <div class="tail">
        <a href="../BrokenPage.aspx" title="#-Sharp!" class="Bottom_Info">团队介绍</a>
        <label class="Bottom_Info" style="color: White; margin-left: 2px; margin-right: 2px;">
            |</label>
        <a href="../BrokenPage.aspx" title="联系我们" class="Bottom_Info">联系我们</a>
    </div>
    </form>
</body>
</html>
