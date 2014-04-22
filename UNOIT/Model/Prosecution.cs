using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Prosecution
    {
        private DateTime proscuteTime;

        public DateTime ProscuteTime
        {
            get { return proscuteTime; }
            set { proscuteTime = value; }
        }
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private int isEntry;

        public int IsEntry
        {
            get { return isEntry; }
            set { isEntry = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
