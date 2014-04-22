using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;


public partial class Retrieve_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lkBtnSubmit_Click(object sender, EventArgs e)
    {
        string userName = txtUserName.Text.ToString().Trim();
        string email = txtEmail.Text.ToString().Trim();
        if (EmailUtility.SendPasswordToUserEmail(userName, email))
        {
            ClearTxtBox();
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('请至邮箱获取密码！');</script>");

        }
        else
        {
            ClearTxtBox();
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('用户名 邮箱不匹配，请确认！');</script>");
        }
       
    }

    private void ClearTxtBox()
    {
        txtUserName.Text = "";
        txtEmail.Text = "";

        txtUserName.Focus();
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
}