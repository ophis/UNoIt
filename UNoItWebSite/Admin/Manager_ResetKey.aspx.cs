using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;

public partial class Manager_ResetKey : System.Web.UI.Page
{
    public string adminName = "fhb";
    protected void Page_Load(object sender, EventArgs e)
    {
      //  adminName = Session["adminName"].ToString();

        if (adminName != null)
        {
            hpLkAdmin.Text = adminName;
            hpLkAdmin.NavigateUrl = "Manager_Entry.aspx";
        }
    }

    protected void lkBtnReset_Click(object sender, EventArgs e)
    {
        string oldPassword = txtOldPass.Text.ToString();
        string newPassword = txtNewPass.Text.ToString();
        string EnsurePassword = txtEnsurePass.Text.ToString();

        if (newPassword.LastIndexOf(" ") != -1)
        {
            ClearBox();
            Response.Write("<script>alert('密码不能有空格')</script>");
        }
        else if (newPassword.Length > 20 || newPassword.Length < 5)
        {
            ClearBox();
            Response.Write("<script>alert('密码应为5~20个字符')</script>");
        }
        else if (!newPassword.Equals(EnsurePassword))
        {
            ClearBox();
            Response.Write("<script>alert('密码不一致')</script>");
        }
        else if (UserUtility.SetAdminNewPassword(adminName, oldPassword, newPassword))
        {
            ClearBox();
            Response.Write("<script>alert('密码设置成功！')</script>");
        }
        else
        {
            ClearBox();
            Response.Write("<script>alert('用户名 密码不匹配！')</script>");
        }
    }

    private void ClearBox()
    {
        txtOldPass.Text = "";
        txtNewPass.Text = "";
        txtEnsurePass.Text = "";
        txtOldPass.Focus();
    }

    protected void lkBtnCancel_Click1(object sender, EventArgs e)
    {
        ClearBox();
    }
    protected void lkBtnLogOff_Click(object sender, EventArgs e)
    {
        Session.Clear();

        Response.Redirect("../Login.aspx");
    }
}
