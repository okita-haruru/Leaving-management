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
    public partial class apply_detail : Form
    {
        ConnectionPool CP;
        apply applyDemo;
        teacher teacherDemo;
        public apply_detail(ConnectionPool CP,apply app,teacher teacherDemo)
        {
            InitializeComponent();
            pictureBox7.Hide();
            label10.Hide();
            this.CP = CP; ;
            this.teacherDemo = teacherDemo;
            this.applyDemo = app;
            sql_student ss = new sql_student(CP);
            label4.Text = ss.getNumByID(applyDemo.getStu_ID());
            label5.Text = ss.getNameByID(applyDemo.getStu_ID());
            richTextBox1.Text = applyDemo.getApply_reason();
            label6.Text = applyDemo.getApply_start().ToString()+"——"+applyDemo.getApply_end().ToString();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                richTextBox2.Enabled = false;
            }
            else
            {
                richTextBox2.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                richTextBox2.Enabled = false;
            }
            else
            {
                richTextBox2.Enabled = true;
            }
        }

        private void apply_detail_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(!radioButton1.Checked&&!radioButton2.Checked)
            {
                pictureBox7.Show();
                label10.Show();
                return;
            }
            else
            {
                pictureBox7.Hide();
                label10.Hide();
            }
            sql_apply sa = new sql_apply(CP);
            if(radioButton1.Checked)//同意
            {
                sa.check_agree(applyDemo, teacherDemo);
                MessageBox.Show("通过成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                sa.check_refuse(applyDemo, teacherDemo, richTextBox2.Text);
                MessageBox.Show("拒绝成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            teacher_check tc = new teacher_check(CP, teacherDemo);
            tc.Show();
            this.Close();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
