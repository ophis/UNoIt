using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class History
    {
        private List<int> releasedEntryId;

        public List<int> ReleasedEntryId
        {
            get { return releasedEntryId; }
            set { releasedEntryId = value; }
        }
        private List<int> modificatoryEntryId;

        public List<int> ModificatoryEntryId
        {
            get { return modificatoryEntryId; }
            set { modificatoryEntryId = value; }
        }
        private List<int> evaluateEntryId;

        public List<int> EvaluateEntryId
        {
            get { return evaluateEntryId; }
            set { evaluateEntryId = value; }
        }
        private int userId;

        public int UserId
        {
            get { return userId; }
            set
            {
                if (value > 0)
                {
                    userId = value;
                }
                else
                {
                    userId = -1;
                }
            }
                
        }
        private List<int> commentEntryId;

        public List<int> CommentEntryId
        {
            get { return commentEntryId; }
            set { commentEntryId = value; }
        }
    }
}
