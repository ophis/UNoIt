using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;
using System.Text.RegularExpressions;
using System.Text;

public partial class PersonalHP_MyComment : System.Web.UI.Page
{
    public class MyComment
    {
        private int entryId;

        public int EntryId
        {
            get { return entryId; }
            set { entryId = value; }
        }
        private DateTime commentTime;

        public DateTime CommentTime
        {
            get { return commentTime; }
            set { commentTime = value; }
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

        List<Model.Comment> commentList = BLL.CommentUtility.GetCommentByUserId(userId);
        List<MyComment> myCommentList = new List<MyComment>();

        if (commentList == null)
        {
            return;
        }
        else 
        {
            for (int i = 0; i < commentList.Count(); i++)
            {
                MyComment comment = new MyComment();
                comment.EntryId = commentList[i].EntryId;
                comment.CommentTime = commentList[i].Time;

                myCommentList.Add(comment);
            }

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = myCommentList;
            pds.AllowPaging = true;
            pds.PageSize = 8;

            string pindex = Request.QueryString["pageindex"];
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            if (string.IsNullOrEmpty(pindex) || objNotNumberPattern.IsMatch(pindex))
                pds.CurrentPageIndex = 0;
            else
                pds.CurrentPageIndex = Convert.ToInt32(pindex);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pds.PageCount; i++)
            {
                sb.Append(string.Format("<a href='PersonalHP_MyComment.aspx?pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
            }

            pageNav.Text = sb.ToString();

            dataListMyComment.DataSource = pds;
            dataListMyComment.DataBind();
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
    protected void lkBtnSign_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}