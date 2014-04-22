using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   
    public class Catagory
    {
        private string catagoryName;

        public string CatagoryName
        {
            get { return catagoryName; }
            set { catagoryName = value; }
        }
        private int catagoryId;

        public int CatagoryId
        {
            get { return catagoryId; }
            set { catagoryId = value; }
        }
    }
}
