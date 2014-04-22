
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;

public partial class Admin_AuditModify : System.Web.UI.Page
{
    public string adminName = "fhb";
    public string entryName = "";
    public string oldContents = "";
    public string newContents = "";
    public int entryID = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
       // adminName = Session["adminName"].ToString();
        entryName = Request.QueryString["modifyEntry"].ToString();

        if (entryName != null)
        {
            hpLkAdmin.Text = adminName;
            hpLkAdmin.NavigateUrl = "Manager_Entry.aspx";

            entryID = EntryUtility.GetEntryIdByName(entryName);
            oldContents = EntryUtility.GetEntryContentsByID(entryID);
            newContents = EntryToBeVerifiedUtility.GetEntryContentsByEntryName(entryName);

            Page.DataBind();
        }
    }

    protected void lkBtnPass_Click(object sender, EventArgs e)
    {
        Model.EntryToBeVerified entry = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName);
        EntryUtility.DeleteEntryByEntryName(entryName);
        EntryUtility.AgreeThisEntry(entry);
        EntryToBeVerifiedUtility.DeleteThisEntryToBeVarified(entry.EntryId);

        Response.Redirect("Manager_Entry.aspx");
    }


    protected void lkBtnReject_Click(object sender, EventArgs e)
    {
        Model.EntryToBeVerified entry = EntryToBeVerifiedUtility.GetEntryToVarifyByEntryName(entryName);

        EntryToBeVerifiedUtility.DeleteThisEntryToBeVarified(entry.EntryId);

        Response.Redirect("Manager_Entry.aspx");
    }
    protected void lkBtnLogOff_Click(object sender, EventArgs e)
    {
        Session.Clear();

        Response.Redirect("../Login.aspx");
    }
}