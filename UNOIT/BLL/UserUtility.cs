using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data.Linq;
using Model;


namespace BLL
{
    public class UserUtility
    {
        //用户登陆时，根据不同情况返回不同的枚举值。
        public static LoginStateFlag Login(string userName, string password)
        {

            if (IsUser(userName))
            {
                return UserLogin(userName, password);
            }
            else
            {
                return AdminLogin(userName, password);
            }
        }



        private static LoginStateFlag AdminLogin(string userName, string password)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            DAL.Administrators admin = dataContext.Administrators.FirstOrDefault(p => p.AdministratorName == userName);
            if (admin == null)
            {
                return LoginStateFlag.USERNAMENOTEXIST;
            }
            else
            {
                if (admin.Password == password)
                {
                    return LoginStateFlag.ADMINSUCCESS;
                }
                else
                {
                    return LoginStateFlag.PASSWORDERROR;
                }
            }
        }


        private static LoginStateFlag UserLogin(string userName, string password)
        {
            DALDataContext dataContext = new DALDataContext();
            var user = from u in dataContext.Users
                       where u.UserName == userName
                       select new
                       {
                           userName = u.UserName,
                           password = u.Password,
                           isActivated = u.IsActivated,
                           frozenTime = u.FrozenTime,
                           passwordErrorCounts = u.PasswordErrorCounts
                       };

            foreach (var theUser in user)
            {
                if (password == theUser.password)
                {
                    if (1 == theUser.isActivated)
                    {
                        if (theUser.passwordErrorCounts < BLL.ConstSummmary.MAXPASSWORDERROR)
                        {
                            UpdatePasswordErrSum(userName, dataContext, 0);
                            return LoginStateFlag.USERSUCCESS;
                        }
                        else
                        {
                            TimeSpan ts = (TimeSpan)DateTime.Now.Subtract(Convert.ToDateTime(theUser.frozenTime));
                            if (0 == ts.Days && 0 == ts.Hours)
                            {
                                return LoginStateFlag.ACCOUNTFREEZE;
                            }
                            else
                            {
                                UpdatePasswordErrSum(userName, dataContext, 0);
                                return LoginStateFlag.USERSUCCESS;
                            }
                        }
                    }
                    else
                    {
                        return LoginStateFlag.NONACTIVATED;
                    }
                }
                else
                {
                    UpdatePasswordErrSum(userName, dataContext, 1);
                    return LoginStateFlag.PASSWORDERROR;
                }
            }
            return LoginStateFlag.USERNAMENOTEXIST;
        }



        //登陆成功时，密码错误次数清0，否则该用户的密码错误次数+1。   
        private static void UpdatePasswordErrSum(string userName, DALDataContext dataContext, int flag)
        {
            DAL.Users myUser = dataContext.Users.FirstOrDefault(p => p.UserName == userName);
            if (flag == 0)
            {
                myUser.PasswordErrorCounts = 0;
            }
            else
            {
                myUser.PasswordErrorCounts = myUser.PasswordErrorCounts + 1;
            }

            myUser.FrozenTime = DateTime.Now;
            dataContext.ExecuteCommand("UPDATE [Users] SET  PasswordErrorCounts = @p0 WHERE UserName = @p1", myUser.PasswordErrorCounts, myUser.UserName);

        }

        public static RegistStateFlag Regist(Model.User user)
        {
            DALDataContext dataContext = new DALDataContext();
            int sameNameUserNum = (from u in dataContext.Users
                                   where u.UserName == user.UserName
                                   select u).Count();

            int sameNameAdminNum = (from u in dataContext.Administrators
                                    where u.AdministratorName == user.UserName
                                    select u).Count();

            int sameEmailNum = (from u in dataContext.Users
                                where u.Email == user.Info.Email
                                select u).Count();

            if (sameEmailNum != 0)
            {
                return RegistStateFlag.EMAILEXIST;
            }

            if (sameNameUserNum != 0 || sameNameAdminNum != 0)
            {
                return RegistStateFlag.ACCOUNTEXIST;
            }

            dataContext.Users.InsertOnSubmit(TransUserToTableType(user));
            dataContext.SubmitChanges();
            return RegistStateFlag.SUCCESS;
        }

