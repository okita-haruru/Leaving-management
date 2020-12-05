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
    public partial class main_teacher : Form
    {
        ConnectionPool CP;
        teacher teacherDemo=new teacher();
        public main_teacher(ConnectionPool CP, string user, string username)
        {
            InitializeComponent();
            this.CP = CP;
            label3.Text = username;
            MySqlDataReader reader;
            string sql = $"select * from tb_teacher where teacher_num={user}";
            selecter selecterDemo = new selecter(CP, sql);
            reader = selecterDemo.execute();
            reader.Read();
            teacherDemo.setTeacher_ID(reader.GetInt32("teacher_ID"));
            teacherDemo.setTeacher_num(user);
            teacherDemo.setTeacher_name(username);
            teacherDemo.setTeacher_pos(reader.GetInt32("teacher_pos"));
            teacherDemo.setTeacher_tel(reader.GetString("teacher_tel"));
            selecterDemo.end();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox4, "注销登陆");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox2, "审批记录");
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox3, "信息查询");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(pictureBox1, "申请审批");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            teacher_check tc = new teacher_check(CP,teacherDemo);
            tc.Show();
        }

        private void main_teacher_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            info_teacher inte = new info_teacher(CP, teacherDemo);
            inte.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            info_clazz ic = new info_clazz(CP);
            ic.Show();
        }
    }
}
