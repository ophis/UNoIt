using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Comment
    {
        private DateTime time;

        public DateTime Time
        {
            get { return time; }

            set { time = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private int userId = -1;

        public int UserId
        {
            get { return userId; }
            set { userId = value;}
        }
        private int entryId = -1;

        public int EntryId
        {
            get { return entryId; }
            set { entryId = value; }
        }
        private int commentId = -1;

        public int CommentId
        {
            get { return commentId; }
            set { commentId = value; }
        }
    }
}
