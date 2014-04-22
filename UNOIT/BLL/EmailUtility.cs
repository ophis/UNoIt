using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using Model;
using DAL;

namespace BLL
{
    public class EmailUtility
    {
        public static void CreateSTMP(string email, string message)
        {
            //SmtpClient smtp = new SmtpClient(); //实例化一个SmtpClient
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network
            //smtp.EnableSsl = false;//smtp服务器是否启用SSL加密
            //smtp.Host = "smtp.sina.com.cn"; //指定 smtp 服务器地址

            //smtp.Credentials = new NetworkCredential("sharpunoit@sina.com", "unoit123");
            //MailMessage mm = new MailMessage(); //实例化一个邮件类
            //mm.Priority = MailPriority.High; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
            //mm.From = new MailAddress("sharpunoit@sina.com");

            ////string str = "sharpunoit@sina.com";
            //mm.To.Add(email);

            //mm.Subject = "UNOIT Password"; //邮件标题
            //mm.SubjectEncoding = Encoding.GetEncoding(936);
            //mm.BodyEncoding = Encoding.GetEncoding(936);
            //mm.IsBodyHtml = true; //邮件正文是否是HTML格式      

            //mm.Body = message;

            //smtp.Send(mm); //发送邮件，如果不返回异常， 则大功告成了。

            SmtpClient smtp = new SmtpClient(); //实例化一个SmtpClient
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network
            smtp.EnableSsl = false;//smtp服务器是否启用SSL加密
            smtp.Host = "smtp.163.com"; //指定 smtp 服务器地址
            smtp.Port = 25;             //指定 smtp 服务器的端口，默认是25，如果采用默认端口，可省去

            smtp.Credentials = new NetworkCredential("sharpunoit@163.com", "unoit123");
            MailMessage mm = new MailMessage(); //实例化一个邮件类
            mm.Priority = MailPriority.High; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
            mm.From = new MailAddress("sharpunoit@163.com", "C#UNOIT", Encoding.GetEncoding(936));


            mm.To.Add(new MailAddress(email, "接收者", Encoding.GetEncoding(936)));

            mm.Subject = "这是邮件标题"; //邮件标题
            mm.SubjectEncoding = Encoding.GetEncoding(936);

            mm.IsBodyHtml = true; //邮件正文是否是HTML格式

            mm.BodyEncoding = Encoding.GetEncoding(936);

            
            mm.Body = message; 

            smtp.Send(mm); //发送邮件，如果不返回异常， 则大功告成了。

        }

        public static bool SendActivateEmail(string userName, string email)
        {
            string message = @"10.6.12.12:8080/Login.aspx?users=" + userName;
            CreateSTMP(email, message);
            return false;
        }

        public static bool GetActivation(string userName)
        {
            DALDataContext da = new DALDataContext();
            var queryActivation = (from query in da.Users where query.UserName == userName select query).FirstOrDefault();

            if (queryActivation != null)
            {
                queryActivation.IsActivated = 1;

                da.SubmitChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SendPasswordToUserEmail(string userName, string email)
        {
            DALDataContext da = new DALDataContext();

            //判断用户名与邮箱是否匹配
            var queryPass = (from query in da.Users where (query.UserName == userName && query.Email == email) select new { query.Password }).FirstOrDefault();

            if (queryPass != null)
            {
                string pass = queryPass.ToString();

                //向用户发送密码
                CreateSTMP(email, queryPass.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

