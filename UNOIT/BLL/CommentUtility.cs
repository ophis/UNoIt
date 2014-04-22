using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CommentUtility
    {
        //TODO 判断是否是已登录用户
        //添加评论，只有用户有权限评论。调用该方法前要加判断。
        public static bool AddComment(Model.Comment comment)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            DAL.Comment newComment = new DAL.Comment();

            ////判断评价的词条是否存在 而且用户也存在
            //var queryResultsCounts = (from query in dataContext.Comment 
            //                          where (query.EntryID == comment.EntryId && query.UserID == comment.UserId) 
            //                          select query).Count();

            //if (queryResultsCounts != 0)
            //{
                
                 newComment.CommentTime = DateTime.Now;
                 newComment.CommentContents = comment.Content;
                 newComment.EntryID = comment.EntryId;
                 newComment.UserID = comment.UserId;

                dataContext.Comment.InsertOnSubmit(newComment);
                dataContext.SubmitChanges();
                return true;
            //} 
            //else
            //{
            //    return false;
            //}
            
        }
        
       //TODO
        public static bool DeleteComment(int commentId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();            
            //var comment = dataContext.Comments.Single(p => p.CommentID == commentId);
            var queryResults = from query in dataContext.Comment where query.CommentID == commentId select query;

            if (queryResults.Count() != 0)
            {
                foreach (var query in queryResults)
                {
                    dataContext.Comment.DeleteOnSubmit(query);
                    dataContext.SubmitChanges();
                   
                }  
                return true;
            } 
            else
            {
                return false;
            }            
        }

        public static bool DeleteCommentByEntryID(int entryID)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
           var queryResults = from query in dataContext.Comment where query.EntryID == entryID select query;

            if (queryResults.Count() != 0)
            {
                foreach (var query in queryResults)
                {
                    dataContext.Comment.DeleteOnSubmit(query);
                    dataContext.SubmitChanges();

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteComment(string userName)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            //var comment = dataContext.Comments.Single(p => p.CommentID == commentId);
           // var queryResults = from query in dataContext.Comment where query.CommentID == commentId select query;

            var queryResults = (from o in dataContext.Comment
                                join u in dataContext.Users
                                on o.UserID equals u.UserID
                                where u.UserName == userName
                                select o).FirstOrDefault();

            if (queryResults != null)
            {
                if (DeleteComment(queryResults.CommentID))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        //TODO
        public static List<Model.Comment> GetCommentsByEntryId(int entryId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var allComment = from u in dataContext.Comment
                             where u.EntryID == entryId
                             orderby u.CommentTime descending
                             select u;

            List<Model.Comment> list = new List<Model.Comment>();
            if (allComment.Count() != 0)
            {
                foreach (var row in allComment)
                {
                    Model.Comment com = new Model.Comment();
                    com.CommentId = row.CommentID;
                    com.Content = row.CommentContents;
                    com.Time = row.CommentTime;
                    com.UserId = row.UserID;
                    com.EntryId = row.EntryID;
                    list.Add(com);
                 }
            } 
            else
            {
                return null;
            }

            return list;
        }

        public static Model.Comment GetCommentsByCommentId(int commentId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var allComment = (from u in dataContext.Comment
                             where u.CommentID == commentId
                             select u).FirstOrDefault();

            if (allComment != null)
            {
                Model.Comment commment = new Model.Comment();
                commment.CommentId = commentId;
                commment.Content = allComment.CommentContents;
                commment.EntryId = allComment.EntryID;
                commment.UserId = allComment.UserID;
                commment.Time = allComment.CommentTime;

                return commment;
            }
            else
            {
                return null;
            }
        }

        public static string GetUserNameByCommentId(int commentId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();

            var queryResults = (from u in dataContext.Users
                               join o in dataContext.Comment
                               on u.UserID equals o.UserID
                               where o.CommentID == commentId
                               select u).FirstOrDefault();

            if (queryResults != null)
            {
                return queryResults.UserName;
            }
            else
                return null;
            

        }

        public static List<int> GetEntryIdByUserId(int userId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var entriesId = from u in dataContext.Comment
                            where u.UserID == userId
                            select new { id = u.EntryID };

            List<int> list = new List<int>();
            foreach (var row in entriesId)
            {
                list.Add(row.id);

            }
            return list;
        }

        public static int GetEntryIdByCommentsID(int commentID)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var entryResults = (from u in dataContext.Comment
                            where u.CommentID == commentID
                            select u).FirstOrDefault();

            if (entryResults != null)
            {
                return (int)entryResults.EntryID;
            }
            else
            {
                return -1;
            }
        }

        public static List<Model.Comment> GetCommentByUserId(int userId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            List<Model.Comment> list = new List<Model.Comment>();

            var comments = from u in dataContext.Comment
                           where u.UserID == userId
                           select u;
            foreach (var row in comments)
            {
                Model.Comment comment = new Model.Comment();
                comment.CommentId = row.CommentID;
                comment.Content = row.CommentContents;
                comment.EntryId = row.EntryID;
                comment.Time = row.CommentTime;
                comment.UserId = row.UserID;
                list.Add(comment);
            }

            if (list.Count == 0)
                return null;
            else
                return list;
        }
    }
}
