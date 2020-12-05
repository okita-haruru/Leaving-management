using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 请假管理系统
{
    class password
    {
        public string lockstring(string s)
        {
            string saf="";
            foreach(char c in s)
            {
                saf += (char)(c - 1);
            }
            return saf;
        }

        public string unlockstring(string s)
        {
            string saf = "";
            foreach (char c in s)
            {
                saf += (char)(c + 1);
            }
            return saf;
        }


    }
}
