using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class EntryToBeVerified
    {
        private int catagoryId = -1;

        public int CatagoryId
        {
            get { return catagoryId; }
            set { catagoryId = value; }
        }
        private string entryName = "";

        public string EntryName
        {
            get { return entryName; }
            set { entryName = value; }
        }
        private string content = "";

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private int userId = -1;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string source;

        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        private DateTime releasedTime;

        public DateTime ReleasedTime
        {
            get { return releasedTime; }
            set { releasedTime = value; }
        }
        private int entryId;

        public int EntryId
        {
            get { return entryId; }
            set { entryId = value; }
        }
    }
}
