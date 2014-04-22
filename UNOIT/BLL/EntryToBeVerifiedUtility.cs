using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data.Linq;
using System.IO;
using System.Data;

namespace BLL
{
    public class EntryToBeVerifiedUtility
    {
        //根据词条ID删除该EntryToBeVarified词条
        public static bool DeleteThisEntryToBeVarified(int entryId)
        {
            DALDataContext da = new DALDataContext();

            var entryToBeVarifieds = from entry in da.EntryToBeVerified where entry.EntryID == entryId select entry;

            if (entryToBeVarifieds.Count() != 0)
            {
                foreach (var entrys in entryToBeVarifieds)
                {
                    da.EntryToBeVerified.DeleteOnSubmit(entrys);
                    da.SubmitChanges();
                }

                return true;
            }

            return false;
        }

        //根据词条名删除该EntryToBeVarified词条
        public static bool DeleteThisEntryToBeVarified(string entryName)
        {
            DALDataContext da = new DALDataContext();

            var entryToBeVarifieds = from entry in da.EntryToBeVerified where entry.EntryName == entryName select entry;

            if (entryToBeVarifieds.Count() != 0)
            {
                foreach (var entrys in entryToBeVarifieds)
                {
                    da.EntryToBeVerified.DeleteOnSubmit(entrys);
                    da.SubmitChanges();
                }

                return true;
            }

            return false;
        }

        //创建一个词条
        public static bool CreateEntry(Model.EntryToBeVerified entry)
        {
            DALDataContext da = new DALDataContext();

            DAL.EntryToBeVerified dalEntry = new DAL.EntryToBeVerified();

            //查询创建的词条的catagoryID是否存在           

            var dentryQuerysCounts = (from entryQuery in da.Catagory where entryQuery.CatagoryID == entry.CatagoryId select entryQuery).Count();

            if (VerifyEntry(entry))
            {
                if (dentryQuerysCounts != 0)
                {
                    dalEntry = new DAL.EntryToBeVerified();

                    dalEntry.EntryName = entry.EntryName;
                    dalEntry.UserID = entry.UserId;
                    dalEntry.Contents = entry.Content;
                    dalEntry.CatagoryID = entry.CatagoryId;
                    dalEntry.ReleaseTime = entry.ReleasedTime;
                    dalEntry.EntrySource = entry.Source;

                    da.EntryToBeVerified.InsertOnSubmit(dalEntry);
                    da.SubmitChanges();

                    return true;
                }

                return false;
            }

            return false;
        }

        //用户编辑词条
        public static bool EditEntry(Model.EntryToBeVerified entry)
        {
            return CreateEntry(entry);
        }

        //验证词条是否符合规格
        public static bool VerifyEntry(Model.EntryToBeVerified entry)
        {
            //TODOUNOIT
            //StreamReader streamReader = 
            //    new StreamReader((Stream)File.OpenRead(@"C:\Users\TP\Desktop\sensitiveWords.txt"),
            //        System.Text.Encoding.GetEncoding("GB2312"));
            StreamReader streamReader = new StreamReader((Stream)File.OpenRead(@"data\sensitiveWords.txt"), System.Text.Encoding.GetEncoding("GB2312"));
            while (streamReader.Peek() >= 0)
            {
                string word = streamReader.ReadLine();
                if (entry.Content.Contains(word) || entry.EntryName.Contains(word))
                {
                    return false;
                }
            }
            return true;
        }

        //返回一条待审核词条记录，有管理员进行审核
        public static Model.EntryToBeVerified GetEntryToVarify()
        {
            DALDataContext da = new DALDataContext();

            Model.EntryToBeVerified dalEntry = new Model.EntryToBeVerified();
            //  DAL.EntryToBeVerified entryToBeVarifieds = da.EntryToBeVerified.FirstOrDefault();
            var entryToBeVarifieds = (from query in da.EntryToBeVerified select query).FirstOrDefault();

            if (entryToBeVarifieds != null)
            {
                dalEntry.CatagoryId = (int)entryToBeVarifieds.CatagoryID;
                dalEntry.Content = entryToBeVarifieds.Contents;
                dalEntry.EntryId = entryToBeVarifieds.EntryID;
                dalEntry.EntryName = entryToBeVarifieds.EntryName;
                dalEntry.ReleasedTime = entryToBeVarifieds.ReleaseTime;
                dalEntry.Source = entryToBeVarifieds.EntrySource;
                dalEntry.UserId = entryToBeVarifieds.UserID;

                // da.EntryToBeVerified.DeleteOnSubmit(entryToBeVarifieds);
               // da.SubmitChanges();
                return dalEntry;
            }
            else
            {
                return null;
            }
        }

