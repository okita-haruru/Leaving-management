using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 请假管理系统
{
    public partial class info_teacher : Form
    {
        ConnectionPool CP;
        teacher teacherDemo;
        public info_teacher(ConnectionPool CP,teacher teacherDemo)
        {
            InitializeComponent();
            this.CP = CP;
            this.teacherDemo = teacherDemo;
            List<apply> applyList = new List<apply>();
            string sql = $"select * from tb_apply where tutor_ID={teacherDemo.getTeacher_ID()} " +
                $"or instructor_ID={teacherDemo.getTeacher_ID()}";
            selecter selecterDemo = new selecter(CP, sql);
            apply applyDemo;
            MySqlDataReader reader = selecterDemo.execute();
            while (reader.Read())
            {
                applyDemo = new apply();
                applyDemo.setApply_ID(reader.GetInt32("apply_ID"));
                applyDemo.setStu_ID(reader.GetInt32("stu_ID"));
                applyDemo.setTutor_ID(reader.GetInt32("tutor_ID"));
                applyDemo.setInstructor_ID(reader.GetInt32("instructor_ID"));
                applyDemo.setApply_time(reader.GetDateTime("apply_time"));
                applyDemo.setApply_start(reader.GetDateTime("apply_start"));
                applyDemo.setApply_end(reader.GetDateTime("apply_end"));
                applyDemo.setApply_reason(reader.GetString("apply_reason"));
                applyDemo.setCheck_tutor(reader.GetInt32("check_tutor"));
                applyDemo.setCheck_instructor(reader.GetInt32("check_instructor"));
                if (applyDemo.getCheck_tutor() == 2 || applyDemo.getCheck_instructor() == 2)
                    applyDemo.setApply_refuse(reader.GetString("apply_refuse"));
                applyList.Add(applyDemo);
            }
            selecterDemo.end();
            sql_student ss = new sql_student(CP);
            foreach (apply ap in applyList)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = ss.getNumByID(ap.getStu_ID());
                dataGridView1.Rows[index].Cells[1].Value = ss.getNameByID(ap.getStu_ID());
                dataGridView1.Rows[index].Cells[2].Value = ap.getApply_reason();
                dataGridView1.Rows[index].Cells[3].Value = ap.getApply_start();
                dataGridView1.Rows[index].Cells[4].Value = ap.getApply_end();
                if(teacherDemo.getTeacher_pos()==1)
                {
                    dataGridView1.Rows[index].Cells[5].Value = ss.getState_tutor(ap.getCheck_tutor());
                }
                if (teacherDemo.getTeacher_pos() == 2)
                {
                    dataGridView1.Rows[index].Cells[5].Value = ss.getState_instructor(ap.getCheck_tutor(), ap.getCheck_instructor());
                }
                dataGridView1.Rows[index].Cells[6].Value = ap.getApply_refuse();
            }

        }

        private void info_teacher_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
