using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace 请假管理系统
{
    class sql_student
    {
        ConnectionPool CP;
        public sql_student(ConnectionPool CP)
        {
            this.CP = CP;
        }
        public int insert(student stu)
        {
            MySqlConnection conn = CP.getConnection();
            string sql = $"insert into tb_student(clazz_ID,stu_num,stu_name,stu_sex,stu_tel,stu_password,stu_addTime,stu_editTime) " +
                $"values ({stu.getClazz_ID()},'{stu.getStu_num()}','{stu.getStu_name()}',{stu.getStu_sex()},'{stu.getStu_tel()}','{stu.getStu_password()}','{stu.getStu_addTime().ToString()}','{stu.getStu_editTime().ToString()}')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int j = cmd.ExecuteNonQuery();
            CP.closeConnection(conn);
            return j;
        }
        public int update(student stu)
        {
            MySqlConnection conn = CP.getConnection();
            DateTime DT = DateTime.Now;
            string sql = $"update tb_student set clazz_ID={stu.getClazz_ID()},stu_name='{stu.getStu_name()}',stu_sex={stu.getStu_sex()},stu_tel='{stu.getStu_tel()}',stu_password='{stu.getStu_password()}'," +
                $"stu_editTime='{DT.ToString()}' where stu_num='{stu.getStu_num()}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int j = cmd.ExecuteNonQuery();
            CP.closeConnection(conn);
            return j;
        }
        public int getID(student stu)
        {
            MySqlConnection conn = CP.getConnection();
            string sql = $"select * from tb_student where stu_num = '{stu.getStu_num()}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int j = reader.GetInt32("stu_ID");
            reader.Dispose();
            CP.closeConnection(conn);
            stu.setStu_ID(j);
            return j;
        }

        public string getNameByID(int n)
        {
            MySqlConnection conn = CP.getConnection();
            string sql = $"select * from tb_student where stu_ID = '{n}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string name = reader.GetString("stu_name");
            reader.Dispose();
            CP.closeConnection(conn);
            return name;
        }

        public string getNumByID(int n)
        {
            MySqlConnection conn = CP.getConnection();
            string sql = $"select * from tb_student where stu_ID = '{n}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string num = reader.GetString("stu_num");
            reader.Dispose();
            CP.closeConnection(conn);
            return num;
        }
        public string getState_tutor(int check_tutor)
        {
            switch (check_tutor)
            {
                case 0:
                    {
                        return "审核中";
                    }
                case 1:
                    {
                        return "已通过";
                    }
                case 2:
                    {
                        return "未通过";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        public string getState_instructor(int check_tutor, int check_instructor)
        {
            if (check_tutor == 0)
            {
                return "待审核";
            }
            if (check_tutor == 2)
            {
                return "未通过";
            }
            switch (check_instructor)
            {
                case 0:
                    {
                        return "审核中";
                    }
                case 1:
                    {
                        return "已通过";
                    }
                case 2:
                    {
                        return "未通过";
                    }
                default:
                    {
                        return "";
                    }
            }

        }
        public int getIDByNum(string num)
        {
            MySqlConnection conn = CP.getConnection();
            string sql = $"select * from tb_student where stu_num like '%{num}%'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int n = reader.GetInt32("stu_ID");
            reader.Dispose();
            CP.closeConnection(conn);
            return n;
        }
    }
}
