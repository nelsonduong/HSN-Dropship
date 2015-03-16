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
using System.Text.RegularExpressions;

namespace HSN_Dropship
{
    public partial class POVerify : Form
    {
        public POVerify()
        {
            InitializeComponent();
        }
        private void POVerify_Load(object sender, EventArgs e)
        {
            if (MySQLConnection.OpenConnection() == true)
            {
                MySqlCommand POVCommand = new MySqlCommand("SELECT `PO Date` FROM `HSN` ORDER BY `PO Date` DESC LIMIT 1;", MySQLConnection.connection);
                string dateResult = POVCommand.ExecuteScalar().ToString();
                DateTime datevalue = DateTime.Parse(dateResult);
                labelUpdated.Text = "Last Updated: " + datevalue.ToString("yyyy-MM-dd");
            }
            MySQLConnection.CloseConnection();
        }
        void POVerify_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void buttonPOVerify_Click(object sender, EventArgs e)
        {
            labelCheckStatus.Visible = false;
            labelCheckStatus.Text = "";
            textBoxPOCheck.Text = textBoxPOVerify.Text;
            textBoxPOVerify.Text = "";
            if (MySQLConnection.OpenConnection() == true)
            {
                string MainString = textBoxPOCheck.Text;

                StringBuilder lineInfoDB = new StringBuilder();
                StringBuilder lineInfoSearch = new StringBuilder();

                foreach (string lineSearch in textBoxPOCheck.Lines)
                {
                    string poNum = lineSearch;

                    MySqlCommand POVCommand = new MySqlCommand("SELECT EXISTS(SELECT 1 FROM `HSN` WHERE `PO Number` = '" + poNum + "') AS myCheck;", MySQLConnection.connection);
                    string result = POVCommand.ExecuteScalar().ToString();
                    string poZero = "0";

                    if (result == poZero)
                    {
                        textBoxPOVerify.AppendText(poNum + "\n");
                    }
                    textBoxPOVerify.Text = Regex.Replace(textBoxPOVerify.Text, "(?<Text>.*)(?:[\r\n]?(?:\r\n)?)", "${Text}\r\n");
                    textBoxPOVerify.Text = Regex.Replace(textBoxPOVerify.Text, "\\s+\r\n", "\r\n");
                }

            }
            MySQLConnection.CloseConnection();
            /*
            if (textBoxPOVerify.Text == "")
            {
                labelCheckStatus.Visible = true;
                labelCheckStatus.ForeColor = Color.Green;
                labelCheckStatus.Text = "All POs Good!";
            }
            else if (textBoxPOVerify.Text != "")
            {
                labelCheckStatus.Visible = true;
                labelCheckStatus.ForeColor = Color.Red;
                labelCheckStatus.Text = "Error!";
            } */
        }
           
        private void buttonPOVHelp_Click(object sender, EventArgs e)
        {
            string help;
            help = "HSN PO Verify Tool v1.0\n\n\nThis tool will check if the number(s) in the textbox are in the HSN drop ship database.\n\nIf the number is not in the database (because of typo/PO doesn't exist/etc.), it will remain in the textbox.\n\nCopy and paste your PO numbers in the textbox. Then hit the 'PO Verify' Button. If the PO is valid it will dissapear from the textbox. If it is invalid, it will remain.\n\nThe 'Last Updated' shows the date that the last drop ship data was imported.";
            MessageBox.Show(help, "HSN PO Verify Tool Help");
        }
    }
}
