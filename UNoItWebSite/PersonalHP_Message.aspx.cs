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
using System.Globalization;

public partial class PersonalHP_Message : System.Web.UI.Page
{
    public class Message
    {
        private string contents;

        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }
        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private int notifyId;

        public int NotifyId
        {
            get { return notifyId; }
            set { notifyId = value; }
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
        
        string userName = Session["userName"].ToString();

        if (userName != null)
        {
            hpLkLogin.Text = userName;
            hpLkLogin.NavigateUrl = "PersonalHP_MyEntry.aspx";
            lkBtnSign.Visible = false;
        }

        lblUserName.Text = userName;
      //  lblUserNameShow.Text = userName;
        Model.PersonalInformation person = PersonalInformationUtility.GetPersonalInfoByUserName(userName);

        position = person.Position;
       
        
        birthday = person.Birthdate.ToShortDateString();
        city = person.City;
        skilledField = person.SkilledField;
        scores = UserUtility.GetScoresByUserName(userName);

        Page.DataBind();
        
        List<Message> messageList = new List<Message>();

        int userId = UserUtility.GetUserIdByName(userName);

        List<Model.Notify> notifyList = new List<Model.Notify>();

        notifyList = NotifyUtility.GetNotifyByUserId(userId);

        if (notifyList.Count == 0)
        {
             return;
        }

        else 
        {
               foreach (var item in notifyList)
                {
                    Message message = new Message();
                    message.Contents = item.Content;
                    message.Time = item.Time;
                    message.NotifyId = item.NotifyId;

                    messageList.Add(message);
                }


                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = messageList;
                pds.AllowPaging = true;
                pds.PageSize = 3;

                string pindex = Request.QueryString["pageindex"];
                Regex objNotNumberPattern = new Regex("[^0-9.-]");
                if (string.IsNullOrEmpty(pindex) || objNotNumberPattern.IsMatch(pindex))
                    pds.CurrentPageIndex = 0;
                else
                    pds.CurrentPageIndex = Convert.ToInt32(pindex);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < pds.PageCount; i++)
                {
                    sb.Append(string.Format("<a href='PersonalHP_Message.aspx?pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
                }

                pageNav.Text = sb.ToString();

                dtList.DataSource = pds;
                dtList.DataBind();
            }
    }

    protected void lkBtnDelete_Click(object sender, EventArgs e)
    {
        int notifuId = Convert.ToInt32((sender as LinkButton).CommandArgument);

        if (notifuId != -1)
        {
            NotifyUtility.DeleteNotify(notifuId);
            Response.Redirect("PersonalHP_Message.aspx");
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
    protected void lkBtnSign_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}