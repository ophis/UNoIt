<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalog.aspx.cs" Inherits="Catalog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>U No.IT -- 百科，你懂的。</title>
    <link href="CSS/Catalog.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.6.2.js"></script>
    <script src="js/kandytabs.pack.js" type="text/javascript"></script>
    <link href="css/kandytabs.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("dl").KandyTabs({
                trigger: "click",
                action: "slide"
            });
        })
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
           <%-- <label class="Set12px" style="margin-left: 500px;">
                Hi,你好！</label>
            <a class="Set12px" title="登录" href="Login.aspx">登录</a> 
            <a class="Set12px" title="注册" href="SignUp.aspx">注册</a> 
            <a class="Set12px" title="联系我们" href="BrokenPage.aspx">联系我们</a>--%>
       
       <asp:Label ID="lblHi" runat="server" Text="Hi,你好！" CssClass="Set12px" style="margin-left: 500px;"></asp:Label>

            <%--<a class="Set12px" title="登录" href="Login.aspx">登录</a> --%>  
            <asp:HyperLink ID="hpLkLogin" runat="server" CssClass = "Set12px">登录</asp:HyperLink>              
           <%-- <a class="Set12px" title="注册" href="Index.aspx">注册</a> --%>

            <%--<asp:LinkButton ID="lkBtnSign" runat="server" CssClass = "Set12px" 
                onclick="lkBtnSign_Click">注册</asp:LinkButton>--%>

                  <asp:LinkButton ID="lkBtnSign" runat="server" CssClass = "Set12px" 
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
                    style="font-weight: bold; margin-left: 27px;" 
                    onclick="linkBtnSearch_Click">求科普</asp:LinkButton>
                  </span>
            </div>
            <div class="nav">
                <a href="Index.aspx" title="主页"></a>
                <a href="Catalog.aspx" title="分类目录"></a>
            </div>
            <div class="MainBody">
                <div class="Catalog">
                    <dl>
                        <dt>自然</dt>
                        <dd>
                            <a class="ChildCata" href="Catalog.aspx?catagory=生物">生物</a> 
                            <a class="ChildCata" href="Catalog.aspx?catagory=天文">天文</a>
                            <a class="ChildCata" href="Catalog.aspx?catagory=地理">地理</a>
                            <a class="ChildCata" href="Catalog.aspx?catagory=自然现象">自然现象</a>
                        </dd>
                        <dt>科技</dt>
                        <dd>
                            <a class="ChildCata" href="Catalog.aspx?catagory=数理化">数理化</a>
                            <a class="ChildCata" href="Catalog.aspx?catagory=医药学">医药学</a>
                            <a class="ChildCata" href="Catalog.aspx?catagory=生物学">生物学</a>
                            <a class="ChildCata" href="Catalog.aspx?catagory=应用科学">应用科学</a>
                        </dd>
                        <dt>文化</dt>
                        <dd>
                            <a class="ChildCata" href="Catalog.aspx?catagory=文学">文学</a> 
                            <a class="ChildCata" href="Catalog.aspx?catagory=艺术">艺术</a> 
                            <a class="ChildCata" href="Catalog.aspx?catagory=民俗">民俗</a>
                            <a class="ChildCata" href="Catalog.aspx?catagory=宗教">宗教</a>
                        </dd>
                        <dt>生活</dt>
                        <dd>
                            <a class="ChildCata" href="Catalog.aspx?catagory=衣">衣</a> 
                            <a class="ChildCata" href="Catalog.aspx?catagory=食">食</a> 
                            <a class="ChildCata" href="Catalog.aspx?catagory=住">住</a>
                            <a class="ChildCata" href="Catalog.aspx?catagory=行">行</a>
                        </dd>
                        <dt>社会</dt>
                        <dd>
                            <a class="ChildCata" href="Catalog.aspx?catagory=军事">军事</a> 
                            <a class="ChildCata" href="Catalog.aspx?catagory=政法">政法</a> 
                            <a class="ChildCata" href="Catalog.aspx?catagory=时事">时事</a>
                            <a class="ChildCata" href="Catalog.aspx?catagory=机构">机构</a>
                        </dd>
                    </dl>
                </div>
                <div style="height: 30px; clear: both;">
                </div>
                <div class="EntryView">
                    <div class="HotImg">
                    </div>
                    <ul class="EntryListBody">
                        <li class="EntryList" >
                            <div class="CommentTitle">
                                <label class="leftTitle" style="color: #99cc67;">
                                    词条名称</label>
                                <label class="rightTitle" style="color: #99cc67;">
                                    发布时间</label>
                                <label class="centerTitle" style="color: #99cc67;">
                                    发布者</label>
                            </div>
                        </li>
                        <asp:DataList ID="entryDataList" runat="server">
                        <ItemTemplate>
                        <li class="EntryList">
                            <div>                                
                                <%--<a class="left" href="#" title="点击查看">刘翔</a>--%>
                                <asp:HyperLink ID="entryLink" runat="server" CssClass="left" NavigateUrl='<%#@"ViewEntry.aspx?title="+Eval("EntryName")%>'><%#Eval("EntryName")%></asp:HyperLink>
                                <label class="center">
                                <%#Eval("Publisher") %></label>
                                <label class="right">
                                    <%#Eval("ReleaseTime")%></label>
                            </div>
                        </li>
                        </ItemTemplate>
                        </asp:DataList>   
                         <asp:Label ID="pageNav" CssClass=" PageNav" runat="server"></asp:Label>  
                    </ul>
              
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
