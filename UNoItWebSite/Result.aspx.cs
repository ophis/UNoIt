using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

public partial class Result : System.Web.UI.Page
{
    //要更新 我来发布 主页 分类目录的链接 以及第一行的状态。
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Model.Entry> entryList = BLL.EntryUtility.SearchEntriesByKeywords(Request.QueryString["keywords"]);
        hyperLinkWiki.NavigateUrl = "http://zh.wikipedia.org/wiki/" + Request.QueryString["keywords"].ToString();

        //如果搜索结果不为空，将搜索结果分页。
        if (entryList.Count != 0)
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = entryList;
            pds.AllowPaging = true;
            pds.PageSize = 10;

            string pindex = Request.QueryString["pageindex"];
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            if (string.IsNullOrEmpty(pindex) || objNotNumberPattern.IsMatch(pindex))
                pds.CurrentPageIndex = 0;
            else
                pds.CurrentPageIndex = Convert.ToInt32(pindex);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pds.PageCount; i++)
            {
                sb.Append(string.Format("<a href='Result.aspx?pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
            }
            pageNav.Text = sb.ToString();
            pageNav.Style.Value = "visibility:visible";

            entryDataList.DataSource = pds;
            entryDataList.DataBind();
        }
        else
        {
            pageNav.Style.Value = "visibility:hidden";
        }
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
    protected void linkBtnRelease_Click(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            RedirectAlert("未登录用户不能发布词条！", "Login.aspx");
        }
        else
        {
            if (Session["isAdmin"] == "TRUE")
            {
                AlertMsg("管理员不能发布词条");
            }
            else
            {
                Response.Redirect("Publish_Entry.aspx");
            }
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
}