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
    public partial class register : Form
    {
        ConnectionPool CP;
        password pw = new password();
        public register(ConnectionPool CP)
        {
            InitializeComponent();
            this.CP = CP;
            comboBox1.Items.Add("高三(1)班");
            comboBox1.Items.Add("高三(2)班");
            comboBox1.Items.Add("高三(3)班");
            comboBox1.Items.Add("高三(4)班");
            comboBox2.Items.Add("男");
            comboBox2.Items.Add("女");
            pictureBox3.Hide();//初始化
            label11.Hide();
            pictureBox5.Hide();
            label13.Hide();
            pictureBox4.Hide();
            label12.Hide();
            pictureBox7.Hide();
            label10.Hide();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox2, "确认注册");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Boolean flag;
            flag = true;
            student newstu = new student();
            if (textBox3.Text!=textBox4.Text)//判密码
            {
                pictureBox3.Show();
                label11.Show();
                flag = false;
            }
            else
            {
                pictureBox3.Hide();
                label11.Hide();
            }
            if(textBox3.Text=="")
            {
                flag = false;
                pictureBox5.Show();
                label13.Show();
            }
            else
            {
                pictureBox5.Hide();
                label13.Hide();
            }

            if (textBox5.Text.Length != 11 || textBox5.Text.Substring(0, 1) != "1")//验手机号
            {
                flag = false;
                pictureBox4.Show();
                label12.Show();
            }
            else
            {
                pictureBox4.Hide();
                label12.Hide();
            }
            
            string sql = $"select * from tb_student where stu_num = '{textBox1.Text}'"; ;
            selecter selecterDemo = new selecter(CP, sql);
            try
            {
                if (selecterDemo.getNum() != 0)
                {
                    pictureBox7.Show();
                    label10.Show();
                    flag = false;
                }
                else
                {
                    pictureBox7.Hide();
                    label10.Hide();//到此成功注册
                    newstu.setClazz_ID(comboBox1.SelectedIndex+1);
                    newstu.setStu_name(textBox2.Text);
                    newstu.setStu_num(textBox1.Text);
                    newstu.setStu_sex(comboBox2.SelectedIndex);
                    newstu.setStu_password(pw.lockstring(textBox3.Text));
                    newstu.setStu_tel(textBox5.Text);
                    newstu.setStu_addTime(DateTime.Now);
                    newstu.setStu_editTime(DateTime.Now);
                }
                if (flag == false)
                {
                    return;
                }
            }
            finally
            {
                selecterDemo.end();
            }
            sql_student ss = new sql_student(CP);
            int j = ss.insert(newstu);
            this.Hide();
            MessageBox.Show("注册成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
