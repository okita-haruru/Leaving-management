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
    public partial class login : Form
    {
        MySqlConnection conn;
        string user;
        string username;
        ConnectionPool CP = new ConnectionPool();
        password pw = new password();
        public login()
        {
            connecter connecter = new connecter();
            conn = CP.getConnection();
            InitializeComponent();
            label3.Hide();
            pictureBox7.Hide();
            label2.Hide();
            pictureBox8.Hide();
            label4.Hide();
            pictureBox9.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox1, "用户名");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox2, "密码");
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox5, "学生登陆");
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox4, "教师登陆");
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox6, "学生注册");
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            register win_reg = new register(CP);
            win_reg.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean flag=true;
            MySqlDataReader reader;
            user = textBox1.Text;
            string password;

            if (!radioButton1.Checked&&!radioButton2.Checked)
            {
                label4.Show();
                pictureBox9.Show();
                flag = false;
                return;
            }
            else
            {
                label4.Hide();
                pictureBox9.Hide();
            }


            if (radioButton2.Checked)//学生
            {
                string sql = $"select * from tb_student where stu_num = '{user}'";
                selecter selecterDemo = new selecter(CP, sql);
                try
                {
                    if (0 == selecterDemo.getNum())
                    {
                        label3.Show();
                        pictureBox7.Show();
                        flag = false;
                        return;
                    }
                    else
                    {
                        label3.Hide();
                        pictureBox7.Hide();
                    }
                    reader = selecterDemo.execute();
                    reader.Read();
                    password = reader.GetString("stu_password");
                    username = reader.GetString("stu_name");
                    reader.Dispose();
                    if (pw.unlockstring(password) != textBox2.Text)
                    {
                        label2.Show();
                        pictureBox8.Show();
                        flag = false;
                        return;
                    }
                    else
                    {
                        label2.Hide();
                        pictureBox8.Hide();//到此学生成功登陆
                    }
                }
                finally
                {
                    selecterDemo.end();
                }
                this.Hide();
                main_student ms = new main_student(CP, user, username);
                ms.ShowDialog(this);
                this.Show();
            }
            if (radioButton1.Checked)//教师
            {
                string sql = $"select * from tb_teacher where teacher_num = '{user}'";
                selecter selecterDemo = new selecter(CP, sql);
                try
                {
                    if (0 == selecterDemo.getNum())
                    {
                        label3.Show();
                        pictureBox7.Show();
                        flag = false;
                        return;
                    }
                    else
                    {
                        label3.Hide();
                        pictureBox7.Hide();
                    }
                    reader = selecterDemo.execute();
                    reader.Read();
                    password = reader.GetString("teacher_password");
                    username = reader.GetString("teacher_name");
                    reader.Dispose();
                    if (pw.unlockstring(password) != textBox2.Text)
                    {
                        label2.Show();
                        pictureBox8.Show();
                        flag = false;
                        return;
                    }
                    else
                    {
                        label2.Hide();
                        pictureBox8.Hide();//到此教师成功登陆
                    }
                }
                finally
                {
                    selecterDemo.end();
                }
                this.Hide();
                main_teacher mt = new main_teacher(CP, user, username);
                mt.ShowDialog(this);
                this.Show();
            }
        }
    }
}
