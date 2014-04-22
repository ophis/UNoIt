using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Request.QueryString["emailUserName"];

        if (userName != null)
        {
            if (EmailUtility.GetActivation(userName))
            {
                RedirectAlert("账户激活成功，请登录！", "Login.aspx");
            }
        }
        //else
        //{
        //    Response.Write("<script>alert('账户未激活，请至邮箱！');</script>");
        //}
    }

    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    string userN = txtUserName.Text.ToString().Trim();
    //    string passW = txtPassword.Text.ToString().Trim();

    //    switch (UserUtility.Login(userN, passW))
    //    {
    //        case LoginStateFlag.ACCOUNTFREEZE:
    //            RedirectAlert("账号被冻结", "Login.aspx");
    //            break;

    //        case LoginStateFlag.ADMINSUCCESS:
    //            //管理员登陆成功
    //            Session["isAdmin"] = "TRUE";
    //            Session["userName"] = userN;
    //            Response.Redirect("Admin.aspx");
    //            break;

    //        case LoginStateFlag.NONACTIVATED:
    //            //账户未激活
    //            RedirectAlert("账户未激活", "Login.aspx");
    //            break;

    //        case LoginStateFlag.PASSWORDERROR:
    //            //密码错误
    //            RedirectAlert("密码错误", "Login.aspx");
    //            break;

    //        case LoginStateFlag.USERNAMENOTEXIST:
    //            //用户名不存在
    //            RedirectAlert("用户名不存在", "Login.aspx");
    //            break;

    //        case LoginStateFlag.USERSUCCESS:
    //            //普通用户登陆成功
    //            Session["isAdmin"] = "FALSE";
    //            Session["userName"] = userN;
    //            Response.Redirect("HomepageLogged.aspx");
    //            break;
    //    }
    //}

    private void RedirectAlert(string message, string distUrl)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + message + "');window.location.href ='" + distUrl + "';</script>");
    }
    protected void lkBtnLogin_Click(object sender, EventArgs e)
    {
        string userN = txtUserName.Text.ToString();
        string passW = txtPassword.Text.ToString();

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
                RedirectAlert("密码错误,还剩" + (5 - UserUtility.GetPasswordErrSumByName(userN)) +"次机会", "Login.aspx");
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
        txtUserName.Text = "";
        txtPassword.Text = "";       

        txtUserName.Focus();
    } 
    protected void linkBtnSearch_Click(object sender, EventArgs e)
    {
        string queryString = txtQueryString.Text;
        if (queryString == "")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('输入不能为空！')<script>");
        }
        else
        {
            Response.Redirect("~/ViewEntry.aspx?title=" + queryString);
        }
    }
}