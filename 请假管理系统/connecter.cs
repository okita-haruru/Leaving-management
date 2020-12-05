using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace 请假管理系统
{
    class connecter
    {
        ConnectionPool CP = new ConnectionPool();


        public MySqlConnection connection()
        {
            MySqlConnection conn = CP.getConnection();
            try
            {
                conn.Open();
                MessageBox.Show("连接成功!", "系统连接提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("连接失败,无法继续操作，系统关闭!", "系统连接提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }
            finally
            {
                conn.Close();
            }
            return conn;
        }
    }
            
}
