using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

public partial class Catalog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            hpLkLogin.Text = Session["userName"].ToString();
            hpLkLogin.NavigateUrl = "PersonalHP_MyEntry.aspx";
            lkBtnSign.Text = "注销";
        }

        string catagoryName = null;
        if (Request.QueryString["catagory"] == null)
        {
            catagoryName = "生物";
        }
        else
        {
            catagoryName = Request.QueryString["catagory"].ToString();
        }
        Model.Catagory catagory = new Model.Catagory();
        catagory.CatagoryName = catagoryName;
        List<string> entries = BLL.EntryUtility.SearchEntriesByCatagoryId(BLL.EntryUtility.GetCatagoryIdByName(catagory));

        List<EntryInfo> entryInfoList = new List<EntryInfo>();
        foreach (var row in entries)
        {
            EntryInfo entryInfo = new EntryInfo();
            Model.Entry entry = BLL.EntryUtility.SearchEntryByName(row);
            entryInfo.EntryName = entry.EntryName;
            entryInfo.Publisher = BLL.UserUtility.GetUserNameById(entry.UserId);
            entryInfo.ReleaseTime = entry.ReleasedTime.ToShortDateString();
            entryInfoList.Add(entryInfo);
        }

        //将结果分页
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = entryInfoList;
        pds.AllowPaging = true;
        pds.PageSize = 8;

        string pindex = Request.QueryString["pageindex"];
        Regex objNotNumberPattern = new Regex("[^0-9.-]");
        if (string.IsNullOrEmpty(pindex) || objNotNumberPattern.IsMatch(pindex))
            pds.CurrentPageIndex = 0;
        else
            pds.CurrentPageIndex = Convert.ToInt32(pindex);

        StringBuilder sb = new StringBuilder();
        int i = 0;
        for (i = 0; i < pds.PageCount; i++)
        {
            sb.Append(string.Format("<a href='Catalog.aspx?catagory=" + catagoryName + "&pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
        }

        if (i == 0)
        {
            pageNav.Visible = false;
        }
        else
        {
            pageNav.Visible = true;
        }
        pageNav.Text = sb.ToString();

        entryDataList.DataSource = pds;
        entryDataList.DataBind();        
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
    protected void lkBtnSign_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}


public class EntryInfo
{
    private string entryName;

    public string EntryName
    {
        get { return entryName; }
        set { entryName = value; }
    }
    private string releaseTime;

    public string ReleaseTime
    {
        get { return releaseTime; }
        set { releaseTime = value; }
    }
    private string publisher;

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }
}