using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace 请假管理系统
{
    class sql_teacher
    {
        ConnectionPool CP;
        public sql_teacher(ConnectionPool CP)
        {
            this.CP = CP;
        }
        int getID(teacher teacherDemo)
        {
            MySqlConnection conn = CP.getConnection();
            string sql = $"select * from tb_teacher where teacher_num = '{teacherDemo.getTeacher_num()}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int j = reader.GetInt32("teacher_ID");
            reader.Dispose();
            CP.closeConnection(conn);
            teacherDemo.setTeacher_ID(j);
            return j;
        }
    }
}
