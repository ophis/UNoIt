using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class PersonalInformationUtility
    {
        //更新个人信息，只有用户可以更新个人信息。
        public static bool UpdatePersonalInformation(string userName, Model.PersonalInformation info)
        {
            DALDataContext dataContext = new DALDataContext();
            DAL.Users userToUpdateInfo = dataContext.Users.FirstOrDefault(p => p.UserName == userName);

            if (userToUpdateInfo == null)
            {
                return false;
            }

            userToUpdateInfo.Birthdate = info.Birthdate;
            userToUpdateInfo.City = info.City;
            userToUpdateInfo.Email = info.Email;
            userToUpdateInfo.Gender = info.Gender;
            userToUpdateInfo.PhotoUrl = info.PhotoUrl;
            userToUpdateInfo.Position = info.Position;
            userToUpdateInfo.Province = info.Province;
            userToUpdateInfo.SkilledField = info.SkilledField;

            dataContext.SubmitChanges();
            return true;
        }

        public static Model.PersonalInformation GetPersonalInfoByUserName(string userName)
        {
            DALDataContext dataContext = new DALDataContext();

            var queryResults = (from query in dataContext.Users where query.UserName == userName select query).FirstOrDefault();

            if (queryResults != null)
            {
                Model.PersonalInformation person = new Model.PersonalInformation();

                person.Birthdate = queryResults.Birthdate;
                person.City = queryResults.City;
                person.Email = queryResults.Email;
                person.Gender = queryResults.Gender;
                person.PhotoUrl = queryResults.PhotoUrl;
                person.Position = queryResults.Position;
                person.Province = queryResults.Province;
                person.SkilledField = queryResults.SkilledField;

                return person;
            }
            else
            {
                return null;
            }
        }
        //public static DataTable ShowPersonalInformation(string userName)
        //{
        //    DALDataContext dataContext = new DALDataContext();

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("UserName");
        //    dt.Columns.Add("Gender");
        //    dt.Columns.Add("City");
        //    dt.Columns.Add("Province");
        //    dt.Columns.Add("Birthdate");
        //    dt.Columns.Add("Score");
        //    dt.Columns.Add("IllegalCounts");
        //    dt.Columns.Add("SkilledField");
        //    dt.Columns.Add("Email");
        //    dt.Columns.Add("Position");

        //    var queryInfo = (from query in dataContext.Users where query.UserName == userName select query).FirstOrDefault();

        //    if (queryInfo != null)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["UserName"] = queryInfo.UserName;

        //        switch (queryInfo.Gender)
        //        {
        //            case 1:
        //                dr["Gender"] = "Male";
        //                break;
        //            case 0:
        //                dr["Gender"] = "Secret";
        //                break;
        //            case -1:
        //                dr["Gender"] = "Female";
        //                break;
        //        }

        //        dr["City"] = queryInfo.City;
        //        dr["Province"] = queryInfo.Province;
        //        dr["birthdate"] = queryInfo.Birthdate;
        //        dr["Score"] = queryInfo.Score;
        //        dr["IllegalCounts"] = queryInfo.IllegalCounts;
        //        dr["SkilledField"] = queryInfo.SkilledField;
        //        dr["Email"] = queryInfo.Email;
        //        dr["Position"] = queryInfo.Position;


        //        dt.Rows.Add(dr);

        //        return dt;
        //    }
        //    else
        //    {
        //        return null;
        //    }
    }
}

