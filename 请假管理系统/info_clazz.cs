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
//select count(*),clazz_name from tb_apply,tb_student,tb_clazz where tb_apply.stu_ID=tb_student.stu_ID and tb_student.clazz_ID=tb_clazz.clazz_ID GROUP BY clazz_name ORDER BY count(*)DESC
namespace 请假管理系统
{
    public partial class info_clazz : Form
    {
        Boolean flag;
        List<apply> applyList = new List<apply>();
        List<apply> alterApplyList = new List<apply>();

        ConnectionPool CP;
        public info_clazz(ConnectionPool CP)
        {
            InitializeComponent();
            pictureBox7.Hide();
            label3.Hide();
            this.CP = CP;
            string sql;
            sql = "select count(*),clazz_name from tb_apply,tb_student,tb_clazz " +
                "where tb_apply.stu_ID=tb_student.stu_ID and tb_student.clazz_ID=tb_clazz.clazz_ID " +
                "GROUP BY clazz_name ORDER BY count(*)";
            selecter selecterDemo = new selecter(CP,sql);
            MySqlDataReader reader = selecterDemo.execute();
            while(reader.Read())
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = reader.GetString("clazz_name");
                dataGridView1.Rows[index].Cells[1].Value = reader.GetInt32("count(*)");
            }
            reader.Dispose();
            selecterDemo.end();
            string sql2;
            sql2 = "select * from tb_apply";
            selecterDemo = new selecter(CP, sql2);
            reader = selecterDemo.execute();
            apply applyDemo;
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
                if(applyDemo.getCheck_tutor() == 0 || applyDemo.getCheck_instructor() == 0)
                    applyDemo.setApply_refuse("审核中");
                if (applyDemo.getCheck_tutor() == 2 || applyDemo.getCheck_instructor() == 2)
                    applyDemo.setApply_refuse(reader.GetString("apply_refuse"));
                if (applyDemo.getCheck_tutor() == 1 && applyDemo.getCheck_instructor() == 1)
                    applyDemo.setApply_refuse("申请通过");
                applyList.Add(applyDemo);
            }
            selecterDemo.end();
            sql_student ss = new sql_student(CP);
            foreach(apply ap in applyList)
            {
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = ss.getNumByID(ap.getStu_ID());
                dataGridView2.Rows[index].Cells[1].Value = ss.getNameByID(ap.getStu_ID());
                dataGridView2.Rows[index].Cells[2].Value = ap.getApply_time();
                dataGridView2.Rows[index].Cells[3].Value = ap.getApply_reason();
                dataGridView2.Rows[index].Cells[4].Value = ap.getApply_refuse();
            }




        }

        private void info_clazz_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select count(*),clazz_name from tb_apply,tb_student,tb_clazz " +
                "where tb_apply.stu_ID=tb_student.stu_ID and tb_student.clazz_ID=tb_clazz.clazz_ID " +
                "GROUP BY clazz_name ORDER BY count(*)";
            selecter selecterDemo = new selecter(CP, sql);
            MySqlDataReader reader = selecterDemo.execute();
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = reader.GetString("clazz_name");
                dataGridView1.Rows[index].Cells[1].Value = reader.GetInt32("count(*)");
            }
            selecterDemo.end();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select count(*),clazz_name from tb_apply,tb_student,tb_clazz " +
                "where tb_apply.stu_ID=tb_student.stu_ID and tb_student.clazz_ID=tb_clazz.clazz_ID " +
                "GROUP BY clazz_name ORDER BY count(*)DESC";
            selecter selecterDemo = new selecter(CP, sql);
            MySqlDataReader reader = selecterDemo.execute();
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = reader.GetString("clazz_name");
                dataGridView1.Rows[index].Cells[1].Value = reader.GetInt32("count(*)");
            }
            selecterDemo.end();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int i1 = textBox1.Text.IndexOf("or");
            int i2 = textBox1.Text.IndexOf("OR");
            int i3 = textBox1.Text.IndexOf("and");
            int i4 = textBox1.Text.IndexOf("AND");
            int i5= textBox1.Text.IndexOf("%");
            int i6 = textBox1.Text.IndexOf("_");
            if (i1 + i2 + i3 + i4 + i5 + i6 != -6)
            {
                flag = false;
                pictureBox7.Show();
                label3.Show();
                return;
            }
            else
            {
                pictureBox7.Hide();
                label3.Hide();
                flag = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(flag==true)
            {
                sql_student ss = new sql_student(CP);
                dataGridView2.Rows.Clear();
                string s;
                foreach (apply ap in applyList)
                {
                    if (ss.getNumByID(ap.getStu_ID()).IndexOf(textBox1.Text) != -1)
                    {
                        int index = dataGridView2.Rows.Add();
                        dataGridView2.Rows[index].Cells[0].Value = ss.getNumByID(ap.getStu_ID());
                        dataGridView2.Rows[index].Cells[1].Value = ss.getNameByID(ap.getStu_ID());
                        dataGridView2.Rows[index].Cells[2].Value = ap.getApply_time();
                        dataGridView2.Rows[index].Cells[3].Value = ap.getApply_reason();
                        dataGridView2.Rows[index].Cells[4].Value = ap.getApply_refuse();
                    }

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(flag==true)
            {
                sql_student ss = new sql_student(CP);
                dataGridView2.Rows.Clear();
                string s;
                foreach (apply ap in applyList)
                {
                    if (ss.getNameByID(ap.getStu_ID()).IndexOf(textBox1.Text) != -1)
                    {
                        int index = dataGridView2.Rows.Add();
                        dataGridView2.Rows[index].Cells[0].Value = ss.getNumByID(ap.getStu_ID());
                        dataGridView2.Rows[index].Cells[1].Value = ss.getNameByID(ap.getStu_ID());
                        dataGridView2.Rows[index].Cells[2].Value = ap.getApply_time();
                        dataGridView2.Rows[index].Cells[3].Value = ap.getApply_reason();
                        dataGridView2.Rows[index].Cells[4].Value = ap.getApply_refuse();
                    }

                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            sql_student ss = new sql_student(CP);
            foreach (apply ap in applyList)
            {
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = ss.getNumByID(ap.getStu_ID());
                dataGridView2.Rows[index].Cells[1].Value = ss.getNameByID(ap.getStu_ID());
                dataGridView2.Rows[index].Cells[2].Value = ap.getApply_time();
                dataGridView2.Rows[index].Cells[3].Value = ap.getApply_reason();
                dataGridView2.Rows[index].Cells[4].Value = ap.getApply_refuse();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
