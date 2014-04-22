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

public partial class Admin_Manager_IFComment : System.Web.UI.Page
{
    public class ProComment
    {
        private int commentID;

        public int CommentID
        {
            get { return commentID; }
            set { commentID = value; }
        }

        private string proUser;

        public string ProUser
        {
            get { return proUser; }
            set { proUser = value; }
        }
        private string entryName;

        public string EntryName
        {
            get { return entryName; }
            set { entryName = value; }
        }
        private string commentContents;

        public string CommentContents
        {
            get { return commentContents; }
            set { commentContents = value; }
        }

        private DateTime proTime;

        public DateTime ProTime
        {
            get { return proTime; }
            set { proTime = value; }
        }
    }

    public string adminName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //EntryUtility.DeleteEntryByEntryName("弗洛伊德");
        adminName = Session["adminName"].ToString();

        if (adminName != null)
        {
             hpLkLogin.Text = adminName;
             hpLkLogin.NavigateUrl = "Manager_Entry.aspx";

             lkBtnSign.Text = "注销";
        }

        //返回所有举报的评论
        List<Model.Prosecution> prosecutionList = ProsecutionUtility.GetAllProsecutionComment();

        if (prosecutionList != null)
        {
            List<int> commentIDList = new List<int>();

            foreach (var query in prosecutionList)
            {
                commentIDList.Add(query.Id);
            }

            List<string> userNameList = new List<string>();

            foreach (var query in prosecutionList)
            {
                userNameList.Add(UserUtility.GetUserNameById(query.UserId));
            }

            List<string> contentsList = new List<string>();

            foreach (var query in prosecutionList)
            {
                Model.Comment comment = CommentUtility.GetCommentsByCommentId(query.Id);

                contentsList.Add(comment.Content);
            }

            List<string> entryNameList = new List<string>();

            foreach (var query in prosecutionList)
            {
                int entryID = CommentUtility.GetEntryIdByCommentsID(query.Id);

                entryNameList.Add(EntryUtility.GetEntryNameById(entryID));
            }

            List<ProComment> proCommentList = new List<ProComment>();

            for (int i = 0; i < prosecutionList.Count(); i++)
            {
                ProComment entry = new ProComment();

                entry.EntryName = entryNameList[i];
                entry.CommentContents = contentsList[i];
                entry.ProUser = userNameList[i];
                entry.CommentID = commentIDList[i];
                entry.ProTime = prosecutionList[i].ProscuteTime;

                proCommentList.Add(entry);
            }

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = proCommentList;
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
                sb.Append(string.Format("<a href='Manager_IFComment.aspx?pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
            }

            pageNav.Text = sb.ToString();

            dtList.DataSource = pds;
            dtList.DataBind();
        }
        //else
        //{
        //    Response.Write("<script>alert('无举报词条！');</script>");
        //}
    }

    protected void lkBtnCancel_Click(object sender, EventArgs e)
    {
        int commentID = Convert.ToInt32((sender as LinkButton).CommandArgument);

        ProsecutionUtility.DeleteAProsecutionByID(commentID);


        int entryID = CommentUtility.GetEntryIdByCommentsID(commentID);
        string commentContents = CommentUtility.GetCommentsByCommentId(commentID).Content;
        string entryName = EntryUtility.GetEntryNameById(entryID);

        Model.Notify notify = new Model.Notify();

        string userName = CommentUtility.GetUserNameByCommentId(commentID); ;

        notify.UserId = UserUtility.GetUserIdByName(userName);
        notify.Time = DateTime.Now;

        notify.Content = userName + "用户：<br>你好！<br>你发的内容：" + commentContents + "<br>词条没通过审核！";
        NotifyUtility.SendNotifyToUser(notify);

        CommentUtility.DeleteComment(commentID);
        Response.Redirect("Manager_IFComment.aspx");
    }

    protected void lkBtnSubmit_Click(object sender, EventArgs e)
    {
        int commentID = Convert.ToInt32((sender as LinkButton).CommandArgument);

       // ProsecutionUtility.DeleteAProsecutionByID(commentID);

        int entryID = CommentUtility.GetEntryIdByCommentsID(commentID);

        string commentContents = CommentUtility.GetCommentsByCommentId(commentID).Content;
        string entryName = EntryUtility.GetEntryNameById(entryID);


        Model.Notify notify = new Model.Notify();

        string userName = CommentUtility.GetUserNameByCommentId(commentID); ;

        notify.UserId = UserUtility.GetUserIdByName(userName);
        notify.Time = DateTime.Now;
       
        notify.Content = userName + "用户：<br>你好！<br>你发的内容：" + commentContents + "<br>词条通过审核！";
        NotifyUtility.SendNotifyToUser(notify);

        EntryUtility.DeleteEntryByEntryName(entryName);

        ProsecutionUtility.DeleteAProsecutionByID(commentID);
        //EntryUtility.DeleteEntryById(entryID);
       // CommentUtility.DeleteCommentByEntryID(entryID);


        Response.Redirect("Manager_IFComment.aspx");
    }
    protected void lkBtnSign_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("../Login.aspx");
    }
}