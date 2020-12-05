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
    public partial class main_student : Form
    {
        ConnectionPool CP;
        string stu_num;
        string stu_name;
        student studentDemo = new student();
        public main_student(ConnectionPool CP,string user,string username)
        {
            InitializeComponent();
            this.CP = CP;
            label3.Text = username;
            stu_num = user;
            stu_name = username;
            MySqlDataReader reader;
            string sql = $"select * from tb_student where stu_num={stu_num}";
            selecter selecterDemo = new selecter(CP, sql);
            reader = selecterDemo.execute();
            reader.Read();
            studentDemo.setClazz_ID(reader.GetInt32("clazz_ID"));
            studentDemo.setStu_ID(reader.GetInt32("stu_ID"));
            studentDemo.setStu_num(reader.GetString("stu_num"));
            studentDemo.setStu_name(reader.GetString("stu_name"));
            studentDemo.setStu_sex(reader.GetInt32("stu_sex"));
            studentDemo.setStu_tel(reader.GetString("stu_tel"));
            studentDemo.setStu_password(reader.GetString("stu_password"));
            selecterDemo.end();
            
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox1, "新增申请");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox2, "申请记录");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox3, "修改个人信息");
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox4, "退出登陆");
        }

        private void main_student_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            student_edit se = new student_edit(CP, studentDemo);
            se.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            apply_add aa = new apply_add(CP,studentDemo);
            aa.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            infor_stu ins = new infor_stu(CP,studentDemo);
            ins.Show();
        }
    }
}
