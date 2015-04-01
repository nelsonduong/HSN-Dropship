using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace HSN_Dropship
{
    public partial class MySQLConnection
    {
        public static string server, database, uid, password;
        public static MySqlConnection connection;

        //198.46.137.123
        //96.229.127.8
        public static void HSNDropship_Load(object sender, EventArgs e)
        {
            server = "visual-land.com"; database = "dropship"; uid = "dropship"; password = "ds2db";
            string conNVLDB;
            conNVLDB = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "Allow User Variables=True" + ";" + "convert zero datetime=True" + ";";

            connection = new MySqlConnection(conNVLDB);    
        }
        
        
        public static bool OpenConnection()
        {
            try
            {
                connection.Open();
                //MySqlCommand cmd = new MySqlCommand("set net_write_timeout=99999999; set net_read_timeout=99999999; set global wait_timeout = 99999999;", connection); // Setting timeout on mysqlServer
                //cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        public static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
         
    }
}
