using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Entry : EntryToBeVerified
    {
        private List<string> keywords;

        public List<string> Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }
        private int clickSum;

        public int ClickSum
        {
            get { return clickSum; }
            set { clickSum = value; }
        }
        private DateTime lastModification;

        public DateTime LastModification
        {
            get { return lastModification; }
            set { lastModification = value; }
        }
        private int digSum;

        public int DigSum
        {
            get { return digSum; }
            set { digSum = value; }
        }
        private int upSum;

        public int UpSum
        {
            get { return upSum; }
            set { upSum = value; }
        }
    }
}
