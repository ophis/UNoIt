using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MessageUtility
    {
        public static bool SendMessage(Model.Message msg)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            DAL.Message message = new DAL.Message();

            message.Receiver = msg.Receiver;
            message.Sender = msg.Sender;
            message.Contents = msg.Contents;
            message.SendTime = DateTime.Now;

            dataContext.Message.InsertOnSubmit(message);
            dataContext.SubmitChanges();
 
            return true;
        }

        public static List<Model.Message> ReceiveMessage(string userName)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var allMsg = from u in dataContext.Message
                         where u.Receiver == userName
                         select u;

            List<Model.Message> msgList = new List<Model.Message>();
            foreach(var row in allMsg)
            {
                Model.Message msg = new Model.Message();
                msg.Contents = row.Contents;
                msg.Receiver = row.Receiver;
                msg.Sender = row.Sender;
                msg.SendTime = row.SendTime;
                msg.MessageID = row.MessageID;

                msgList.Add(msg);
            }
            return msgList;
        }

        public static bool DeleteMessageByMsgId(int msgId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();

            var message = dataContext.Message.FirstOrDefault(m => m.MessageID == msgId);
            if (message == null)
            {
                return false;
            }
            else
            {
                dataContext.Message.DeleteOnSubmit(message);
                dataContext.SubmitChanges();
                return true;
            }
        }
    }
}
