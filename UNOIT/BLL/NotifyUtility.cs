using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data.Linq;


namespace BLL
{
    public class NotifyUtility
    {

        //用户删除通知时，可以直接调用该方法，根据notityId,直接删除数据库中的通知；

        public static bool DeleteNotify(int notifyId)
        {

            DALDataContext ds = new DALDataContext();

            var notity = from n in ds.Notify
                         where n.NotifyID == notifyId
                         select n;

            if (notity.Count() != 0)
            {

                foreach (var item in notity)
                {
                    ds.Notify.DeleteOnSubmit(item);
                    ds.SubmitChanges();
                }

                return true;
            }

            return false;
        }

      
        // 根据通知ID查找表中的对应通知，如果表中没有该通知ID，返回null.

        public static List<Model.Notify> GetNotifyByUserId(int userId)
        {
            DALDataContext da = new DALDataContext();

            List<Model.Notify> list = new List<Model.Notify>();

            Model.Notify noti = new Model.Notify();
            var notify = from n in da.Notify
                         where n.UserID == userId
                         select n;


            foreach (var item in notify)
            {
                Model.Notify com = new Model.Notify();
                com.NotifyId = item.NotifyID;
                com.Content = item.NotifyContents;
                com.Time = item.NotifyTime;
                com.UserId = item.UserID;
                list.Add(com);
            }

            return list;
        }


        public static List<Model.Notify> GetAllNotifies()
        {
            DALDataContext dalContext = new DALDataContext();

            Model.Notify notify = new Model.Notify();
                
            var queryNotifies = from query in dalContext.Notify orderby query.NotifyTime descending select query;

            if (queryNotifies.Count() != 0)
            {
                List<Model.Notify> notifyList = new List<Model.Notify>();
                foreach (var query in queryNotifies)
                {
                    notify.Content = query.NotifyContents;
                    notify.Time = query.NotifyTime;

                    notifyList.Add(notify);
                }

                return notifyList;
            }
            else
                return null;
        }

        //当管理员删除词条，删除评论，审核词条通过，审核词条不通过，都将调用该方法向用户发送通知
        public static bool SendNotifyToUser(Model.Notify notify)
        {
            DALDataContext da = new DALDataContext();
  
            var queryNotify = from query in da.Notify where query.UserID == notify.UserId select query;

            if (queryNotify.Count() != 0)
            {
                DAL.Notify dalNotify = new DAL.Notify();

                //dalNotify.NotifyID = notify.NotifyId;
                dalNotify.NotifyTime = notify.Time;
                dalNotify.NotifyContents = notify.Content;
                dalNotify.UserID = notify.UserId;

                da.Notify.InsertOnSubmit(dalNotify);
                da.SubmitChanges();

                return true;
            }

            else
            {
                return false;
            }
         
        }

    }
}
