using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 请假管理系统
{
    public class teacher
    {
        int teacher_ID;
        string teacher_num;
        string teacher_name;
        int teacher_pos;
        string teacher_tel;
        string teacher_password;
        DateTime teacher_addTime;
        DateTime teacher_editTime;
        public int getTeacher_ID()
        {
            return teacher_ID;
        }
        public void setTeacher_ID(int n)
        {
            teacher_ID = n;
        }

        public string getTeacher_num()
        {
            return teacher_num;
        }
        public void setTeacher_num(string s)
        {
            teacher_num = s;
        }

        public string getTeacher_name()
        {
            return teacher_name;
        }
        public void setTeacher_name(string s)
        {
            teacher_name = s;
        }

        public int getTeacher_pos()
        {
            return teacher_pos;
        }
        public void setTeacher_pos(int n)
        {
            teacher_pos = n;
        }

        public string getTeacher_tel()
        {
            return teacher_tel;
        }
        public void setTeacher_tel(string s)
        {
            teacher_tel = s;
        }

        public string getTeacher_password()
        {
            return teacher_password;
        }
        public void setTeacher_password(string s)
        {
            teacher_password = s;
        }
        public DateTime getTeacher_addTime()
        {
            return teacher_addTime;
        }
        public void setTeacher_addTime(DateTime DT)
        {
            teacher_addTime = DT;
        }

        public DateTime getTeacher_editTime()
        {
            return teacher_editTime;
        }
        public void setTeacher_editTime(DateTime DT)
        {
            teacher_editTime = DT;
        }
    }
}
