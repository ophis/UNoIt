using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;

public partial class PersonalHP_EditInfo : System.Web.UI.Page
{
    public string userName = "";
    public string position = "";
    public string birthday = "";
    public string city = "";
    public string skilledField = "";
    public int scores = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userName = Session["userName"].ToString();

            if (userName != null)
            {
                
                  hpLkLogin.Text = userName;
                  hpLkLogin.NavigateUrl = "PersonalHP_MyEntry.aspx";

                  lkBtnSign.Text = "注销";
               
                int userId = UserUtility.GetUserIdByName(userName);

                lblUserName.Text = userName;
                Model.PersonalInformation person = PersonalInformationUtility.GetPersonalInfoByUserName(userName);
                position = person.Position;
                birthday = person.Birthdate.ToShortDateString();
                city = person.City;
                skilledField = person.SkilledField;
                scores = UserUtility.GetScoresByUserName(userName);

                Page.DataBind();

                Model.PersonalInformation personalInfomation = BLL.UserUtility.GetUserInfoByName(Session["userName"].ToString().Trim());
                lblUserName2.Text = userName;
                txtBirthdate.Text = Convert.ToString(personalInfomation.Birthdate);
                txtCity.Text = Convert.ToString(personalInfomation.City);
                txtPhotoUrl.Text = Convert.ToString(personalInfomation.PhotoUrl);
                txtSkilledField.Text = Convert.ToString(personalInfomation.SkilledField);
                rdGender1.Checked = false;
                rdGender2.Checked = false;
                rdGender3.Checked = false;


                if (personalInfomation.Gender == 1)
                {
                    rdGender1.Checked = true;
                }
                else if (personalInfomation.Gender == -1)
                {
                    rdGender2.Checked = true;
                }
                else
                {
                    rdGender3.Checked = true;
                }
            }
        }
        

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
            Response.Redirect("#?title=" + queryString);
        }
    }

    protected void linkBtnEdit_Click(object sender, EventArgs e)
    {
        PersonalInformation per = new PersonalInformation();
        per.Birthdate = DateTime.Parse(txtBirthdate.Text.ToString().Trim());
        per.PhotoUrl = txtPhotoUrl.Text.ToString().Trim();
        per.City = txtCity.Text.ToString().Trim();
        per.SkilledField = txtSkilledField.Text.ToString().Trim();
        per.Province = "江苏";
        per.Position = position;

        if (rdGender1.Checked)
        {
            per.Gender = 1;
        }
        else if (rdGender2.Checked)
        {
            per.Gender = -1;
        }
        else
        {
            per.Gender = 0;
        }
        BLL.PersonalInformationUtility.UpdatePersonalInformation(Session["userName"].ToString().Trim(), per);
        RedirectAlert("修改成功","PersonalHP_MyEntry.aspx");
    }

    protected void linkBtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PersonalHP_MyEntry.aspx");
    }

    private void RedirectAlert(string message, string distUrl)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + message + "');window.location.href ='" + distUrl + "';</script>");
    }
    protected void linkBtnSearch_Click1(object sender, EventArgs e)
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
