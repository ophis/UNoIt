using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;

namespace UnoitWebService
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool ValidateUserName(string name)
        {
            return BLL.UserUtility.IsUserExist(name);
        }

        [WebMethod]
        public LoginStateFlag Login(string userName, string password)
        {
            return UserUtility.Login(userName,password);
        }

        [WebMethod]
        public Model.Entry SearchEntryByName(string entryName)
        {
            return EntryUtility.SearchEntryByName(entryName);
        }

        [WebMethod]
        public Model.Entry SearchEntryByEntryId(int entryId)
        {
            return EntryUtility.SearchEntryByEntryId(entryId);
        }

        [WebMethod]
        public List<Model.Entry> SearchEntriesByKeywords(string keyword)
        {
            return EntryUtility.SearchEntriesByKeywords(keyword);
        }
        [WebMethod]
        public bool Support(string entryName, string userName)
        {
            int entryId = EntryUtility.GetEntryIdByName(entryName);
            return EntryUtility.Support(entryId, userName);
        }
        [WebMethod]
        public bool DisSupport(string entryName, string userName)
        {
            int entryId = EntryUtility.GetEntryIdByName(entryName);
            return EntryUtility.DisSupport(entryId, userName);
        }
        [WebMethod]
        public bool EditEntry(Model.EntryToBeVerified newEntry)
        {
            return EntryToBeVerifiedUtility.EditEntry(newEntry);
        }
        [WebMethod]
        public int GetUserIdByName(string userName)
        {
            return UserUtility.GetUserIdByName(userName);
        }
    }
}
