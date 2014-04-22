using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public abstract class AbstractUser
    {
        protected string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        protected string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        protected int passwordErrSum;

        public int PasswordErrSum
        {
            get { return passwordErrSum; }
            set { passwordErrSum = value; }
        }
        protected DateTime freezeTime;

        public DateTime FreezeTime
        {
            get { return freezeTime; }
            set { freezeTime = value; }
        }
        protected int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
