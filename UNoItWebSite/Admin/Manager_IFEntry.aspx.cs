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

public partial class Admin_Manager_IFEntry : System.Web.UI.Page
{
    public class ProEntry
    {
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
        private string entryContents;

        public string EntryContents
        {
            get { return entryContents; }
            set { entryContents = value; }
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
       adminName = Session["adminName"].ToString();
        if (adminName != null)
        {
            hpLkLogin.Text = adminName;
            hpLkLogin.NavigateUrl = "Manager_Entry.aspx";

            lkBtnSign.Text = "注销";
            //返回所有举报的词条
            List<Model.Prosecution> prosecutionList = ProsecutionUtility.GetAllProsecutionEntry();

            if (prosecutionList != null)
            {
                List<string> userNameList = new List<string>();

                foreach (var query in prosecutionList)
                {
                    userNameList.Add(UserUtility.GetUserNameById(query.UserId));
                }

                List<string> contentsList = new List<string>();

                foreach (var query in prosecutionList)
                {
                    contentsList.Add(EntryUtility.GetEntryContentsByID(query.Id));
                }

                List<string> entryNameList = new List<string>();

                foreach (var query in prosecutionList)
                {
                    entryNameList.Add(EntryUtility.GetEntryNameById(query.Id));
                }

                List<ProEntry> proEntryList = new List<ProEntry>();

                for (int i = 0; i < prosecutionList.Count(); i++)
                {
                    ProEntry entry = new ProEntry();

                    entry.EntryName = entryNameList[i];
                    entry.EntryContents = contentsList[i];
                    entry.ProUser = userNameList[i];

                    entry.ProTime = prosecutionList[i].ProscuteTime;

                    proEntryList.Add(entry);
                }

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = proEntryList;
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
                    sb.Append(string.Format("<a href='Admin/Manager_IFEntry.aspx?pageindex={0}'> {1}</a>&nbsp;", i, i + 1));
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
    }
    protected void lkBtnSubmit_Click(object sender, EventArgs e)
    {
        string entryName = Convert.ToString((sender as LinkButton).CommandArgument);
     

        int entryID = EntryUtility.GetEntryIdByName(entryName);


        string contents = EntryUtility.GetEntryContentsByID(entryID);

        Model.Notify notify = new Model.Notify();

        notify.UserId = ProsecutionUtility.GetUserIDById(entryID);
        notify.Time = DateTime.Now;

        string userName = UserUtility.GetUserNameById(notify.UserId);
        notify.Content = userName + "用户：<br>你好！<br>你发的内容：" + contents + "<br>词条通过审核！";
        NotifyUtility.SendNotifyToUser(notify);

        EntryUtility.DeleteEntryByEntryName(entryName);
       ProsecutionUtility.DeleteAProsecutionByID(entryID);
        Response.Redirect("Manager_IFEntry.aspx");
    }

    protected void lkBtnCancel_Click(object sender, EventArgs e)
    {
        string entryName = Convert.ToString((sender as LinkButton).CommandArgument);
      
        int entryID = EntryUtility.GetEntryIdByName(entryName);

        string contents = EntryToBeVerifiedUtility.GetEntryContentsByEntryName(entryName);
        
        Model.Notify notify = new Model.Notify();

        notify.UserId = ProsecutionUtility.GetUserIDById(entryID);
        notify.Time = DateTime.Now;

        string userName = UserUtility.GetUserNameById(notify.UserId);
        notify.Content = userName + "用户：<br>你好！<br>你发的内容：" + contents + "<br>词条不通过审核！";
        NotifyUtility.SendNotifyToUser(notify);

        ProsecutionUtility.DeleteAProsecutionByID(entryID);
        Response.Redirect("Manager_IFEntry.aspx");
    }
    protected void lkBtnSign_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("../Login.aspx");
    }
}