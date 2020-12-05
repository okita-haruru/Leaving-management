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
    public partial class teacher_check : Form
    {
        ConnectionPool CP;
        teacher teacherDemo;
        int dgv_index;
        List<apply> applyList = new List<apply>();
        public teacher_check(ConnectionPool CP,teacher teacherDemo)
        {
            InitializeComponent();
            pictureBox7.Hide();
            label3.Hide();
            this.CP = CP;
            this.teacherDemo = teacherDemo;
            string sql = $"select * from tb_apply where tutor_ID={teacherDemo.getTeacher_ID()} " +
                $"or instructor_ID={teacherDemo.getTeacher_ID()}";
            selecter selecterDemo = new selecter(CP, sql);
            apply applyDemo;
            MySqlDataReader reader = selecterDemo.execute();
            while(reader.Read())
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
                if(teacherDemo.getTeacher_pos()==1)
                {
                    if(applyDemo.getCheck_tutor()==0&&applyDemo.getTutor_ID()==teacherDemo.getTeacher_ID())
                    {
                        applyList.Add(applyDemo);
                    }
                }
                else
                {
                    if(applyDemo.getCheck_instructor()==0&& applyDemo.getCheck_tutor() == 1&&applyDemo.getInstructor_ID()==teacherDemo.getTeacher_ID())
                    {
                        applyList.Add(applyDemo);
                    }
                }
            }
            selecterDemo.end();
            sql_student ss = new sql_student(CP);
            DataGridViewRow dr = new DataGridViewRow();
            foreach (apply ap in applyList)
            {

                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = ss.getNumByID(ap.getStu_ID());
                dataGridView1.Rows[index].Cells[1].Value = ss.getNameByID(ap.getStu_ID());
                dataGridView1.Rows[index].Cells[2].Value = ap.getApply_start();
                dataGridView1.Rows[index].Cells[3].Value = ap.getApply_end();
                dataGridView1.Rows[index].Cells[4].Value = ap.getApply_reason();
                dataGridView1.Rows[index].Cells[5].Value = ap.getApply_time();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                dgv_index = -1;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    dgv_index=row.Index;
                }
            }
            if (dgv_index == -1)
            {
                pictureBox7.Show();
                label3.Show();
                return;
            }
            else
            {
                pictureBox7.Hide();
                label3.Hide();
            }
            apply_detail ad = new apply_detail(CP,applyList[dgv_index],teacherDemo);
            ad.Show();
            this.Close();
        }

        private void teacher_check_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
