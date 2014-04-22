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

public partial class Admin_Manager_Entry : System.Web.UI.Page
{
    public class ModifiedEntry
    {
        private string entryName;

        public string EntryName
        {
            get { return entryName; }
            set { entryName = value; }
        }

        private string entryContents;

        public string EntryContents
        {
            get { return entryContents; }
            set { entryContents = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private DateTime releaseTime;

        public DateTime ReleaseTime
        {
            get { return releaseTime; }
            set { releaseTime = value; }
        }
    }

    public string adminName = "fhb";
    protected void Page_Load(object sender, EventArgs e)
    {
        //adminName = Session["adminName"].ToString();

        if (adminName != null)
        {
            hpLkAdmin.Text = adminName;
            hpLkAdmin.NavigateUrl = "Manager_Entry.aspx";
        }

        List<Model.EntryToBeVerified> entryVerifiedList = new List<Model.EntryToBeVerified>();

        entryVerifiedList = EntryToBeVerifiedUtility.GetAllEntriesToVarify();

        if (entryVerifiedList != null)
        {
            List<DateTime> releaseTimeList = new List<DateTime>();

            foreach (var query in entryVerifiedList)
            {
                releaseTimeList.Add(query.ReleasedTime);
            }

            List<string> userNameList = new List<string>();

            foreach (var query in entryVerifiedList)
            {
                userNameList.Add(UserUtility.GetUserNameById(query.UserId));
            }

             List<string> entryNameList = new List<string>();

            foreach (var query in entryVerifiedList)
            {
                entryNameList.Add(EntryToBeVerifiedUtility.GetEntryToVarifyById(query.EntryId).EntryName);
            }

            List<string> contentsList = new List<string>();

            foreach (var query in entryVerifiedList)
            {
                contentsList.Add(query.Content);
            }

            List<ModifiedEntry> proEntryList = new List<ModifiedEntry>();

            for (int i = 0; i < entryVerifiedList.Count(); i++)
            {
                ModifiedEntry entry = new ModifiedEntry();

                entry.EntryName = entryNameList[i];
                entry.UserName = userNameList[i];
                entry.ReleaseTime = releaseTimeList[i];
                entry.EntryContents = contentsList[i];

                proEntryList.Add(entry);
            }

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = proEntryList;
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
                sb.Append(string.Format("<a href='Manager_Entry.aspx?pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
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

    protected void lkBtnLook_Click(object sender, EventArgs e)
    {
        string entryName  = Convert.ToString((sender as LinkButton).CommandArgument);

        int entryID = EntryUtility.GetEntryIdByName(entryName);

        if (entryID != -1)
        {
            Response.Redirect("AuditModify.aspx?modifyEntry=" + entryName);
        }
        else
        {
            Response.Redirect("AudiPublish.aspx?publishEntry=" + entryName);
        }
    }
    protected void lkBtnLogOff_Click(object sender, EventArgs e)
    {
        Session.Clear();

        Response.Redirect("../Login.aspx");
    }
}