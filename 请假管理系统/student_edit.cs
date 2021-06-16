using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 请假管理系统
{
    public partial class student_edit : Form
    {
        ConnectionPool CP;
        student studentDemo;
        password pw = new password();
        public student_edit(ConnectionPool CP,student studentDemo)
        {
            InitializeComponent();
            comboBox1.Items.Add("高三(1)班");
            comboBox1.Items.Add("高三(2)班");
            comboBox1.Items.Add("高三(3)班");
            comboBox1.Items.Add("高三(4)班");
            this.CP = CP;
            this.studentDemo = studentDemo;
            textBox2.Text = studentDemo.getStu_name();
            comboBox1.SelectedIndex = studentDemo.getClazz_ID()-1;
            textBox5.Text = studentDemo.getStu_tel();
            textBox3.Text = pw.unlockstring(studentDemo.getStu_password());
        }

        private void student_edit_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            studentDemo.setStu_name(textBox2.Text);
            studentDemo.setClazz_ID(comboBox1.SelectedIndex + 1);
            studentDemo.setStu_tel(textBox5.Text);
            studentDemo.setStu_password(pw.lockstring(textBox3.Text));
            sql_student ss = new sql_student(CP);
            int j=ss.update(studentDemo);
            if(1==j)
            {
                MessageBox.Show("修改成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
            }
            else
            {
                MessageBox.Show("修改失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
