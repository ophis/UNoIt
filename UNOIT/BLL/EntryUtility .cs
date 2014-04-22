using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using Lucene.Net;
using Lucene.Net.Analysis;
using Lucene.China;

namespace BLL
{
    public class EntryUtility
    {
       //根据entry编号删除entry，且只有管理员和词条发布者有权限
        public static bool DeleteEntryById(int entryId)
        {
            DALDataContext da = new DALDataContext();
            
            //删除Entry表中的该编号的词条
            var entryQuerys = from query in da.Entry where query.EntryID == entryId select query;

            //判断是否存在该词条
            if (entryQuerys.Count() != 0)
            {
                //级联删除对该词条的评论
                var commentQuery = from query in da.Comment where query.EntryID == entryId select query;
                //判断是否存在该词条
                if (commentQuery.Count() != 0)
                {
                    foreach (var queryResults in commentQuery)
                    {
                        da.Comment.DeleteOnSubmit(queryResults);
                        da.SubmitChanges();
                    }
                }

                //级联删除对该词条的评价
                var evaluationQuery = from query in da.Evaluation where query.EntryID == entryId select query;
                //判断是否存在该词条
                if (evaluationQuery.Count() != 0)
                {
                    foreach (var queryResults in evaluationQuery)
                    {
                        da.Evaluation.DeleteOnSubmit(queryResults);
                        da.SubmitChanges();
                    }
                }

                //级联删除对该词条的举报
                var prosecutionQuery = from query in da.Prosecution
                                       where  query.IsEntry == 1 && query.ID == entryId
                                       select query;
                //判断是否存在该词条
                if (prosecutionQuery.Count() != 0)
                {
                    foreach (var queryResults in prosecutionQuery)
                    {
                        da.Prosecution.DeleteOnSubmit(queryResults);
                        da.SubmitChanges();
                    }
                }

                ////级联删除对该词条的修改历史
                //var entryHistoryResults = from query in da.EntryModifiedHistory
                //                          where query.EntryID == entryId
                //                          select query;
                ////判断是否存在该词条
                //if (entryHistoryResults.Count() != 0)
                //{
                //    foreach (var queryResults in entryHistoryResults)
                //    {
                //        da.EntryModifiedHistory.DeleteOnSubmit(queryResults);
                //        da.SubmitChanges();
                //    }
                //}

                //级联删除对该词条的键值对
                var entryMenuResults = from query in da.EntryKeywordMenu
                                          where query.EntryID == entryId
                                          select query;
                //判断是否存在该词条
                if (entryMenuResults.Count() != 0)
                {
                    foreach (var queryResults in entryMenuResults)
                    {
                        da.EntryKeywordMenu.DeleteOnSubmit(queryResults);
                        da.SubmitChanges();
                    }
                }

                //级联删除对该词条的Modified
                var entryModifidResults = from query in da.EntryModifiedHistory
                                          where query.EntryID == entryId
                                          select query;
                //判断是否存在该词条
                if (entryModifidResults.Count() != 0)
                {
                    foreach (var queryResults in entryModifidResults)
                    {
                        da.EntryModifiedHistory.DeleteOnSubmit(queryResults);
                        da.SubmitChanges();
                    }
                }

                foreach (var queryResults in entryQuerys)
                {
                    da.Entry.DeleteOnSubmit(queryResults);
                    da.SubmitChanges();
                }
                              
                return true;
            }        
           
            return false;
        }

        public static bool DeleteEntryByEntryName(string entryName)
        {
            DALDataContext da = new DALDataContext();

            //删除Entry表中的该词条的词条
            var entryQuerys = (from query in da.Entry where query.EntryName == entryName select new { query.EntryID }).FirstOrDefault();

            if (entryQuerys != null)
            {
                if (DeleteEntryById(entryQuerys.EntryID))
                {
                    return true;
                }

                return false;
            }
            else
                return false;
        }


