using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;


//TODO 页面上的状态需要更改
public partial class ViewEntry : System.Web.UI.Page
{
    protected static Model.Entry entry = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //如果找不到该词条，则显示相关词条。
            string entryName = Request.QueryString["title"];
            entry = BLL.EntryUtility.SearchEntryByName(entryName);
            if (entry == null)
            {
                Response.Redirect("Result.aspx?keywords=" + entryName);
            }
        }

        //显示词条的相关内容
        if (!IsPostBack)
        {
            string contentIncludeLink = GetContentIncludeLinks(entry.Content);
            //pContent.InnerHtml = entry.Content;
            pContent.InnerHtml = contentIncludeLink;
            hEntryName.InnerText = entry.EntryName;
            pUpSum.InnerText = Convert.ToString(entry.UpSum);
            pDigSum.InnerText = Convert.ToString(entry.DigSum);
            pReleaseTime.InnerText = entry.ReleasedTime.ToLongDateString();
            pUserName.InnerText = BLL.UserUtility.GetUserNameById(entry.UserId);
            aSource.InnerText = entry.Source;
            aSource.HRef = entry.Source;
            lblSecondCatagory.InnerText = BLL.EntryUtility.GetCatagoryNameById(entry.CatagoryId);
            lblFirstCatagory.InnerText = BLL.EntryUtility.GetCatagoryNameById(BLL.EntryUtility.GetUpCatagoryIdById(entry.CatagoryId));
        }

        //获取该词条的所有评论
        List<Model.Comment> commentList = BLL.CommentUtility.GetCommentsByEntryId(entry.EntryId);

        //如果评论为空，则退出。其他的载入语句要写在这句之前。
        if (commentList == null)
        {
            return;
        }
        //将评论分页
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = commentList;
        pds.AllowPaging = true;
        pds.PageSize = 4;

        string pindex = Request.QueryString["pageindex"];
        Regex objNotNumberPattern = new Regex("[^0-9.-]");
        if (string.IsNullOrEmpty(pindex) || objNotNumberPattern.IsMatch(pindex))
            pds.CurrentPageIndex = 0;
        else
            pds.CurrentPageIndex = Convert.ToInt32(pindex);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < pds.PageCount; i++)
        {
            sb.Append(string.Format("<a href='ViewEntry.aspx?title=" + entry.EntryName + "&pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
        }

        pageNav.Text = sb.ToString();

        commentDataList.DataSource = pds;
        commentDataList.DataBind();               
    }
    protected void linkButtonReport_Click(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            RedirectAlert("未登录用户不能举报！", "Login.aspx");
        }
        int commentId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        Model.Prosecution prosecution = new Model.Prosecution();
        prosecution.IsEntry = 0;
        prosecution.ProscuteTime = DateTime.Now;
        prosecution.UserId = BLL.UserUtility.GetUserIdByName(Session["userName"].ToString());
        prosecution.Id = commentId;

        if (BLL.ProsecutionUtility.ProsecuteEntry(prosecution))
        {
            AlertMsg("举报成功！");
        }
        else
        {
            AlertMsg("该条评论已被举报！");
        }                
    }

    protected void linkBtnEditEntry_Click(object sender, EventArgs e)
    {
        if (Session["userName"] == "")
        {
            RedirectAlert("请先登录！", "Login.aspx");
        }
        else
        {
            if (Session["isAdmin"] == "TRUE")
            {
                AlertMsg("管理员不能修改词条！");
            }
            else
            {
                string entryName = Request.QueryString["title"];
                Response.Redirect("Modify_Entry.aspx?title=" + entryName + "&firstCatagory=" +
                                   lblFirstCatagory.InnerText + "&secondCatagory=" + lblSecondCatagory.InnerText +
                                   "&userId=" + entry.UserId);
            }
        }        
    }
    protected void linkBtnProsecute_Click(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            RedirectAlert("未登录用户不能举报词条！", "Login.aspx");
        }
        else
        {
            if (Session["isAdmin"] == "TRUE")
            {
                AlertMsg("管理员不能举报词条");
            }
            else
            {
                Model.Prosecution prosecution = new Model.Prosecution();
                prosecution.IsEntry = 1;
                prosecution.Id = BLL.EntryUtility.GetEntryIdByName(Request.QueryString["title"].ToString().Trim());
                prosecution.ProscuteTime = DateTime.Now;
                prosecution.UserId = BLL.UserUtility.GetUserIdByName(Session["userName"].ToString().Trim());

                if (BLL.ProsecutionUtility.ProsecuteEntry(prosecution))
                {
                    AlertMsg("举报词条成功！");
                }
                else
                {
                    AlertMsg("该词条已被举报过！");
                }

                
            }
        }
    }
    protected void linkBtnDeleteEntry_Click(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == "TRUE" || entry.UserId == BLL.UserUtility.GetUserIdByName(Session["userName"].ToString()))
        {                
                BLL.EntryUtility.DeleteEntryById(entry.EntryId);

                if (Session["isAdmin"] == "TRUE")
                {
                    Response.Redirect("Admin/Manager_Entry.aspx", true);
                }
                else
                {
                    Response.Redirect("PersonalHP_MyEntry.aspx", true);
                }
        }
        else
        {
            AlertMsg("对不起，你没有权限删除该词条。");
        }
    }
    protected void linkBtnComment_Click(object sender, EventArgs e)
    {
        if (txtBoxComment.Text.Trim() != "")
        {
            if (Session["userName"] == "")
            {
                RedirectAlert("请先登录！", "Login.aspx");
            }
            else
            {

                if (Session["isAdmin"] != "TRUE")
                {
                    Model.Comment comment = new Model.Comment();
                    comment.Content = txtBoxComment.Text;
                    comment.Time = DateTime.Now;
                    comment.UserId = BLL.UserUtility.GetUserIdByName(Session["userName"].ToString().Trim());
                    comment.EntryId = entry.EntryId;

                    BLL.CommentUtility.AddComment(comment);
                    RedirectAlert("评论成功！", Request.Url.ToString());
                }
                else
                {
                    AlertMsg("管理员不能评论!");
                }
            }
        }
        else
        {
            AlertMsg("输入评论不能为空！");
        }
    }

    private void AlertMsg(string message)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + message + "');</script>");
    }

    private void RedirectAlert(string message, string distUrl)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + message + "');window.location.href ='" + distUrl + "';</script>");
    }
    protected void linkBtnSearch_Click(object sender, EventArgs e)
    {
        string queryString = txtQueryString.Text.Trim();
        if (queryString == "")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('输入不能为空！')</script>");
        }
        else
        {
            Response.Redirect("~/ViewEntry.aspx?title=" + queryString);
        }
    }
    protected void linkBtnHate_Click(object sender, EventArgs e)
    {
        if (BLL.EntryUtility.DisSupport(entry.EntryId, Session["userName"].ToString()))
        {            
            pDigSum.InnerText = Convert.ToString(Convert.ToInt32(pDigSum.InnerText) + 1);
        }
    }
    protected void linkBtnLike_Click(object sender, EventArgs e)
    {
        if (BLL.EntryUtility.Support(entry.EntryId, Session["userName"].ToString()))
        {
            pUpSum.InnerText = Convert.ToString(Convert.ToInt32(pUpSum.InnerText) + 1);
        }
    }

    protected string GetEntryLink(string entryName)
    {
        string reVal = "<a href=\"ViewEntry.aspx?title="
                     + entryName + "\"Style=\"color:#66cccc ; text-decoration:underline;\">" + entryName + "</a>";
     
        return reVal;
    }

    protected string GetContentIncludeLinks(string content)
    {
        List<string> list = BLL.EntryUtility.GetAllEntriesName();
        foreach (var row in list)
        {
            content = content.Replace(row, GetEntryLink(row));
            
        }
        return content;
    }
}