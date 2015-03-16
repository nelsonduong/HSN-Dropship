using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;


namespace HSN_Dropship
{
    public partial class ResultSet : Form
    {
        public ResultSet()
        {
            InitializeComponent();
        }

        private void dataGridViewSQLResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewSQLResult.Columns[e.ColumnIndex].Name == "PO Date")
            {
                if (e.Value != null)
                {
                    try
                    {
                        dataGridViewSQLResult.Columns[e.ColumnIndex].DefaultCellStyle.Format = "yyyy'/'MM'/'dd";

                        System.Text.StringBuilder dateString = new System.Text.StringBuilder();
                        DateTime theDate = DateTime.Parse(e.Value.ToString());

                        dateString.Append(theDate.Month);
                        dateString.Append("/");
                        dateString.Append(theDate.Day);
                        dateString.Append("/");
                        dateString.Append(theDate.Year.ToString().Substring(2));
                        e.Value = dateString.ToString();
                        e.FormattingApplied = true;

                    }
                    catch (FormatException)
                    {
                        e.FormattingApplied = false;
                    }
                }
            }

        }

        private void ResultSet_Load(object sender, EventArgs e)
        {
            labelExportStatus.Text = "";
        }
        public void saveFileCSV_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileCSV.FileName;
        }
        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            saveFileCSV.Filter = "CSV file (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileCSV.ShowDialog() == DialogResult.OK)
            {
                string outputFile = saveFileCSV.FileName;
                if (dataGridViewSQLResult.RowCount > 0)
                {
                    string value = "";
                    DataGridViewRow dr = new DataGridViewRow();
                    StreamWriter swOut = new StreamWriter(outputFile);
                    //write header rows to csv
                    if (HSNDropship.buttonSummaryText == "Accounting")
                    {

                    }
                    else
                    {
                        for (int i = 0; i <= dataGridViewSQLResult.Columns.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                swOut.Write(",");
                            }
                            swOut.Write(dataGridViewSQLResult.Columns[i].HeaderText);
                        }
                        swOut.WriteLine();
                    }
                    //write DataGridView rows to csv
                    for (int j = 0; j <= dataGridViewSQLResult.Rows.Count - 1; j++)
                    {
                        if (j > 0)
                        {
                            swOut.WriteLine();
                        }

                        dr = dataGridViewSQLResult.Rows[j];

                        for (int i = 0; i <= dataGridViewSQLResult.Columns.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                swOut.Write(",");
                            }

                            value = dr.Cells[i].Value.ToString();
                            //replace comma's with spaces
                            value = value.Replace(',', ' ');
                            //replace embedded newlines with spaces
                            value = value.Replace(Environment.NewLine, " ");

                            swOut.Write(value);
                        }
                    }
                    swOut.Close();
                    labelExportStatus.Text = "CSV File Exported!";

                    //Setting the process date column in the database to the current date. This way we won't have a duplicate shipment tomorrow.
                    if (MySQLConnection.OpenConnection() == true)
                    {
                        string today = DateTime.Now.ToString("yyyy-MM-dd");
                        MySqlCommand uq = new MySqlCommand("UPDATE `HSN` SET `ShipDate` = '" + today + "' WHERE `ProcessedDate` = '" + today + "';", MySQLConnection.connection);
                        uq.ExecuteNonQuery();
                        MySQLConnection.CloseConnection();
                    }
                }
                
                else
                {
                    MessageBox.Show("You must select a directory and file name to save!");
                }
            }
        }
    }
}
