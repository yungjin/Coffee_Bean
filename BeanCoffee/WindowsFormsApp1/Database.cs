using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Database
    {
        private MySqlConnection conn;

        public Database()
        {
            this.conn = GetConnection();
        }

        private MySqlConnection GetConnection()
        {
            string host = "192.168.3.139";
            string user = "root";
            string pwd = "1234";
            string database = "coffee";

            string conStar = string.Format(@"server={0};user{1};pws{2};database{3}", host, user, pwd, database);

            MySqlConnection conn = new MySqlConnection(conStar);

            try
            {
                conn.Open();
                MessageBox.Show("연결 성공");
                return conn;

            }
            catch
            {
                MessageBox.Show("연결 실패");
                return null;
            }
        }

        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    MessageBox.Show("NonQuery 실패");
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
                else
                {
                    MessageBox.Show("Reader 실패");
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
                
            }
            catch
            {
                return null;
            }
        }

        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }

    }
}
