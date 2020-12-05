using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 请假管理系统
{
    public class apply
    {
        int apply_ID;
        int stu_ID;
        int tutor_ID;
        int instructor_ID;
        DateTime apply_time;
        DateTime apply_start;
        DateTime apply_end;
        string apply_reason;
        int check_tutor;
        int check_instructor;
        DateTime apply_del;
        string apply_refuse;
        DateTime apply_editTime;

        public int getApply_ID()
        {
            return apply_ID;
        }
        public void setApply_ID(int n)
        {
            apply_ID = n;
        }

        public int getStu_ID()
        {
            return stu_ID;
        }
        public void setStu_ID(int n)
        {
            stu_ID = n;
        }

        public int getTutor_ID()
        {
            return tutor_ID;
        }
        public void setTutor_ID(int n)
        {
            tutor_ID = n;
        }

        public int getInstructor_ID()
        {
            return instructor_ID;
        }
        public void setInstructor_ID(int n)
        {
            instructor_ID = n;
        }

        public DateTime getApply_time()
        {
            return apply_time;
        }
        public void setApply_time(DateTime DT)
        {
            apply_time = DT;
        }

        public DateTime getApply_start()
        {
            return apply_start;
        }
        public void setApply_start(DateTime DT)
        {
            apply_start = DT;
        }

        public DateTime getApply_end()
        {
            return apply_end;
        }
        public void setApply_end(DateTime DT)
        {
            apply_end = DT;
        }

        public string getApply_reason()
        {
            return apply_reason;
        }
        public void setApply_reason(String s)
        {
            apply_reason = s;
        }

        public int getCheck_tutor()
        {
            return check_tutor;
        }
        public void setCheck_tutor(int n)
        {
            check_tutor = n;
        }

        public int getCheck_instructor()
        {
            return check_instructor;
        }
        public void setCheck_instructor(int n)
        {
            check_instructor = n;
        }

        public DateTime getApply_del()
        {
            return apply_del;
        }
        public void setApply_del(DateTime DT)
        {
            apply_del = DT;
        }

        public string getApply_refuse()
        {
            return apply_refuse;
        }
        public void setApply_refuse(string s)
        {
            apply_refuse = s;
        }

        public DateTime getApply_editTime()
        {
            return apply_editTime;
        }
        public void setApply_editTime(DateTime DT)
        {
            apply_editTime = DT;
        }




    }
}