        //将User类转化成对应的表类型。
        private static DAL.Users TransUserToTableType(Model.User user)
        {
            DAL.Users newUser = new DAL.Users();

            newUser.Birthdate = user.Info.Birthdate;
            newUser.City = user.Info.City;
            newUser.IsActivated = 0;
            newUser.Password = user.Password;
            newUser.UserName = user.UserName;
            newUser.PasswordErrorCounts = 0;
            //TODO
            //newUser.PhotoUrl = default img url.
            newUser.Email = user.Info.Email;
            newUser.Province = user.Info.Province;

            newUser.SkilledField = user.Info.SkilledField;
            newUser.Gender = user.Info.Gender;
            newUser.Position = user.Info.Position;
            newUser.UserName = user.UserName;
            newUser.Score = 0;
            newUser.FrozenTime = DateTime.Now;

            return newUser;
        }


        //根据用户名查找表中的对应ID, 如果表中没有该用户名，返回-1 。
        public static int GetUserIdByName(string userName)
        {
            DALDataContext dataContext = new DALDataContext();

            var queryResults = (from query in dataContext.Users
                                where query.UserName == userName
                                select query).FirstOrDefault();

            if (queryResults != null)
            {
                return queryResults.UserID;
            }
            else
            {
                return -1;
            }
        }
       
        //根据用户名查找表中的对应输入密码错误次数。
        public static int GetPasswordErrSumByName(string userName)
        {
            DALDataContext dataContext = new DALDataContext();

            var queryResults = (from query in dataContext.Users
                                where query.UserName == userName
                                select query).FirstOrDefault();

            if (queryResults != null)
            {
                return queryResults.PasswordErrorCounts;
            }
            else
            {
                return -1;
            }
        }

        //管理员修改密码。
        public static bool SetAdminNewPassword(string userName, string oldPassword, string newPassword)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            DAL.Administrators adminToChangerPwd = dataContext.Administrators.FirstOrDefault(p => p.AdministratorName == userName);
            if (adminToChangerPwd.Password == oldPassword)
            {
                adminToChangerPwd.Password = newPassword;
                dataContext.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //根据用户名得到
        public static Model.PersonalInformation GetUserInfoByName(string userName)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var info = (from u in dataContext.Users
                        where u.UserName.Equals(userName)
                        select new
                        {
                            birthday = u.Birthdate,
                            city = u.City,
                            province = u.Province,
                            skillField = u.SkilledField,
                            gender = u.Gender,
                            position = u.Position,
                            photoUrl = u.PhotoUrl,
                            email = u.Email,
                        }).FirstOrDefault();

            Model.PersonalInformation personalInformation = new Model.PersonalInformation();
            personalInformation.Birthdate = info.birthday;
            personalInformation.City = info.city;
            personalInformation.Gender = info.gender;
            personalInformation.Position = info.position;
            personalInformation.Province = info.province;
            personalInformation.SkilledField = info.skillField;
            personalInformation.Email = info.email;
            personalInformation.PhotoUrl = info.photoUrl;

            return personalInformation;
        }

        //修改密失败返回false，成功返回TRUE。
        //输入的userName要保证一定存在。
        public static bool SetNewPassword(string userName, string oldPassword, string newPassword)
        {
            DALDataContext dataContext = new DALDataContext();
            DAL.Users userToChangePwd = dataContext.Users.FirstOrDefault(p => p.UserName == userName);
            if (userToChangePwd.Password == oldPassword)
            {
                userToChangePwd.Password = newPassword;
                dataContext.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetUserNameById(int id)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var user = (from u in dataContext.Users
                        where u.UserID == id
                        select u).FirstOrDefault();
            if (user == null)
            {
                return String.Empty;
            }
            else
            {
                return Convert.ToString(user.UserName);
            }
        }

        public static int GetScoresByUserName(string userName)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var user = (from u in dataContext.Users
                        where u.UserName == userName
                        select u).FirstOrDefault();
            if (user == null)
            {
                return -1;
            }
            else
            {
                return (int)user.Score;
            }
        }