        public static List<Model.EntryToBeVerified> GetAllEntriesToVarify()
        {
            DALDataContext da = new DALDataContext();

            List<Model.EntryToBeVerified> dalEntryList = new List<Model.EntryToBeVerified>();

            var entryToBeVarifiedsResults = from query in da.EntryToBeVerified select query;

            if (entryToBeVarifiedsResults.Count() != 0)
            {
                foreach (var query in entryToBeVarifiedsResults)
                {
                    Model.EntryToBeVerified entry = new Model.EntryToBeVerified();

                    entry .CatagoryId= (int)query.CatagoryID;
                    entry.Content = query.Contents;
                    entry.EntryId = query.EntryID;
                    entry.EntryName = query.EntryName;
                    entry.ReleasedTime = query.ReleaseTime;
                    entry.Source = query.EntrySource;
                    entry.UserId = query.UserID;

                    dalEntryList.Add(entry);
                 }
                return dalEntryList;
            }
            else
            {
                return null;
            }
        }

        //返回一条待审核词条记录，有管理员进行审核 按标号
        public static Model.EntryToBeVerified GetEntryToVarifyById(int entryId)
        {
            DALDataContext da = new DALDataContext();

            Model.EntryToBeVerified dalEntry = new Model.EntryToBeVerified();
            //  DAL.EntryToBeVerified entryToBeVarifieds = da.EntryToBeVerified.FirstOrDefault();
            var entryToBeVarifieds = (from query in da.EntryToBeVerified where query.EntryID == entryId select query).FirstOrDefault();

            if (entryToBeVarifieds != null)
            {
                dalEntry.CatagoryId = (int)entryToBeVarifieds.CatagoryID;
                dalEntry.Content = entryToBeVarifieds.Contents;
                dalEntry.EntryId = entryToBeVarifieds.EntryID;
                dalEntry.EntryName = entryToBeVarifieds.EntryName;
                dalEntry.ReleasedTime = entryToBeVarifieds.ReleaseTime;
                dalEntry.Source = entryToBeVarifieds.EntrySource;
                dalEntry.UserId = entryToBeVarifieds.UserID;

                // da.EntryToBeVerified.DeleteOnSubmit(entryToBeVarifieds);
                //da.SubmitChanges();
                return dalEntry;
            }
            else
            {
                return null;
            }
        }

        //返回一条待审核词条记录，有管理员进行审核 按词条名
        public static Model.EntryToBeVerified GetEntryToVarifyByEntryName(string entryName)
        {
            DALDataContext da = new DALDataContext();

            Model.EntryToBeVerified dalEntry = new Model.EntryToBeVerified();
            //  DAL.EntryToBeVerified entryToBeVarifieds = da.EntryToBeVerified.FirstOrDefault();
            var entryToBeVarifieds = (from query in da.EntryToBeVerified where query.EntryName == entryName select query).FirstOrDefault();

            if (entryToBeVarifieds != null)
            {
                dalEntry.CatagoryId = (int)entryToBeVarifieds.CatagoryID;
                dalEntry.Content = entryToBeVarifieds.Contents;
                dalEntry.EntryId = entryToBeVarifieds.EntryID;
                dalEntry.EntryName = entryToBeVarifieds.EntryName;
                dalEntry.ReleasedTime = entryToBeVarifieds.ReleaseTime;
                dalEntry.Source = entryToBeVarifieds.EntrySource;
                dalEntry.UserId = entryToBeVarifieds.UserID;

                // da.EntryToBeVerified.DeleteOnSubmit(entryToBeVarifieds);
                //da.SubmitChanges();
                return dalEntry;
            }
            else
            {
                return null;
            }
        }

        //返回一条待审核词条记录的Contents，有管理员进行审核 按词条名
        public static string GetEntryContentsByEntryName(string entryName)
        {
            DALDataContext da = new DALDataContext();

            string contents = "";
            var entryToBeVarifieds = (from query in da.EntryToBeVerified where query.EntryName == entryName select query).FirstOrDefault();

            if (entryToBeVarifieds != null)
            {
                contents = entryToBeVarifieds.Contents;

                return contents;
            }
            else
            {
                return null;
            }
        }

        public static DataTable TranslateToTable(Model.EntryToBeVerified entry)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EntryName");
            dt.Columns.Add("Contents");

            DataRow dr = dt.NewRow();
            dr["EntryName"] = entry.EntryName;
            dr["Contents"] = entry.Content;

            dt.Rows.Add(dr);

            return dt;

        }
    }
}
