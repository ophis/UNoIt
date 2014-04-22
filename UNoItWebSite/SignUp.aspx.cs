using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lkBtnSign_Click(object sender, EventArgs e)
    {
        string userN = txtUserName.Text.ToString();
        string passW = txtPassword.Text.ToString();
        if (IsHasSpace(userN, passW))
        {
            ClearTxtBox();
            txtUserName.Focus();
        }

        if (userN.Length > 20)
        {
            ClearTxtBox();
            Response.Write("<script>alert('用户名长不能超过20字符')</script>");
        }
        else if (passW.Length > 20)
        {
            ClearTxtBox();
            Response.Write("<script>alert('密码长不能超过20字符')</script>");
        }
        else
        {
            PersonalInformation per = new PersonalInformation();
            per.Email = txtEmail.Text.ToString().Trim();
            per.Birthdate = DateTime.Now.AddYears(-20);
            per.Province = "江苏";
            per.City = "苏州";
            per.Position = "学生";
            per.SkilledField = "计算机";
            per.PhotoUrl = "defualt";
            per.Gender = 0;

            Model.User u = new Model.User();
            u.UserName = userN;
            u.Password = passW;
            u.Activation = 0;
            u.IllegalCount = 0;

            u.Info = per;

            switch (UserUtility.Regist(u))
            {
                case RegistStateFlag.ACCOUNTEXIST:
                   //RedirectAlert("账户已存在！", "SignUp.aspx");
                    ClearTxtBox();
                    break;
                case RegistStateFlag.EMAILEXIST:
                    //RedirectAlert("注册邮箱已注册!", "SignUp.aspx");
                    ClearTxtBox();
                    break;
                case RegistStateFlag.SUCCESS:
                    EmailUtility.SendActivateEmail(u.UserName, per.Email);
                    ClearTxtBox();
                    ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('注册成功，请至邮箱激活！')</script>");
                    break;
            }
        }
    }

    public bool IsHasSpace(string userN, string passW)
    {
        if (userN.LastIndexOf(" ") != -1 || passW.LastIndexOf(" ") != -1)
        { 
            Response.Write("<script>alert('不能有空格')</script>");
            return true;
        }
        else
        {
             return false;
        }
    }

    private void RedirectAlert(string message, string distUrl)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + message + "');window.location.href ='" + distUrl + "';</script>");
    }

    private void ClearTxtBox()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtPassEnsure.Text = "";
        txtEmail.Text = "";

        txtUserName.Focus();
    }

    [System.Web.Services.WebMethod]
    public static bool ValidateUserName(string userName)
    {
        return UserUtility.IsUserExist(userName);
    }

    [System.Web.Services.WebMethod]
    public static bool ValidateEmail(string email)
    {
        return UserUtility.IsEmailExist(email);
    }
    protected void linkBtnSearch_Click(object sender, EventArgs e)
    {
        string queryString = txtQueryString.Text.Trim();
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