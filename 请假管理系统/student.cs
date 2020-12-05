using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 请假管理系统
{
    public class student
    {
        int stu_ID;
        int clazz_ID;
        string stu_num;
        string stu_name;
        int stu_sex;
        string stu_tel;
        string stu_password;
        DateTime stu_addTime;
        DateTime stu_editTime;

        public int getStu_ID()
        {
            return stu_ID;
        }
        public void setStu_ID(int n)
        {
            this.stu_ID = n;
        }
        public int getClazz_ID()
        {
            return clazz_ID;
        }
        public void setClazz_ID(int n)
        {
            this.clazz_ID = n;
        }

        public string getStu_num()
        {
            return stu_num;
        }
        public void setStu_num(string s)
        {
            this.stu_num = s;
        }

        public string getStu_name()
        {
            return stu_name;
        }
        public void setStu_name(string s)
        {
            this.stu_name = s;
        }

        public int getStu_sex()
        {
            return stu_sex;
        }
        public void setStu_sex(int n)
        {
            this.stu_sex = n;
        }

        public string getStu_tel()
        {
            return stu_tel;
        }
        public void setStu_tel(string s)
        {
            this.stu_tel = s;
        }

        public string getStu_password()
        {
            return stu_password;
        }
        public void setStu_password(string s)
        {
            this.stu_password = s;
        }

        public DateTime getStu_addTime()
        {
            return stu_addTime;
        }
        public void setStu_addTime(DateTime dt)
        {
            this.stu_addTime = dt;
        }

        public DateTime getStu_editTime()
        {
            return stu_editTime;
        }
        public void setStu_editTime(DateTime dt)
        {
            this.stu_editTime = dt;
        }
    }
}
