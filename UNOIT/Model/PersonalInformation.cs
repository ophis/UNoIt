using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PersonalInformation
    {
        private string skilledField;

        public string SkilledField
        {
            get { return skilledField; }
            set { skilledField = value; }
        }

        private DateTime birthdate;

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        private int gender;

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string province;

        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private string photoUrl;

        public string PhotoUrl
        {
            get { return photoUrl; }
            set { photoUrl = value; }
        }
    }
}
