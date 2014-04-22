using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DAL;
using Model;

namespace BLL
{
    public class HistoryUtility
    {
        //Type t;
        //public static List<int> GetAllHistory(object table, Type t, int userId) 
        //{
        //    Model.History mHistory = new Model.History();
        //    DALDataContext da = new DALDataContext();

        //    var query = from history in da. where history.UserID == userId select new { history.EntryID };
        //    return null;
        //}
        //public static List<int> GetAllHistory(int userId,DALDataContext da) 

        public static Model.History GetHistoryByUserId(int userId)
        {
           // Model.History mHistory = new Model.History();

           // DALDataContext da = new DALDataContext();

           //// EntryHistoryDataContext ev =new EntryHistoryDataContext();
           // var admiCounts = (from count in da.Administrators where count.AdministratorID == userId).Count();
           // var userCounts = (from count in da.Administrators where count.AdministratorID == userId).Count();
            
           // //判断是否存在且为普通用户
           // if (userCounts == 0 && userCounts != 0)
           // {
           //   //  var query = from history in ev.EntryHistoryView where history.UserID == userId select history;
           //     var queryModifiedHistory = from history in da.EntryModifiedHistories where history.UserID == userId select new { history.EntryID };
           //     var queryEvaluationHistory = from history in da.Evaluations where history.UserID == userId select new { history.EntryID };
           //     var queryCommentHistory = from history in da.Comments where history.UserID == userId select new { history.EntryID };
           //     var queryReleasedHistory = from history in da.Entries where history.UserID == userId select new { history.EntryID };

           //     List<int> modifiedList = new List<int>();

           //     foreach (var querys in queryModifiedHistory)
           //     {
           //         modifiedList.Add(querys.EntryID);
           //     }

           //     List<int> evaluationList = new List<int>();

           //     foreach (var querys in queryEvaluationHistory)
           //     {
           //         evaluationList.Add(querys.EntryID);
           //     }

           //     List<int> commentList = new List<int>();

           //     foreach (var querys in queryCommentHistory)
           //     {
           //         commentList.Add(querys.EntryID);
           //     }

           //     List<int> releasedList = new List<int>();

           //     foreach (var querys in queryReleasedHistory)
           //     {
           //         releasedList.Add(querys.EntryID);
           //     }

           //     mHistory.UserId = userId;
           //     mHistory.CommentEntryId = commentList;
           //     mHistory.EvaluateEntryId = evaluationList;
           //     mHistory.ModificatoryEntryId = modifiedList;
           //     mHistory.ReleasedEntryId = releasedList;

           //     return mHistory;
           // }

           // return null;

            //Model.History mHistory = new Model.History();

            //EntryHistoryDataContext ev = new EntryHistoryDataContext();

            //var admiCounts = (from admin in ev.EntryHistoryView where admin.AdministratorsID == userId select admin).Count();
            //var userCounts = (from user in ev.EntryHistoryView where user.AdministratorsID == userId select user).Count();

            //if (admiCounts == 0 && userCounts != 0)
            //{
            //    var queryHistory = from query in ev.EntryHistoryView where query.UserID == userId select query;

            //    List<int> modifiedList = new List<int>();
            //    List<int> commentList = new List<int>();
            //    List<int> releasedList = new List<int>();
            //    List<int> evaluationList = new List<int>();

            //    foreach (var history in queryHistory)
            //    {
            //        modifiedList.Add(history.EntryModifiedID);

            //        releasedList.Add(history.EntryReleasedID);

            //        commentList.Add(history.EntryCommentID);

            //        evaluationList.Add(history.EntryEvaluationID);
            //    }

            //    mHistory.ModificatoryEntryId = modifiedList;
            //    mHistory.ModificatoryEntryId = releasedList;
            //    mHistory.ModificatoryEntryId = commentList;
            //    mHistory.ModificatoryEntryId = evaluationList;

            //    return mHistory;
            //}
            // return null;

            Model.History mHistory = new Model.History();

            DALDataContext da = new DALDataContext();

            var entryCommment = from query in da.Comment where query.UserID == userId select query;
            var entryModified = from query in da.EntryModifiedHistory where query.UserID == userId select query;
            var entryReleased = from query in da.Entry where query.UserID == userId select query;
            var entryEvaluated = from query in da.Comment where query.UserID == userId select query;

            if (entryCommment.Count() != 0)
            {
                List<int> modifiedList = new List<int>();
                List<int> commentList = new List<int>();
                List<int> releasedList = new List<int>();
                List<int> evaluationList = new List<int>();

                mHistory.UserId = userId;

                foreach (var history in entryModified)
                {
                    modifiedList.Add(history.EntryID);
                }


                foreach (var history in entryCommment)
                {
                    commentList.Add(history.EntryID);
                }

                foreach (var history in entryReleased)
                {
                    releasedList.Add(history.EntryID);
                }

                foreach (var history in entryEvaluated)
                {
                    evaluationList.Add(history.EntryID);
                }

                mHistory.ModificatoryEntryId = modifiedList;
                mHistory.ReleasedEntryId = releasedList;
                mHistory.CommentEntryId = commentList;
                mHistory.EvaluateEntryId = evaluationList;

                return mHistory;
            }
            return null;
        }
    }
}
