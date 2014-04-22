using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Notify
    {
        private DateTime time = DateTime.Now;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
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
        private int notifyId = -1;

        public int NotifyId
        {
            get { return notifyId; }
            set { notifyId = value; }
        }      
    }
}
