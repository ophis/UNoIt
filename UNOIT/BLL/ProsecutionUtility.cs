using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data.Linq;


namespace BLL
{
    public class ProsecutionUtility
    {
        //举报一个词条或者评论，当用户看到词条或者评论违规，可点击“举报”按钮

        public static bool ProsecuteEntry(Model.Prosecution prosecution)
        {
            DAL.DALDataContext da = new DAL.DALDataContext();


            var queryResults = (from query in da.Prosecution
                                where query.ID == prosecution.Id && query.IsEntry == prosecution.IsEntry 
                                select query).FirstOrDefault();

            if (queryResults == null)
            {
                DAL.Prosecution dalProsecution = new DAL.Prosecution();

                dalProsecution.ProsecutionTime = DateTime.Now;
                dalProsecution.IsEntry = prosecution.IsEntry;
                dalProsecution.UserID = prosecution.UserId;
                dalProsecution.ID = prosecution.Id;

                da.Prosecution.InsertOnSubmit(dalProsecution);
                da.SubmitChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        //在存有举报的数据表中将该举报的数据删除通过prosecutionId

        public static bool DeleteAProsecution(int prosecutionId)
        {
            DAL.DALDataContext da = new DAL.DALDataContext();

            var prosecution = da.Prosecution.FirstOrDefault(p => p.ProsecutionID == prosecutionId);

            if (prosecution == null)
            {
                return false;
            }
            else
            {
                da.Prosecution.DeleteOnSubmit(prosecution);
                da.SubmitChanges();
                return true;
            }          
        }

        //在存有举报的数据表中将该举报的数据删除通过Id

        public static bool DeleteAProsecutionByID(int ID)
        {
            DAL.DALDataContext da = new DAL.DALDataContext();

            var prosecution = da.Prosecution.FirstOrDefault(p => p.ID == ID);

            if (prosecution == null)
            {
                return false;
            }
            else
            {
                da.Prosecution.DeleteOnSubmit(prosecution);
                da.SubmitChanges();
                return true;
            }
        }

        public static int GetUserIDById(int Id)
        {
            DAL.DALDataContext da = new DAL.DALDataContext();

            var queryResults = (from query in da.Prosecution where query.ID == Id select query).FirstOrDefault();

            if (queryResults != null)
            {
                return (int)queryResults.UserID;
            }
            else
            {
                return -1;
            }
        }
        //管理员处理举报，从举报的表中取得一条举报，再调用DeleteAProsecution将其从数据库中删除，这样可以保证每个举报只被处理一次；

        public static Model.Prosecution GetAProsecution()
        {
            DAL.DALDataContext da = new DAL.DALDataContext();

            Model.Prosecution mProsecution = new Model.Prosecution();

            var pro = (from n in da.Prosecution select n).FirstOrDefault();

            if (pro != null)
            {
                mProsecution.UserId = pro.UserID;
                mProsecution.Id = pro.ID;
                mProsecution.ProscuteTime = pro.ProsecutionTime;
                mProsecution.IsEntry = pro.IsEntry;

                DeleteAProsecution(pro.ProsecutionID);

                return mProsecution;

            }
            else
            {
                return null;
            }
        }

        public static List<Model.Prosecution> GetAllProsecutionEntry()
        {
            DALDataContext dataContext = new DALDataContext();

            var queryResults = from query in dataContext.Prosecution where query.IsEntry == 1 select query;

            List<Model.Prosecution> prosecutionList = new List<Model.Prosecution>();

            if (queryResults.Count() != 0)
            {
                foreach (var query in queryResults)
                {
                    Model.Prosecution prosecution = new Model.Prosecution();

                    prosecution.UserId = query.UserID;
                    prosecution.Id = query.ID;
                    prosecution.ProscuteTime = query.ProsecutionTime;
                    prosecution.IsEntry = 1;

                    prosecutionList.Add(prosecution);
                }

                return prosecutionList;
            }
            else
            {
                return null;
            }
        }

        public static List<Model.Prosecution> GetAllProsecutionComment()
        {
            DALDataContext dataContext = new DALDataContext();

            var queryResults = from query in dataContext.Prosecution where query.IsEntry == 0 select query;

            List<Model.Prosecution> prosecutionList = new List<Model.Prosecution>();

            if (queryResults.Count() != 0)
            {
                foreach (var query in queryResults)
                {
                    Model.Prosecution prosecution = new Model.Prosecution();

                    prosecution.UserId = query.UserID;
                    prosecution.Id = query.ID;
                    prosecution.ProscuteTime = query.ProsecutionTime;
                    prosecution.IsEntry = 0;

                    prosecutionList.Add(prosecution);
                }

                return prosecutionList;
            }
            else
            {
                return null;
            }
        }
    }
}