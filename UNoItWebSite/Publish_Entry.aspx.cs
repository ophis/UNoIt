using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Publish_Entry : System.Web.UI.Page
{
    static string[][] catagory = new string[][]
                          { new string[]{"自然","生物", "天文", "地理", "自然现象"},
                            new string[]{"科技","数理化", "医药学", "生物学",  "应用科学"},
                            new string[]{"文化", "文学", "艺术", "民俗", "宗教"},
                            new string[]{"生活","衣", "食", "住", "行"},
                            new string[]{"社会","军事", "政法", "时事", "机构"}};

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string userName = Session["userName"].ToString();
            if (userName != null)
            {
                hpLkLogin.Text = userName;
                hpLkLogin.NavigateUrl = "PersonalHP_MyEntry.aspx";

                lkBtnSign.Text = "注销";
            }
            for (int i = 1; i < catagory[0].Length; i++)
            {
                this.Select2.Items.Add(catagory[0][i]);
            }
        }      
    }
    //TODO 如果用了文本编辑器，这里可能要作相应更改。
    protected void linkBtnPublish_Click(object sender, EventArgs e)
    {
        if (  Text_UID.Value.ToString().Trim() == ""
           || Text_Password.Value.ToString().Trim() == ""
           || TextArea1.InnerText.ToString().Trim() == "")
        {
            AlertMsg("请先输入完整再提交，谢谢！");
        } 
        else
        {
            
            Model.EntryToBeVerified entry = new Model.EntryToBeVerified();
            entry.Content = TextArea1.Value;//InnerText;
            entry.EntryName = Text_UID.Value.ToString().Trim();
            entry.ReleasedTime = DateTime.Now;
            entry.Source = Text_Password.Value.ToString().Trim();
            entry.UserId = BLL.UserUtility.GetUserIdByName(Session["userName"].ToString());            
            Model.Catagory catagory = new Model.Catagory();
            catagory.CatagoryName = Select2.SelectedItem.Value.ToString();
            entry.CatagoryId = BLL.EntryUtility.GetCatagoryIdByName(catagory);

            if (BLL.EntryToBeVerifiedUtility.CreateEntry(entry))
            {
                AlertMsg("提交成功，等待管理员审核");
                Response.Redirect("Index.aspx");
            }
            else
            {
                AlertMsg("你发的消息含有敏感词...");
                Model.Notify notify = new Model.Notify();
                notify.Time = DateTime.Now;
                notify.UserId = Convert.ToInt32(Request.QueryString["userId"]);
                notify.Content = "尊敬的" + BLL.UserUtility.GetUserNameById(notify.UserId) + "你好!"
                                 + "你提交的内容含有违规词条。";
                BLL.NotifyUtility.SendNotifyToUser(notify);
            }


        }
    }

    protected void hpLkSign_Click(object sender, EventArgs e)
    {
       Session.Clear();
       Response.Redirect("Login.aspx", true);
        
    }
   

    [System.Web.Services.WebMethod]
    public static List<string> GetSecondCatagory(string catagoryName)
    {
        int firstCatagoryId = 0;
        while (catagory[firstCatagoryId][0] != catagoryName)
        {
            firstCatagoryId++;
        }

        List<string> list = new List<string>();
        for (int i = 1; i < catagory[firstCatagoryId].Length; i++)
        {
            list.Add(catagory[firstCatagoryId][i]);
        }
        return list;
    }

    [System.Web.Services.WebMethod]
    public static List<string> test(string catagoryName)
    {
        List<string> list = new List<string>();
        list.Add(catagoryName); list.Add(catagoryName);
        return list;
    }

    private void AlertMsg(string message)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + message + "');</script>");
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