        public static List<string> GetAllReleaseEntriesByUserId(int id)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var entriesName = from u in dataContext.Entry
                              where u.UserID == id
                              select new { name = u.EntryName};
            List<string> entriesNameList = new List<string>();
            foreach (var row in entriesName)
            {
                entriesNameList.Add(row.name);
            }
            return entriesNameList;
        }
        public static Model.Entry SearchEntryByName(string entryName)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();            
            DAL.Entry theEntry = dataContext.Entry.FirstOrDefault(p => p.EntryName == entryName);
            if (theEntry == null)
            {
                return null;
            } 
            else
            {
                return TransEntryTableToEntry(theEntry);
            }
        }

        public static Model.Entry SearchEntryByEntryId(int entryId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            DAL.Entry theEntry = dataContext.Entry.FirstOrDefault(p => p.EntryID == entryId);
            if (theEntry == null)
            {
                return null;
            }
            else
            {
                return TransEntryTableToEntry(theEntry);
            }
        }

        public static List<Model.Entry> GetAllEntriesByUserID(int userID)
        {
            DALDataContext dataContext = new DALDataContext();

            var queryResults = from query in dataContext.Entry where query.UserID == userID select query;

            List<Model.Entry> entryList = new List<Model.Entry>();

            if (queryResults.Count() != 0)
            {

                foreach (var query in queryResults)
                {
                    Model.Entry entry = new Model.Entry();

                    entry.CatagoryId = (int)query.CategoryID;
                    entry.ClickSum = (int)query.ClickSum;
                    entry.Content = query.Contents;
                    entry.DigSum = (int)query.DigSum;
                    entry.EntryId = query.EntryID;
                    entry.EntryName = query.EntryName;
                    entry.LastModification = (DateTime)query.LastModifiedTime;
                    entry.ReleasedTime = query.ReleasedTime;
                    entry.Source = query.EntrySource;
                    entry.UpSum = (int)query.UpSum;

                    entryList.Add(entry);
                }

                return entryList;
            }
            else
            {
                return null;
            }
        }

        private static Model.Entry TransEntryTableToEntry(DAL.Entry theEntry)
        {
            Model.Entry entry = new Model.Entry();
            entry.CatagoryId = (int)theEntry.CategoryID;
            entry.ClickSum = (int)theEntry.ClickSum;
            entry.Content = theEntry.Contents;
            entry.DigSum = (int)theEntry.DigSum;
            entry.EntryId = theEntry.EntryID;
            entry.EntryName = theEntry.EntryName;
            entry.Keywords = GetEntryKeywordList(theEntry.EntryID);
            entry.LastModification = (DateTime)theEntry.LastModifiedTime;
            entry.ReleasedTime = theEntry.ReleasedTime;
            entry.Source = theEntry.EntrySource;
            entry.UpSum = (int)theEntry.UpSum;
            entry.UserId = theEntry.UserID;

            return entry;
        }

        public static string GetCatagoryNameById(int id)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var catagory = (from u in dataContext.Catagory
                            where u.CatagoryID == id
                            select u).FirstOrDefault();
            return catagory.CatagoryName;
        }

        public static int GetUpCatagoryIdById(int id)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var catagory = (from u in dataContext.Catagory
                            where u.CatagoryID == id
                            select u).FirstOrDefault();
            return Convert.ToInt32(catagory.UpperCatagoryID);
        }

        //用户评价成功返回true,如果之前已经评价过，返回false.
        private static bool UpdateSupportSum(int entryId, string userName, bool flag)
        {
            DALDataContext dataContext = new DALDataContext();

            var num = (from u in dataContext.Evaluation
                       where u.EntryID == entryId && u.UserID == UserUtility.GetUserIdByName(userName)
                       select u).Count();
            if (num != 0)
            {
                return false;
            }

            DAL.Entry entryToUpdate = dataContext.Entry.FirstOrDefault(p => p.EntryID == entryId);
            if (flag)
            {
                entryToUpdate.UpSum = entryToUpdate.UpSum + 1;
                dataContext.SubmitChanges();
            }
            else
            {
                entryToUpdate.DigSum = entryToUpdate.DigSum + 1;
                dataContext.SubmitChanges();
            }
            

            DAL.Evaluation evaluation = new DAL.Evaluation();
            evaluation.EntryID = entryId;
            evaluation.UserID = UserUtility.GetUserIdByName(userName);
            evaluation.EvaluateTime = DateTime.Now;

            dataContext.Evaluation.InsertOnSubmit(evaluation);
            dataContext.SubmitChanges();

            return true;
        }

        //按目录和关键字搜索词条。 
        //TODO 搜索出来的词条ID要做去重判断。
        public static List<Model.Entry> SearchEntriesByKeywords(string keyword)
        {
            List<Model.Entry> entryList = new List<Model.Entry>();               

            //把用户的输入字符串的关键字提取出来。
            List<string> keywordList = AutoMatchEntryKeywords(keyword);

            DAL.DALDataContext dataContext = new DAL.DALDataContext();

            var matchEntryId = (from u in dataContext.EntryKeywordMenu
                                join o in dataContext.Keywords
                                on u.KeywordID equals o.KeywordID
                                where keywordList.Contains(o.KeywordName)
                                select new { entryId = u.EntryID}).Distinct();
           
            foreach (var row in matchEntryId)
            {
                DAL.Entry theEntry = dataContext.Entry.FirstOrDefault(p => p.EntryID == row.entryId);                               
                entryList.Add(TransEntryTableToEntry(theEntry));                
            }

            return entryList;
        }

        //根据第二层目录的ID号搜索词条
        public static List<string> SearchEntriesByCatagoryId(int catagoryId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var entryName = from u in dataContext.Entry
                            where u.CategoryID == catagoryId
                            select u.EntryName;

            List<string> entryList = new List<string>();
            foreach(var row in entryName)
            {
                entryList.Add(row);
            }
            return entryList;
        }

        public static bool Support(int entryId, string userName)
        {
            return UpdateSupportSum(entryId, userName, true);
        }

        public static bool DisSupport(int entryId, string userName)
        {
            return UpdateSupportSum(entryId, userName, false);
        }

        public static bool AgreeThisEntry(Model.EntryToBeVerified entry)
        {
            DAL.Entry newEntry = new DAL.Entry();
            newEntry.EntryName = entry.EntryName;
            newEntry.UserID = entry.UserId;
            newEntry.Contents = entry.Content;
            newEntry.CategoryID = entry.CatagoryId;
            newEntry.ReleasedTime = entry.ReleasedTime;
            newEntry.LastModifiedTime = DateTime.Now;
            newEntry.EntrySource = entry.Source;
            newEntry.ClickSum = 0;
            newEntry.DigSum = 0;
            newEntry.UpSum = 0;

            DALDataContext dataContext = new DALDataContext();
            dataContext.Entry.InsertOnSubmit(newEntry);
            dataContext.SubmitChanges();

            int theEntryId = GetEntryIdByName(entry.EntryName);

            List<string> keywordList = AutoMatchEntryKeywords(entry.Content);
            foreach (string keyword in keywordList)
            {
                int keywordId = GetKeywordIdByKeyword(keyword);
                if (-1 == keywordId)
                {
                    DAL.Keywords keywordInfo = new DAL.Keywords();
                    keywordInfo.KeywordName = keyword;
                    dataContext.Keywords.InsertOnSubmit(keywordInfo);
                    dataContext.SubmitChanges();

                    keywordId = GetKeywordIdByKeyword(keyword);
                }
                DAL.EntryKeywordMenu entryKeyMenu = new DAL.EntryKeywordMenu();
                entryKeyMenu.KeywordID = keywordId;
                entryKeyMenu.EntryID = theEntryId;

                var checkIsExist = (from u in dataContext.EntryKeywordMenu
                                    where u.EntryID == entryKeyMenu.EntryID 
                                       && u.KeywordID == entryKeyMenu.KeywordID
                                    select u).FirstOrDefault();
                if (checkIsExist == null)
                {
                    dataContext.EntryKeywordMenu.InsertOnSubmit(entryKeyMenu);                  
                }
            }
            dataContext.SubmitChanges();
            return true;
        }

        public static bool DisagreeThisEntry()
        {
            return true;
        }

        //寻找某个关键字是否存在。存在返回ID，否则返回-1 。
        private static int GetKeywordIdByKeyword(string keyword)
        {
            DALDataContext dataContext = new DALDataContext();
            var word = (from u in dataContext.Keywords
                        where u.KeywordName == keyword
                        select u).FirstOrDefault();
            if (word != null)
            {
                return word.KeywordID;
            }
            else
            {
                return -1;
            }
        }

        //TODO 如果速度过慢，用概率算法减少每个词条的关键词个数来提高速度。
        //用分词算法提取出词条的关键字。
        public static List<string> AutoMatchEntryKeywords(string content)
        {
            List<string> list = new List<string>();

            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);
            string t1 = "";
            Analyzer analyzer = new Lucene.China.ChineseAnalyzer();            
            System.IO.StringReader sr = new System.IO.StringReader(content);
            TokenStream stream = analyzer.TokenStream(null, sr);

            Token t = stream.Next();
            while (t != null)
            {
                t1 = t.ToString();
                t1 = t1.Replace("(", "");
                char[] separator = { ',' };
                t1 = t1.Split(separator)[0];

                if (t1.Length > 1)
                {
                    if (list.Contains(t1) == false)
                    {
                        list.Add(t1);
                    }
                }

                t = stream.Next();
            }
            return list;
        }


        //根据词条名得到词条的ID。如果该词条不存在，返回-1。
        public static int GetEntryIdByName(string entryName)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            DAL.Entry entry = dataContext.Entry.FirstOrDefault(p => p.EntryName == entryName);
            if (entry == null)
            {
                return -1;
            } 
            else
            {
                return entry.EntryID;
            }            
        }

        
        public static string GetEntryNameById(int entryId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            DAL.Entry entry = dataContext.Entry.FirstOrDefault(p => p.EntryID == entryId);
            
            if (entry == null)
            {
                return null;
            }
            else
            {
                return entry.EntryName;
            }
        }

        private static List<string> GetEntryKeywordList(int entryId)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            List<string> keywordList = new List<string>();
            var keyWords = from u in dataContext.EntryKeywordMenu
                           join o in dataContext.Keywords
                           on u.KeywordID equals o.KeywordID
                           where u.EntryID == entryId
                           select new { KeywordName = o.KeywordName };
            foreach (var row in keyWords)
            {
                keywordList.Add(row.KeywordName);
            }
            return keywordList;                                                 
        }
        public static List<Model.Entry> GetHotEntries()
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var hotEntries = (from u in dataContext.Entry
                              orderby (u.UpSum - u.DigSum) descending
                              select u).Take(ConstSummmary.HOTENTRIESSUM);
            List<Model.Entry> list = new List<Model.Entry>();
            foreach (var row in hotEntries)
            {
                Model.Entry hotEntry = new Model.Entry();
                hotEntry.CatagoryId = (int)row.CategoryID;
                hotEntry.ClickSum = (int)row.ClickSum;
                hotEntry.DigSum = (int)row.DigSum;
                hotEntry.EntryId = row.EntryID;
                hotEntry.EntryName = row.EntryName;
                hotEntry.Keywords = GetEntryKeywordList(row.UserID);
                hotEntry.LastModification = (DateTime)row.LastModifiedTime;
                hotEntry.UpSum = (int)row.UpSum;
                hotEntry.UserId = row.UserID;
                hotEntry.ReleasedTime = row.ReleasedTime;
                hotEntry.Source = row.EntrySource;
                hotEntry.Content = row.Contents;

                list.Add(hotEntry);
            }

            return list;
        }

        public static int GetCatagoryIdByName(Model.Catagory entryCatagory)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var catagory = (from u in dataContext.Catagory
                            where  entryCatagory.CatagoryName.Equals(u.CatagoryName)
                            select u).FirstOrDefault();
            if (catagory != null)
            {
                return catagory.CatagoryID;
            }
            else
            {
                return -1;
            }
        }
        public static List<Model.Catagory> GetAllChildCatagories(Model.Catagory entryCatagory)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var catagories = from u in dataContext.Catagory
                             where u.UpperCatagoryID == GetCatagoryIdByName(entryCatagory)
                             select u;

            List<Model.Catagory> list = new List<Model.Catagory>();
            foreach (var row in catagories)
            {
                Model.Catagory childCatagory = new Model.Catagory();
                childCatagory.CatagoryId = row.CatagoryID;
                childCatagory.CatagoryName = row.CatagoryName;
                list.Add(childCatagory);
            }

            return list;
        }

        public static bool UpdateEntry(Model.EntryToBeVerified entry)
        {
            DALDataContext da = new DALDataContext();

            var queryResults = (from query in da.EntryToBeVerified where query.EntryName == entry.EntryName select query).FirstOrDefault();
            
            //有该词条
            if (queryResults != null)
            {
                EntryUtility.DeleteEntryByEntryName(queryResults.EntryName);
                EntryUtility.AgreeThisEntry(entry);
                return true;              
            }
            else
            {
                EntryUtility.AgreeThisEntry(entry);
            }
            return false;
        }

        public static string GetEntryContentsByID(int entryID)
        {
            DALDataContext datacontext = new DALDataContext();

            var queryContents = (from query in datacontext.Entry where query.EntryID == entryID select query).FirstOrDefault();

            if (queryContents != null)
            {
                return queryContents.Contents;
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetAllEntriesName()
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            List<string> list = new List<string>();

            var entriesName = from u in dataContext.Entry
                              select new { entryName = u.EntryName };
            foreach (var row in entriesName)
            {
                list.Add(row.entryName);
            }

            return list;
        }
    }
}
