using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Message
    {
        private int messageID;

        public int MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }
        private string sender;

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        private string receiver;

        public string Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }
        private DateTime sendTime = DateTime.Now;

        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }

        private string contents;

        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }
    }
}
