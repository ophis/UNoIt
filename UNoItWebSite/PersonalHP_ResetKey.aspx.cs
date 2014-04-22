using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;
using System.Globalization;
using System.Data;

public partial class PersonalHP_ResetKey : System.Web.UI.Page
{
    public string userName = "";
    public string position = "";
    public string birthday = "";
    public string city = "";
    public string skilledField = "";
    public int scores = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        userName = Session["userName"].ToString();

       if (userName != null)
       {
           hpLkLogin.Text = userName;
           hpLkLogin.NavigateUrl = "PersonalHP_MyEntry.aspx";
         
            hpLkSign.Text = "注销";
       }

       lblUserName.Text = userName;
       lblUserNameShow.Text = userName;
        Model.PersonalInformation person = PersonalInformationUtility.GetPersonalInfoByUserName(userName);

        position = person.Position;
        birthday =  person.Birthdate.ToShortDateString();
        
       
        //birthday.ToShortDateString
        //DateTime dt = DateTime.ParseExact(dr["time"].ToString(), "yyyy-MM-dd", null);
        city = person.City;
        skilledField = person.SkilledField;
        scores = UserUtility.GetScoresByUserName(userName);

        Page.DataBind();
    }

    protected void lkBtnReset_Click(object sender, EventArgs e)
    {
        string oldPassword = txtOldPass.Text.ToString().Trim();
        string newPassword = txtNewPass.Text.ToString().Trim();
        string EnsurePassword = txtEnsurePass.Text.ToString().Trim();

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
        else if (UserUtility.SetNewPassword(lblUserNameShow.Text, oldPassword, newPassword))
        {
            Response.Write("<script>alert('密码设置成功！')</script>");
        }
    }

    private void ClearBox()
    {
        txtOldPass.Text = "";
        txtNewPass.Text = "";
        txtEnsurePass.Text = "";
        txtOldPass.Focus();
    }
    protected void lkBtnCancel_Click(object sender, EventArgs e)
    {
        ClearBox();
    }
    protected void hpLkSign_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}