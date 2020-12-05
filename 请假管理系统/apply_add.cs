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
    public partial class apply_add : Form
    {
        ConnectionPool CP;
        student studentDemo;
        Boolean flag;
        int tutor_ID;
        int instructor_ID;
        public apply_add(ConnectionPool CP,student studentDemo)
        {
            InitializeComponent();
            this.CP = CP;
            this.studentDemo = studentDemo;
            pictureBox7.Hide();
            label10.Hide();
            pictureBox2.Hide();
            label6.Hide();
            sql_student ss = new sql_student(CP);
            ss.getID(studentDemo);
            string sql = $"select * from tb_student,tb_clazz where tb_student.clazz_ID=tb_clazz.clazz_ID and tb_student.stu_ID={studentDemo.getStu_ID()}";
            selecter selecterDemo = new selecter(CP, sql);
            MySqlDataReader reader = selecterDemo.execute();
            reader.Read();
            tutor_ID = reader.GetInt32("tutor_ID");
            instructor_ID = reader.GetInt32("instructor_ID");
            reader.Dispose();
            selecterDemo.end();
            

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void apply_add_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker2.Value<dateTimePicker1.Value)//判断日期
            {
                pictureBox7.Show();
                label10.Show();
                flag = false;
                return;
            }
            else
            {
                pictureBox7.Hide();
                label10.Hide();
                flag = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                pictureBox2.Show();
                label6.Show();
                flag = false;
                return;
            }
            else
            {
                pictureBox2.Hide();
                label6.Hide();
                flag = true;
            }
            if (flag == true)//验证通过
            {
                apply applyDemo = new apply();
                applyDemo.setStu_ID(studentDemo.getStu_ID());
                applyDemo.setApply_start(dateTimePicker1.Value);
                applyDemo.setApply_end(dateTimePicker2.Value);
                applyDemo.setApply_reason(richTextBox1.Text);
                applyDemo.setCheck_tutor(0);
                applyDemo.setInstructor_ID(0);
                applyDemo.setApply_refuse("");
                applyDemo.setApply_editTime(DateTime.Now);
                applyDemo.setApply_time(DateTime.Now);
                applyDemo.setTutor_ID(tutor_ID);
                applyDemo.setInstructor_ID(instructor_ID);
                applyDemo.setApply_editTime(DateTime.Now);
                sql_apply sa = new sql_apply(CP);
                sa.insert(applyDemo);
                MessageBox.Show("添加成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)//判断日期
            {
                pictureBox7.Show();
                label10.Show();
                flag = false;
                return;
            }
            else
            {
                pictureBox7.Hide();
                label10.Hide();
                flag = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
