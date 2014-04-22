using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User : AbstractUser
    {
        //用户违规次数
        private int illegalCount = 0;

        public int IllegalCount
        {
            get { return illegalCount; }
            set { illegalCount = value;}
        }
         
        //用户个人信息
        private PersonalInformation info = null;

        public PersonalInformation Info
        {
            get { return info; }
            set { info = value; }
        }

        //用户积分
        private int score = 0;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        //用户账户是否激活
        private int activation = 0;

        public int Activation
        {
            get { return activation; }
            set { activation = value; }
        }

    }
}
