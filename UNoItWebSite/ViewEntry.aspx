<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEntry.aspx.cs" Inherits="ViewEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>U No.IT -- 百科，你懂的。</title>
    <link href="css/ViewEntry.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="viewEntryForm" runat="server">
        <div class="Window">
        <div class="PersonNav">
            <span class="logo">
                <img src="images/logo.png" title="U No.IT.com" style="height: 62px; width: 144px;
                    margin-left: 30px" />
            </span>
            <label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>
            <a class="Set12px" title="登录" href="Login.aspx">登录</a> <a class="Set12px" title="注册"
                href="SignUp.aspx">注册</a> <a class="Set12px" title="联系我们" href="BrokenPage.aspx">联系我们</a>
        </div>
        <div class="MainDiv">
            <div class="search">
                <%--<span>
                    <input type="text" class="Text_Search" />
                    <a href="#" style="font-weight: bold; margin-left: 27px;">求科普</a> </span>--%>
                <span>                      
                    <asp:TextBox ID="txtQueryString" runat="server" CssClass="Text_Search"></asp:TextBox>
                    <asp:LinkButton ID="linkBtnSearch" runat="server" 
                         style="font-weight: bold; margin-left: 27px;" 
                    onclick="linkBtnSearch_Click">求科普</asp:LinkButton>
                </span> 
            </div>
            <div class="nav">
                <a href="Index.aspx" title="主页"></a>
                <a href="Catalog.aspx" title="分类目录"></a>
            </div>
            <div class="MainBody">
                <div class="EntryDiv">
                    <h4 id="hEntryName" runat="server" style="clear: both; text-align: right; position: relative; left: -20px; top: -22px;
                        font-size: 24px; color: #99cc66"></h4>
                    <p style="font-size:12px; color:#cccccc; float:left; margin-top:-60px; margin-left:15px;">所属分类：<label id="lblFirstCatagory" runat="server"></label>>><label id="lblSecondCatagory" runat="server"></label></p>
                    <div class="EntryBody" style="text-align:left">
                        <p class="SmallTitle">
                            词条内容：</p>
                        <p class="Details"></p>
                        <p id = "pContent" runat ="server"><%--class="SmallTitle"--%>
                            参考链接：</p>
                        <a id="aSource" runat="server" class="Details" href="" target="_blank"></a>
                    </div>
                    <div class="Comments">
                        <p class="SmallTitle">
                            近期评论：</p>
                        <ul class="CommentBody">
                            <li style="margin-top: 18px;">
                                <asp:DataList ID="commentDataList" runat="server">
                                <ItemTemplate>
                                <div class="Comment">
                                    <div class="UserAva">
                                        <img src="images/img_Entry/DefaultAva.gif" style="height: 40px; width: 40px;" />
                                        <%--<asp:Image ID="imageSender" runat="server" style="height: 40px; width: 40px;"/>--%>
                                    </div>
                                    <span class="ComText"><%#BLL.UserUtility.GetUserNameById((int)Eval("UserId"))%></span> <span class="ComText" style="color: #cccccc;">
                                        (<label><%#Eval("Time")%></label>)</span>
                                    <div class="ComDetail">
                                        <label><%#Eval("Content") %></label></div>
                                    
                                    <%--<a href="#" class="inform">举报</a>--%>
                                    <asp:LinkButton ID="linkButtonReport" CommandArgument='<%#Eval("CommentId") %>'
                                         CssClass="inform" runat="server" onclick="linkButtonReport_Click">举报</asp:LinkButton>    
                                </div>
                                </ItemTemplate>
                                </asp:DataList>
                                <asp:Label ID="pageNav" CssClass=" PageNav" runat="server"></asp:Label>                          
                            </li>
                            </li>
                        </ul>
                        <%--<textarea class="CommentArea"></textarea>--%>
                        <asp:TextBox ID="txtBoxComment" runat="server" CssClass="CommentArea" 
                            TextMode="MultiLine"></asp:TextBox>
                        <%--<a href="#" title="评论" class="CommentButton"></a>--%>
                        <asp:LinkButton ID="linkBtnComment" runat="server" CssClass="CommentButton" onclick="linkBtnComment_Click" 
                            ></asp:LinkButton>
                    </div>
                </div>
                <div class="EntryInfoDiv">
                    <p style="font-size: 14px; text-align: left; margin-left: 10px; margin-top: 40px;                        
                        color: #3e3e3e;">
                        发布人：</p>
                    <div class="UserAva0">
                        <img src="images/img_Entry/DefaultAva.gif" style="height: 82px; width: 82px;" />
                       <%-- <asp:Image ID="Image1" runat="server" style="height: 82px; width: 82px;"
                        ImageUrl='<%#Eval("BLL.UserUtility.GetUserPhotoUrlById(entry.UserId)")%>'/>--%>
                    </div>
                    <p id="pUserName" runat="server" style="font-size: 14px; color: #99cc66; font-weight: 800;">
                        </p>
                    <p id="pReleaseTime" runat="server" style="font-size: 14px; color: #99cc66; font-weight: 500;">
                        </p>
                    <div class="Operation">

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                         <%--<a href="######" title="踩" class="Hate"></a>
                        <a href="######" title="赞" class="Like"></a>--%>

                        <asp:LinkButton ID="linkBtnHate" runat="server" onclick="linkBtnHate_Click" CssClass="Hate"></asp:LinkButton>
                        <asp:LinkButton ID="linkBtnLike" runat="server" onclick="linkBtnLike_Click" CssClass="Like"></asp:LinkButton>

                        <p class="TipText">
                            赞词条</p>
                        <p class="TipText">
                            踩词条</p>
                        <p id="pUpSum" runat="server" class="Count">
                            </p>
                        <p id="pDigSum" runat="server" class="Count">
                            </p>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        

                       
                        <div class="EntryOp">
<%--                            <a href="Modify_Entry.htm" title="修改词条" class="EditButton"></a>
                            <a href="######" title="举报词条"class="InformButton"></a>
                            <a href="######" title="删除词条" class="DeleteButton"></a>--%>
                            <asp:LinkButton ID="linkBtnEditEntry" runat="server" CssClass="EditButton" onclick="linkBtnEditEntry_Click" 
                                ></asp:LinkButton>
                            <asp:LinkButton ID="linkBtnProsecute" runat="server" CssClass="InformButton" onclick="linkBtnProsecute_Click" 
                                ></asp:LinkButton>
                            <asp:LinkButton ID="linkBtnDeleteEntry" runat="server" CssClass="DeleteButton" onclick="linkBtnDeleteEntry_Click"  onClientclick="return confirm('确实删除吗？')" 
                                ></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
    </div>
    <div class="tail">
        <a href="BrokenPage.aspx" title="#-Sharp!" class="Bottom_Info">团队介绍</a>
        <label class="Bottom_Info" style="color: White; margin-left: 2px; margin-right: 2px;">
            |</label>
        <a href="BrokenPage.aspx" title="联系我们" class="Bottom_Info">联系我们</a>
    </div>
    </form>
</body>
</html>
