using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientBLL.UnoitServer;

namespace ClientBLL
{
    public class ClientAgent
    {
        public static UnoitServer.UserService server = new UnoitServer.UserService();
        public static string username;
        public static LoginStateFlag Login(string username, string password)
        {
            return server.Login(username,password);
            
        }

        public static List<Entry> Search(string entry)
        {
            List<Entry> list = new List<Entry>();
            Entry entrySearchedByName = server.SearchEntryByName(entry);
            if (entrySearchedByName != null)
            {
                list.Add(entrySearchedByName);
            }
            Entry[] list2 = server.SearchEntriesByKeywords(entry);
            foreach (Entry e in list2)
            {
                list.Add(e);
            }
            return list;
        }
    }
}
