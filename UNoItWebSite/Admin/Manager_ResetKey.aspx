<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager_ResetKey.aspx.cs" Inherits="Manager_ResetKey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>U No.IT -- 超级管理员！</title>
    <link href="../CSS/Manager_ResetKey.css" rel="stylesheet" type="text/css" />
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
                <asp:Label ID="lblSayHi" runat="server" Style="margin-left: 500px;" CssClass="Set12px">Hi,你好！</asp:Label>

            <%--<label class="Set12px" style="color: #cc0066; font-weight: 500;">
                FTSamoyed</label>--%>
           <%-- <asp:Label ID="lblAdmin" runat="server"  CssClass="Set12px" style="color: #cc0066; font-weight: 500;" Text = "<%#adminName%>"></asp:Label>
--%>
            <asp:HyperLink ID="hpLkAdmin" runat="server" CssClass="Set12px" style="color: #cc0066; font-weight: 500;" Text = "<%#adminName%>"></asp:HyperLink>
           <%-- <a class="Set12px" title="注销" href="#">注销</a>--%>
            <%--<asp:HyperLink ID="hpLkLogOff" runat="server" CssClass="Set12px" ToolTip = "注销" NavigateUrl = "####">注销</asp:HyperLink>
        --%>
            <asp:LinkButton ID="lkBtnLogOff" runat="server" CssClass="Set12px" 
                ToolTip = "注销" onclick="lkBtnLogOff_Click">注销</asp:LinkButton>   
        
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
                <div class="ManageResetKeyView">
                    <p style="float: right; font-size: 18px; font-weight: bold; margin-right: 40px; 
                        color: #3e3e3e;">
                        修改密码</p>
                    <div class="ManageResetKeyBody">
                        <p style="margin-top: 70px;">
                            原始密码：
                        </p>
                       <%-- <input class="InputText" type="text" />--%>
                        <asp:TextBox ID="txtOldPass" runat="server" CssClass="InputText"></asp:TextBox>
                        <p>
                            新密码：
                        </p>
                        <%--<input class="InputText" type="text" />--%>
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
                                <%--<a href="#"></a>--%>
                               <%-- <asp:HyperLink ID="hpLkReset" runat="server" NavigateUrl ="######"></asp:HyperLink>--%>
                                <asp:LinkButton ID="lkBtnReset" runat="server" onclick="lkBtnReset_Click"></asp:LinkButton>
                            </div>
                            <div class="CancelBtn">
                                <%--<a href="#"></a>--%>
                               <%-- <asp:HyperLink ID="hpLkCancel" runat="server" NavigateUrl ="########"></asp:HyperLink>--%>
                                <asp:LinkButton ID="lkBtnCancel" runat="server" onclick="lkBtnCancel_Click1"></asp:LinkButton>
                            </div>
                        
                    </div>
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
