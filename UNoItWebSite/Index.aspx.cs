using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;


public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["userName"] == null)
        {            
            userInfoDiv.Style.Value="visibility:hidden";
        }
        else
        {
            hpLkLogin.Text = Session["userName"].ToString();
            hpLkLogin.NavigateUrl = "PersonalHP_MyEntry.aspx";
            lkBtnSign.Text = "注销";

            loginDiv.Style.Value = "visibility:hidden";
            lblUserName.InnerText = Session["userName"].ToString();
        }

        //TODO:前台的链接要添加
        List<Model.Entry> hotEntriesList = BLL.EntryUtility.GetHotEntries();
        dataListHotEnties.DataSource = hotEntriesList;
        dataListHotEnties.DataBind();
        
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
        Response.Redirect("../Login");
    }

    protected void LinkBtnLogin_Click(object sender, EventArgs e)
    {
        string userN = Text_UID.Text.ToString();
        string passW = Text_Password.Text.ToString();

        switch (UserUtility.Login(userN, passW))
        {
            case LoginStateFlag.ACCOUNTFREEZE:
                ClearTxtBox();
                RedirectAlert("账号被冻结", "Login.aspx");
                break;

            case LoginStateFlag.ADMINSUCCESS:
                //管理员登陆成功
                Session["isAdmin"] = "TRUE";
                Session["adminName"] = userN;
                Response.Redirect("Admin/Manager_Entry.aspx");
                break;

            case LoginStateFlag.NONACTIVATED:
                //账户未激活
                ClearTxtBox();
                RedirectAlert("账户未激活", "Login.aspx");
                break;

            case LoginStateFlag.PASSWORDERROR:
                //密码错误
                ClearTxtBox();
                RedirectAlert("密码错误,还剩" + (5 - UserUtility.GetPasswordErrSumByName(userN)) + "次机会", "Login.aspx");
                break;
            case LoginStateFlag.USERNAMENOTEXIST:
                //用户名不存在
                ClearTxtBox();
                RedirectAlert("用户名不存在", "Login.aspx");
                break;

            case LoginStateFlag.USERSUCCESS:
                //普通用户登陆成功
                Session["isAdmin"] = "FALSE";
                Session["userName"] = userN;
                Response.Redirect("PersonalHP_MyEntry.aspx");
                break;
        }
    }

      private void ClearTxtBox()
    {
        Text_UID.Text = "";
        Text_Password.Text = "";       

        Text_UID.Focus();
    } 

     private void RedirectAlert(string message, string distUrl)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + message + "');window.location.href ='" + distUrl + "';</script>");
    }
}