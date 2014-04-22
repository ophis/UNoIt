using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modify_Entry : System.Web.UI.Page
{
    static Model.Entry entry = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string entryName = Request.QueryString["title"].ToString().Trim();

            


            entry = BLL.EntryUtility.SearchEntryByName(entryName);
            if (null == entry)
            {
                return;
            }

            hpLkLogin.Text = Session["userName"].ToString();
            hpLkLogin.NavigateUrl = "PersonalHP_MyEntry.aspx";

            lkBtnSign.Text = "注销";

            this.hEntryName.InnerText = entry.EntryName;
            this.TextArea1.InnerText = entry.Content;
            this.Text_Password.Value = entry.Source;
            lblFirstCatagory.InnerText = Request.QueryString["firstCatagory"];
            lblSecondCatagory.InnerText = Request.QueryString["secondCatagory"];
        }        
    }
    protected void linkBtnEdit_Click(object sender, EventArgs e)
    {
        if (this.hEntryName.InnerText == "" ||
            this.Text_Password.Value == "" ||
            this.TextArea1.InnerText == "")
        {
            AlertMsg("请输入完整!");
        } 
        else
        {
            Model.EntryToBeVerified newEntry = new Model.EntryToBeVerified();
            newEntry.CatagoryId = entry.CatagoryId;
            newEntry.Content = this.TextArea1.InnerText;
            newEntry.EntryName = entry.EntryName;
            newEntry.ReleasedTime = DateTime.Now;
            newEntry.Source = this.Text_Password.Value.ToString().Trim();
            newEntry.UserId = BLL.UserUtility.GetUserIdByName(Session["userName"].ToString());
            BLL.EntryToBeVerifiedUtility.CreateEntry(newEntry);
            RedirectAlert("提交成功，等待管理员审核。", "Index.aspx");
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