        public static string GetUserPhotoUrlById(int id)
        {
            DAL.DALDataContext dataContext = new DAL.DALDataContext();
            var user = (from u in dataContext.Users
                        where u.UserID == id
                        select u).FirstOrDefault();
            if (user == null)
            {
                return String.Empty;
            }
            else
            {
                return Convert.ToString(user.PhotoUrl);
            }
        }
        //判断该用户是否为普通用户
        private static bool IsUser(string userName)
        {
            if (GetUserIdByName(userName) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsAdminExist(string adminName)
        {
            DALDataContext dataContext = new DALDataContext();
            var queryCounts = (from query in dataContext.Administrators where query.AdministratorName == adminName select query).Count();

            if (queryCounts != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsEmailExist(string email)
        {
            DALDataContext dataContext = new DALDataContext();

            var queryCounts = (from query in dataContext.Users where query.Email == email select query).Count();

            if (queryCounts != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool MakeScores(int scores, string userName)
        {

            DALDataContext dataContext = new DALDataContext();
            var queryResults = (from query in dataContext.Users where query.UserName == userName select query).FirstOrDefault();


            if (queryResults != null)
            {
                Model.User user = new User();

                if (scores > 0)
                {
                    user.Score += (int)queryResults.Score;
                }
                else
                {
                    user.Score -= (int)queryResults.Score;

                    if (user.Score < 0)
                    {
                        user.Score = 0;
                    }
                }

                dataContext.SubmitChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Model.User> GetUserByScores()
        {
            DALDataContext dataContext = new DALDataContext();

            List<Model.User> userList = new List<User>();

            var queryResults = (from query in dataContext.Users orderby query.Score select query);

            if (queryResults.Count() > 10)
            {
                foreach (var query in queryResults.Take(10))
                {
                    Model.PersonalInformation per = new PersonalInformation();
                    per.Birthdate = query.Birthdate;
                    per.City = query.City;
                    per.Email = query.Email;
                    per.Gender = query.Gender;
                    per.PhotoUrl = query.PhotoUrl;
                    per.Position = query.Position;
                    per.Province = query.Province;
                    per.SkilledField = query.SkilledField;

                    Model.User user = new User();
                    user.UserId = query.UserID;
                    user.UserName = query.UserName;
                    user.IllegalCount = (int)query.IllegalCounts;
                    user.PasswordErrSum = query.PasswordErrorCounts;
                    user.Score = (int)query.Score;

                    user.Info = per;

                    userList.Add(user);
                }

                return userList;
            }
            else if (queryResults.Count() > 0)
            {
                foreach (var query in queryResults)
                {
                    Model.PersonalInformation per = new PersonalInformation();
                    per.Birthdate = query.Birthdate;
                    per.City = query.City;
                    per.Email = query.Email;
                    per.Gender = query.Gender;
                    per.PhotoUrl = query.PhotoUrl;
                    per.Position = query.Position;
                    per.Province = query.Province;
                    per.SkilledField = query.SkilledField;

                    Model.User user = new User();
                    user.UserId = query.UserID;
                    user.UserName = query.UserName;
                    user.IllegalCount = (int)query.IllegalCounts;
                    user.PasswordErrSum = query.PasswordErrorCounts;
                    user.Score = (int)query.Score;

                    user.Info = per;

                    userList.Add(user);
                }

                return userList;
            }
            else
            {
                return null;
            }
        }

        public static bool IsUserExist(string name)
        {
            if (IsUser(name) || IsAdminExist(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //private Model.User TransaleToUser(BLL.UserUtility bUser)
        //{
        //    Model.PersonalInformation per = new PersonalInformation();
        //    per.Birthdate = bUser.Birthdate;
        //    per.City = bUser.City;
        //    per.Email = query.Email;
        //    per.Gender = query.Gender;
        //    per.PhotoUrl = query.PhotoUrl;
        //    per.Position = query.Position;
        //    per.Province = query.Province;
        //    per.SkilledField = query.SkilledField;

        //    Model.User mUser = new User();
        //    mUser.UserId = query.UserID;
        //    mUser.UserName = query.UserName;
        //    mUser.IllegalCount = (int)query.IllegalCounts;
        //    mUser.PasswordErrSum = query.PasswordErrorCounts;
        //    mUser.Score = (int)query.Score;

        //    mUser.Info = per;
        //}

        //TODO 类图中有但未实现的方法
        //public bool LogOff(string userName)
        //{
        //    return true;
        //}                      
    }
}
