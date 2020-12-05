using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace 请假管理系统
{
    class selecter
    {
        MySqlConnection conn;
        ConnectionPool CP;
        string sql;
        public selecter(ConnectionPool CP,string sql)
        {
            this.CP = CP;
            this.sql = sql;
        }
        public MySqlDataReader execute()
        {
            conn = CP.getConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public int getNum()
        {
            conn = CP.getConnection();
            int i=0;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                i++;
            }
            reader.Dispose();
            return i;
        }
        public void end()
        {
            CP.closeConnection(conn);
        }
    }
}
