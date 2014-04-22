using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;

public partial class Admin_AudiPublish : System.Web.UI.Page
{
    public string adminName = "fhb";
    public string entryName = "";
    public string contents = "";
    public int entryID = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        //adminName = Session["adminName"].ToString();
        entryName = Request.QueryString["publishEntry"].ToString();

        if (entryName != null)
        {
            hpLkAdmin.Text = adminName;
            hpLkAdmin.NavigateUrl = "Manager_Entry.aspx";

            int entryID = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName).EntryId;
            contents = EntryToBeVerifiedUtility.GetEntryContentsByEntryName(entryName);

            Page.DataBind();
        }
    }

    protected void lkBtnPass_Click(object sender, EventArgs e)
    {
        entryName = Request.QueryString["publishEntry"].ToString();
        if (entryName != null)
        {
            Model.EntryToBeVerified entry = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName);
            EntryUtility.AgreeThisEntry(entry);

            entryID = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName).EntryId;
           
            Model.Notify notify = new Model.Notify();

            notify.UserId = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName).UserId;
            notify.Time = DateTime.Now;

            string userName = UserUtility.GetUserNameById(notify.UserId);
            notify.Content = userName + "用户：<br>你好！<br>你发的内容：" + contents + "<br>词条通过审核！";
            NotifyUtility.SendNotifyToUser(notify);

            EntryToBeVerifiedUtility.DeleteThisEntryToBeVarified(entryID);


            Response.Redirect("Manager_Entry.aspx");
        }
    }

    protected void lkBtnReject_Click(object sender, EventArgs e)
    {
        entryName = Request.QueryString["publishEntry"].ToString();

        if (entryName != null)
        {
            Model.EntryToBeVerified entry = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName);

            entryID = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName).EntryId;

            Model.Notify notify = new Model.Notify();

            notify.UserId = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName).UserId;
            notify.Time = DateTime.Now;

            string userName = UserUtility.GetUserNameById(notify.UserId);
            notify.Content = userName + "用户：<br>你好！<br>你发的内容：" + contents + "<br>词条不通过审核！";
            NotifyUtility.SendNotifyToUser(notify);

            EntryToBeVerifiedUtility.DeleteThisEntryToBeVarified(entryID);

            

            Response.Redirect("Manager_Entry.aspx");
        }
    }
    protected void lkBtnLogOff_Click(object sender, EventArgs e)
    {
        Session.Clear();

        Response.Redirect("../Login.aspx");
    }
}