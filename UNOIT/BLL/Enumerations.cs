using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public enum LoginStateFlag { USERSUCCESS, ADMINSUCCESS, PASSWORDERROR, USERNAMENOTEXIST, NONACTIVATED, ACCOUNTFREEZE };
    public enum RegistStateFlag { SUCCESS, ACCOUNTEXIST, EMAILEXIST, PASSWORDUNMATCH };
    public enum NotifyType { ENTRYBEDELETED, COMMENTBEDELETED, ENTRYPASS, ENTRYUNPASS };    
}
