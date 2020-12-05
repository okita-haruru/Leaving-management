using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace 请假管理系统
{
    class sql_apply
    {
        ConnectionPool CP;
        public sql_apply(ConnectionPool CP)
        {
            this.CP = CP;
        }
        public int insert(apply applyDemo)
        {
            MySqlConnection conn=CP.getConnection();
            string sql;
            sql = "insert into tb_apply(stu_ID,tutor_ID,instructor_ID,apply_time,apply_start,apply_end," +
                "apply_reason,check_tutor,check_instructor,apply_editTime) values" +
                $"({applyDemo.getStu_ID()},{applyDemo.getTutor_ID()},{applyDemo.getInstructor_ID()}," +
                $"'{applyDemo.getApply_time()}','{applyDemo.getApply_start()}','{applyDemo.getApply_end()}'," +
                $"'{applyDemo.getApply_reason()}',{applyDemo.getCheck_tutor()},{applyDemo.getCheck_instructor()}," +
                $"'{applyDemo.getApply_editTime()}')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int j = cmd.ExecuteNonQuery();
            CP.closeConnection(CP.getConnection());
            return j;
        }
        public int check_agree(apply applyDemo,teacher teacherDemo)
        {
            MySqlConnection conn = CP.getConnection();
            DateTime DT = DateTime.Now;
            string sql;
            if (teacherDemo.getTeacher_pos() == 1)
            {
                sql = $"update tb_apply set check_tutor=1,apply_editTime='{DT}' where apply_ID={applyDemo.getApply_ID()}";
            }
            else
            {
                sql = $"update tb_apply set check_instructor=1,apply_editTime='{DT}' where apply_ID={applyDemo.getApply_ID()}";
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int j = cmd.ExecuteNonQuery();
            CP.closeConnection(conn);
            return j;
        }

        public int check_refuse(apply applyDemo, teacher teacherDemo,string refuse)
        {
            MySqlConnection conn = CP.getConnection();
            DateTime DT = DateTime.Now;
            string sql;
            if (teacherDemo.getTeacher_pos() == 1)
            {
                sql = $"update tb_apply set check_tutor=2,apply_editTime='{DT}',apply_refuse='{refuse}' where apply_ID={applyDemo.getApply_ID()}";
            }
            else
            {
                sql = $"update tb_apply set check_instructor=2,apply_editTime='{DT}',apply_refuse='{refuse}' where apply_ID={applyDemo.getApply_ID()}";
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int j = cmd.ExecuteNonQuery();
            CP.closeConnection(conn);
            return j;
        }
    }
}
