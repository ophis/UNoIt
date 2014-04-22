using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using DAL;
using System.Text.RegularExpressions;
using System.Text;

public partial class PersonalHP_MyEntry : System.Web.UI.Page
{
    public class MyEntry
    {
        private string entryName;

        public string EntryName
        {
            get { return entryName; }
            set { entryName = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private int upSum;

        public int UpSum
        {
            get { return upSum; }
            set { upSum = value; }
        }
        private int digSum;

        public int DigSum
        {
            get { return digSum; }
            set { digSum = value; }
        }
        private DateTime releasedTime;

        public DateTime ReleasedTime
        {
            get { return releasedTime; }
            set { releasedTime = value; }
        }
    }

    public string userName = "";
    public string position = "";
    public string birthday = "";
    public string city = "";
    public string skilledField = "";
    public int scores = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        ////TODO:前台的链接要添加
        userName = Session["userName"].ToString();

        if (userName != null)
        {
            hpLkLogin.Text = userName;
            hpLkLogin.NavigateUrl = "PersonalHP_MyEntry.aspx";

            lkBtnSign.Text = "注销";
        }

        int userId = UserUtility.GetUserIdByName(userName);
        lblUserName.Text = userName;
        Model.PersonalInformation person = PersonalInformationUtility.GetPersonalInfoByUserName(userName);
        position = person.Position;
        birthday = person.Birthdate.ToShortDateString();
        city = person.City;
        skilledField = person.SkilledField;
        scores = UserUtility.GetScoresByUserName(userName);


        Page.DataBind();

        List<Model.Entry> entryList = BLL.EntryUtility.GetAllEntriesByUserID(BLL.UserUtility.GetUserIdByName(userName));

//Session["userName"].ToString().Trim()

        List<MyEntry> myEntryList = new List<MyEntry>();

        if (entryList == null)
        {
            return;
        }
        else if (entryList.Count > 0)
        {
            for (int i = 0; i < entryList.Count(); i++)
            {
                MyEntry entry = new MyEntry();
                entry.Content = entryList[i].Content;
                entry.DigSum = entryList[i].DigSum;
                entry.EntryName = entryList[i].EntryName;
                entry.UpSum = entryList[i].UpSum;
                entry.ReleasedTime = entryList[i].ReleasedTime;

                myEntryList.Add(entry);
            }

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = myEntryList;
            pds.AllowPaging = true;
            pds.PageSize = 5;

            string pindex = Request.QueryString["pageindex"];
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            if (string.IsNullOrEmpty(pindex) || objNotNumberPattern.IsMatch(pindex))
                pds.CurrentPageIndex = 0;
            else
                pds.CurrentPageIndex = Convert.ToInt32(pindex);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pds.PageCount; i++)
            {
                sb.Append(string.Format("<a href='PersonalHP_MyEntry.aspx?pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
            }

            pageNav.Text = sb.ToString();

            dataListMyEntry.DataSource = pds;
            dataListMyEntry.DataBind();
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
            Response.Redirect("#?title=" + queryString);
        }
    }
    protected void linkBtnSearch_Click1(object sender, EventArgs e)
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
    protected void linkBtnSearch_Click2(object sender, EventArgs e)
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