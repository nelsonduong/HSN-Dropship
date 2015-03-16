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
using Excel = Microsoft.Office.Interop.Excel;

namespace HSN_Dropship
{
    public partial class HSNDropship : Form
    {
        public static string fileName;
        public static string filePath;
        public static string buttonSummaryText;

        public HSNDropship()
        {
            InitializeComponent();
            dateTimePickerShipDate.Value = DateTime.Now;
        }

        public void buttonHelp_Click(object sender, EventArgs e)
        {
            string help;
            help = "HSN Drop Ship Tool v1.1\n\n\u2022 To start, click on the Login button on the main form to login.\n\u2022 Once you have logged in, a few options will be enabled.\n\u2022 Enter the password that was provided to you.\n\u2022 If you have forgotten the password, please contact Nelson.\n\u2022 For more help, just ask Nelson! This is continually being updated.\n\n\u2022 Password for PO Checker is 'rdb'.";
            MessageBox.Show(help, "HSN Drop Ship Tool Help");
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = buttonLogin;
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = null;
        }

        public void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Visible == false && textBoxPassword.Enabled == false)
            {
                textBoxPassword.Visible = true;
                textBoxPassword.Enabled = true;
                textBoxPassword.Focus();
            }
            if (textBoxPassword.Visible == true && textBoxPassword.Enabled == true)
            {

                if (textBoxPassword.Text == "biscuits")
                {
                    dateTimePickerShipDate.Enabled = true;
                    buttonImport.Enabled = true;
                    textBoxPassword.Visible = false;
                    textBoxPassword.Enabled = false;
                    labelOutstanding.Visible = true;
                    labelOutstanding.Text = "0 Outstanding Shipments";
                    buttonLogin.Enabled = false;
                    buttonCW.Enabled = true;
                    buttonSummary.Enabled = true;
                    if (MySQLConnection.OpenConnection() == true)
                    {
                        MySqlCommand HSNic;
                        HSNic = new MySqlCommand("SELECT Count(`PO Number`) FROM `HSN` WHERE `ShipDate` IS NULL;", MySQLConnection.connection);
                        int numberOfUploads = Convert.ToInt32(HSNic.ExecuteScalar());
                        labelOutstanding.Text = numberOfUploads.ToString() + " POs Outstanding";
                        MySQLConnection.CloseConnection();
                    }
                }

                if (textBoxPassword.Text == "acct4inv")
                {
                    dateTimePickerShipDate.Enabled = true;
                    textBoxPassword.Visible = false;
                    textBoxPassword.Enabled = false;
                    buttonLogin.Enabled = false;
                    buttonSummary.Enabled = true;
                    buttonSummaryText = "Accounting";
                    if (MySQLConnection.OpenConnection() == true)
                    {
                        MySqlCommand HSNic;
                        HSNic = new MySqlCommand("SELECT Count(`PO Number`) FROM `HSN` WHERE `ShipDate` IS NULL;", MySQLConnection.connection);
                        int numberOfUploads = Convert.ToInt32(HSNic.ExecuteScalar());
                        labelOutstanding.Text = numberOfUploads.ToString() + " POs Outstanding";
                        MySQLConnection.CloseConnection();
                    }
                }

                if (textBoxPassword.Text == "rdb")
                {
                    this.Hide();
                    POVerify pv = new POVerify();
                    pv.Show();
                }
                else
                {
                    textBoxPassword.Text = "";
                    textBoxPassword.Focus();
                }

            }
        }

        public void buttonImport_Click(object sender, EventArgs e)
        {
            labelUploadStatus.Text = "";

            if (MessageBox.Show("Is " + dateTimePickerShipDate.Text + " the correct ship date? ", "Confirm Ship Date", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                #region Upload text file into database
                OpenFileDialog openHSNExcel = new OpenFileDialog();
                openHSNExcel.CheckFileExists = true;
                openHSNExcel.CheckPathExists = true;
                openHSNExcel.DefaultExt = "txt";
                openHSNExcel.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openHSNExcel.FilterIndex = 1;
                openHSNExcel.RestoreDirectory = true;
                openHSNExcel.ReadOnlyChecked = true;
                openHSNExcel.ShowReadOnly = true;

                if (openHSNExcel.ShowDialog() == DialogResult.OK)
                {
                    fileName = openHSNExcel.FileName;
                    String filePath = System.IO.Path.GetFullPath(fileName);
                }

                if (fileName == null)
                {
                    MessageBox.Show("Please select a correct file!");
                }
                else if (MessageBox.Show("Are you sure you want to upload this file?", "Import to Database", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //MessageBox.Show("Upload code here");
                    if (MySQLConnection.OpenConnection() == true)
                    {
                        String fileNameA = System.IO.Path.GetFullPath(fileName);

                        String fileNameU = fileNameA.Replace(@"\", @"\\");

                        MySqlCommand nOU, HSNU, HSNc, biu1, biu2, biu3, biu4, biu5, miu1, miu2, miu3, miu4, miu5;
                        //Change the table name below to switch between usable tables.
                        nOU = new MySqlCommand("LOAD DATA LOCAL INFILE '" + fileNameU + "' IGNORE INTO TABLE `HSN` FIELDS TERMINATED BY '\t' LINES TERMINATED BY '\r\n' IGNORE 1 LINES (Sender,Receiver,`PO Number`,`Release Number`, @podate ,`Terms Info`,`FOB Info`,`Ship-To Name`,`Ship-To Address 1`,`Ship-To Address 2`,`Ship-To Location`,`Ship-To City`,`Ship-To State`,`Ship-To Postal Code`,`Ship-To Country`,`Ship-To Contact`,`Bill-To Name`,`Bill-To Address 1`,`Bill-To Address 2`,`Bill-To Location`,`Bill-To City`,`Bill-To State`,`Bill-To PostalCode`,`Bill-To Country`,`Bill-To Contact`,hdr_user_defined_field1,hdr_user_defined_field2,hdr_user_defined_field3,hdr_user_defined_field4,hdr_user_defined_field5,hdr_user_defined_field6,hdr_user_defined_field7,hdr_user_defined_field8,hdr_user_defined_field9,hdr_user_defined_field10,hdr_user_defined_field11,hdr_user_defined_field12,hdr_user_defined_field13,hdr_user_defined_field14,hdr_user_defined_field15,hdr_user_defined_field16,hdr_user_defined_field17,hdr_user_defined_field18,hdr_user_defined_field19,hdr_user_defined_field20,Notes,`Line Nbr`,`Supplier Item Nbr`,`Item Description`,Quantity,`Unit Price`,`UOM	Basis of UOM`,`Buyer Item Nbr`,`Manufacturer Item Nbr`,dtl_user_defined_field1,dtl_user_defined_field2,dtl_user_defined_field3,dtl_user_defined_field4,dtl_user_defined_field5,dtl_user_defined_field6,dtl_user_defined_field7,dtl_user_defined_field8,dtl_user_defined_field9,dtl_user_defined_field10,dtl_user_defined_field11,dtl_user_defined_field12,dtl_user_defined_field13,dtl_user_defined_field14,dtl_user_defined_field15,dtl_user_defined_field16,dtl_user_defined_field17,dtl_user_defined_field18,dtl_user_defined_field19,dtl_user_defined_field20,`PO Purpose`,`SAC Info`,`Delivery Date Requested`,`Last Delivery Date Requested`,`Sub-Line Item`,`Item Info`) set `PO Date` = str_to_date(@podate, '%m/%d/%Y'), `ProcessedDate` = '" + dateTimePickerShipDate.Text + "';", MySQLConnection.connection);
                        nOU.ExecuteNonQuery();
                #endregion
                        #region Update Buyer Item Nbr, Manufacturer Item Nbr, UPC

                        HSNU = new MySqlCommand("UPDATE `HSN` SET `hdr_user_defined_field18` = '1DA' WHERE `hdr_user_defined_field18` = '2-Day'; UPDATE `HSN` SET `hdr_user_defined_field18` = '2DA' WHERE `hdr_user_defined_field18` = 'Express'; UPDATE HSN AS H1 INNER JOIN (SELECT `PO Number`, @InvNumber:=@InvNumber+1 Invoice FROM `HSN`, (SELECT @InvNumber:= 0) AS IU WHERE `ProcessedDate` = '" + dateTimePickerShipDate.Text + "' ORDER BY `hdr_user_defined_field18` ASC, `Supplier Item Nbr` ASC) AS H2 SET H1.`InvNumber` = H2.`Invoice` WHERE H1.`PO Number` = H2.`PO Number`;", MySQLConnection.connection);
                        
                        string sdate = dateTimePickerShipDate.Text;

                        biu1 = new MySqlCommand("UPDATE HSN SET `Buyer Item Nbr` = 'ME107DTCBLKSOFT' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107DTCRYLSOFT' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107DTCPRPSOFT' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107DTCREDSOFT' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107DTCMAGSOFT' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107D8GBSPBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107D8GBSPGRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452304'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107D8GBSPRYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107D8GBSPPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107D8GBSPRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107D8GBSPPNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME107D8GBSPMAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-017-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-017-GRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478304'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-017-RYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-017-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-017-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-017-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-017-MAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-110D-16GB-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-110D-16GB-BLU' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449404'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-110D-16GB-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-110D-16GB-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-110D-16GB-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-10D-16GB-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839001';", MySQLConnection.connection);
                        biu2 = new MySqlCommand("UPDATE HSN SET `Buyer Item Nbr` = 'ME8QS16KCBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8QS16KCGRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089304'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8QS16KCRYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8QS16KCPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8QS16KCRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8QS16KCPNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8QS16KCMAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-10D-16GB-BLU' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839404'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-10D-16GB-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-10D-16GB-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-10D-16GB-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-010-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-010-BLU' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871404'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-010-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-010-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-TC-010-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7F-16GB-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7F-16GB-GRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928304'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7F-16GB-RYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7F-16GB-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7F-16GB-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7F-16GB-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7F-16GB-MAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-BLU' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915404'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915649'; UPDATE HSN SET `Buyer Item Nbr` = '7D8TCSPFEAPBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962001'; UPDATE HSN SET `Buyer Item Nbr` = '7D8TCSPFEAPGRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962304'; UPDATE HSN SET `Buyer Item Nbr` = '7D8TCSPFEAPRYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962431'; UPDATE HSN SET `Buyer Item Nbr` = '7D8TCSPFEAPPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962502';", MySQLConnection.connection);
                        biu3 = new MySqlCommand("UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q16KCAPSPMAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q16KCAPSPRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q16KCAPSPPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q16KCAPSPRYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q16KCAPSPBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052001'; UPDATE HSN SET `Buyer Item Nbr` = '7D8TCSPFEAPRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962611'; UPDATE HSN SET `Buyer Item Nbr` = '7D8TCSPFEAPPNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962649'; UPDATE HSN SET `Buyer Item Nbr` = '7D8TCSPFEAPMAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16TCSPAPBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16TCSPAPBLU' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941404'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16TCSPAPPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16TCSPAPRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16TCSPAPPNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-BLU' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845404'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9D8TC-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KCAPSPBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KCAPSPBLU' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644404'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KCAPSPPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KCAPSPPNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KCAPSPRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCAPBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCAPGRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282304'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCAPPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCAPRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCAPPNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCAPMAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCAPRYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282B6S';", MySQLConnection.connection);
                        biu4 = new MySqlCommand("UPDATE HSN SET `Buyer Item Nbr` = 'ME-7Q-16GB-F-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7Q-16GB-F-GRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311304'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7Q-16GB-F-RYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7Q-16GB-F-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7Q-16GB-F-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7Q-16GB-F-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-7Q-16GB-F-MAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-PC-018-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-PC-018-MAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-PC-018-RYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-PC-018-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-PC-018-GRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305304'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-PC-018-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-PC-018-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KC25-BLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KC25-BLU' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565404'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KC25-PRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KC25-RED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME9Q16KC25-PNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565649';", MySQLConnection.connection);
                        biu5 = new MySqlCommand("UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCBLKBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCBLKGRN' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848304'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCBLKRYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCBLKPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCBLKRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCBLKPNK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848649'; UPDATE HSN SET `Buyer Item Nbr` = 'ME8Q8TCBLKMAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q5M16KCBLK' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780001'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q5M16KCMAG' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780686'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q5M16KCRYL' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780431'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q5M16KCRED' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780611'; UPDATE HSN SET `Buyer Item Nbr` = 'ME10Q5M16KCPRP' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780502'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-89W-BK-16GB' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401789'; UPDATE HSN SET `Buyer Item Nbr` = 'ME-101W-DK-16GB' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401792';", MySQLConnection.connection);
                        miu1 = new MySqlCommand("UPDATE HSN SET `Manufacturer Item Nbr` = '828063818727' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063818741' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063818765' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063818789' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063818772' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063818703' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063918700' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405311686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063420821' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063420845' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063420852' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063420883' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063420876' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063420807' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063420869' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '395089686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063312720' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063312768' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063312782' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063312775' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063412703' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '297624686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063516722' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063516746' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063516760' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063516784' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063516777' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063516708' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063616705' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305452686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301724' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301748' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063401714' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301786' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301779' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301700' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301793' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '305478686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063413021' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063413014' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449404'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063413083' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063413076' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063413007' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '310449649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512021' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839001';", MySQLConnection.connection);
                        miu2 = new MySqlCommand("UPDATE HSN SET `Manufacturer Item Nbr` = '828063512014' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839404'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512083' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512076' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512007' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316839649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301021' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301014' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871404'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301083' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301076' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063301007' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '316871649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063617726' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063617740' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063617764' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063617788' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063617771' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063617702' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063717709' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '328928686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063412925' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063412918' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915404'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063412987' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063412970' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063412901' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '340915649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063519723' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063519747' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063519716' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063519785' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962502';", MySQLConnection.connection);
                        miu3 = new MySqlCommand("UPDATE HSN SET `Manufacturer Item Nbr` = '828063612202' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063612271' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063612288' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063612219' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063612226' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '376052001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063519778' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063519709' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063519792' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '348962686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063414929' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063414912' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941404'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063414981' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063414974' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063414905' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '371941649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512922' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512915' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845404'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512984' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512977' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063512908' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '372845649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063416923' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063416916' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644404'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063416985' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063416909' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063416978' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '381644611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063316827' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063316841' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063316889' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063316872' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063316803' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063316865' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063316858' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '382282B6S';", MySQLConnection.connection);
                        miu4 = new MySqlCommand("UPDATE HSN SET `Manufacturer Item Nbr` = '828063302806' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063302868' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063302851' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063302820' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063302844' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063302875' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063302882' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '405305502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417920' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417913' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565404'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417982' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417975' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417982' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401565649';", MySQLConnection.connection);
                        miu5 = new MySqlCommand("UPDATE HSN SET `Manufacturer Item Nbr` = '828063417821' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417845' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848304'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417852' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417883' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417876' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417807' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848649'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063417869' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '413848686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063712223' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780001'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063712209' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780686'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063712216' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780431'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063712278' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780611'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063712285' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '407780502'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063540925' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401789'; UPDATE HSN SET `Manufacturer Item Nbr` = '828063540123' WHERE `ProcessedDate` = '" + sdate + "' AND `Supplier Item Nbr` = '401792';", MySQLConnection.connection);

                        biu1.ExecuteNonQuery();
                        biu2.ExecuteNonQuery();
                        biu3.ExecuteNonQuery();
                        biu4.ExecuteNonQuery();
                        biu5.ExecuteNonQuery();
                        miu1.ExecuteNonQuery();
                        miu2.ExecuteNonQuery();
                        miu3.ExecuteNonQuery();
                        miu4.ExecuteNonQuery();
                        miu5.ExecuteNonQuery();
                        HSNU.ExecuteNonQuery();

                        #endregion

                        #region Select POs that have not been processed
                        HSNc = new MySqlCommand("SELECT Count(`PO Number`) FROM `HSN` WHERE `ShipDate` IS NULL;", MySQLConnection.connection);
                        int numberOfUploads = Convert.ToInt32(HSNc.ExecuteScalar());
                        labelOutstanding.Text = numberOfUploads.ToString() + " POs Outstanding";
                        labelUploadStatus.Visible = true;
                        labelUploadStatus.Text = "Upload Completed";
                        #endregion

                        MySQLConnection.CloseConnection();

                    }
                }
                else { MessageBox.Show("Select the correct ship date!"); }
            }
        }

        private void buttonSummary_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Is " + dateTimePickerShipDate.Text + " the correct ship date? ", "Confirm Ship Date", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MySQLConnection.OpenConnection() == true)
                {
                    MySqlDataAdapter sq;
                    MySqlCommand iuq, DSSInputHSN;
                    int row = 1;

                    #region HSN Daily Ship Summary
                    if (buttonSummaryText != "Accounting")
                    {

                        OpenFileDialog DSOpen = new OpenFileDialog();
                        DSOpen.CheckFileExists = true;
                        DSOpen.CheckPathExists = true;
                        DSOpen.Title = "Select Today's Daily Dropship Summary Excel File";
                        DSOpen.InitialDirectory = @"\\DATA\DATA Public\Dropship Daily FILES";
                        DSOpen.DefaultExt = "xlsx";
                        DSOpen.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        DSOpen.FilterIndex = 1;
                        DSOpen.RestoreDirectory = true;
                        DSOpen.ReadOnlyChecked = false;
                        DSOpen.ShowReadOnly = false;
                        if (DSOpen.ShowDialog() == DialogResult.OK)
                        {
                            filePath = DSOpen.FileName;
                            String fileNames = System.IO.Path.GetFullPath(filePath);

                            Excel.Application DSSummaryApplication;
                            Excel.Worksheet DSSummaryWorksheet;
                            Excel.Workbook DSSummaryWorkbook;


                            DSSummaryApplication = new Excel.Application();
                            DSSummaryWorkbook = (Excel.Workbook)(DSSummaryApplication.Workbooks.Open(filePath,
                                Type.Missing, true, Type.Missing, Type.Missing, Type.Missing,
                                true, Type.Missing, Type.Missing, false, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing));
                            DSSummaryWorksheet = (Excel.Worksheet)DSSummaryWorkbook.Worksheets["SummaryValues"];
                            DSSummaryApplication.Visible = true;
                            DSSummaryWorksheet.Select(Type.Missing);
                            Excel.Range DSSInputRangeHSN = (Excel.Range)DSSummaryWorksheet.Cells[5, 1];
                            DSSInputRangeHSN.Select();

                            DSSInputHSN = new MySqlCommand("SELECT `Buyer Item Nbr`, COUNT(`Buyer Item Nbr`) FROM HSN WHERE `ShipDate` = '" + dateTimePickerShipDate.Text + "' AND `Quantity` > '0' GROUP BY `Buyer Item Nbr`;", MySQLConnection.connection);
                            MySqlDataReader drDSSInputHSN = DSSInputHSN.ExecuteReader();

                            while (drDSSInputHSN.Read())
                            {
                                for (int col = 0; col < drDSSInputHSN.FieldCount; col++)
                                {
                                    DSSummaryWorksheet.Cells[row + 1, col + 1] = drDSSInputHSN.GetValue(col);
                                }
                                row++;
                            }

                            drDSSInputHSN.Close();
                        }
                        if (filePath == null)
                        { MessageBox.Show("Please select a file!"); }
                    }
                    #endregion

                    #region HSN Invoice Uploads
                    if (buttonSummaryText == "Accounting")
                    {
                        iuq = new MySqlCommand("UPDATE HSN AS H1 Inner JOIN (SELECT `PO Number`, AcctInvN FROM (SELECT `PO Number`, @AcctInvNumber:=@AcctInvNumber+1 AcctInvN, IF(@AcctInvNumber < 500, '1', @AcctInvNumber:= 0) FROM `HSN`, (SELECT @AcctInvNumber:= 0) AS IU WHERE `ProcessedDate` = '" + dateTimePickerShipDate.Text + "') AS H2) AS H3 SET H1.`AcctInvNumber` = H3.`AcctInvN` WHERE H1.`PO Number` = H3.`PO Number`; UPDATE HSN AS H1 Inner JOIN (SELECT `PO Number`, `CountUp` FROM (SELECT `PO Number`, @CountUp:=@CountUp+1 CountUp FROM `HSN`, (SELECT @CountUp:= 0) AS IU WHERE `ProcessedDate` = '" + dateTimePickerShipDate.Text + "') AS H2) AS H3 SET H1.`NumOfOrders` = H3.`CountUp` WHERE H1.`PO Number` = H3.`PO Number`; UPDATE HSN AS H1, (SELECT MAX(`NumOfOrders`) AS MaxCount FROM HSN WHERE `ProcessedDate` = '" + dateTimePickerShipDate.Text + "') AS H2 SET H1.NumOfOrders = H2.MaxCount WHERE H1.`ProcessedDate` = '" + dateTimePickerShipDate.Text + "';", MySQLConnection.connection);
                        sq = new MySqlDataAdapter("SELECT 'HSN', CONCAT('HSN',CAST(DATE_FORMAT(`ProcessedDate`, '%y%m%d')AS CHAR), '-', CASE WHEN `UplNum` < 10 THEN CAST(CONCAT ('0', `UplNum`)AS CHAR) ELSE CAST(`UplNum` AS CHAR) END) AS `CInvNum`, '', 'FALSE', '', `ProcessedDate`, '', 'FALSE', '', '', 'FALSE', 'HSN', '1 HSN Drive', '', 'St. Petersburg', 'FL', '33729', '', '', 'UPS Ground', `ProcessedDate`, DATE_ADD(`ProcessedDate`, INTERVAL 30 DAY) AS DATE_ADD, '', '', 'Net 30 Days', '', '1100', '', '', 'FALSE', '', 'FALSE', '', 'FALSE', NumOfDist, AcctInvN, '0', 'FALSE', 'FALSE', `Quantity`, '', `Buyer Item Nbr`, '', '0', H1.`PO Number`, '4000', `Unit Price` + 1.5, '1', '', '0', (`Unit Price` + 1.5)*-1, '<Each>', '1', '1', `Unit Price` + 1.5, '', '', '29', `CountUp`, '', '', '0', '0', '0' FROM `HSN` AS H1, (SELECT `PO Number`, @AcctInvNumber:=@AcctInvNumber+1 AcctInvN, @CountUp:=@Countup+1 CountUp, IF(@AcctInvNumber=@AcctInvNumber AND @AcctInvNumber<500, '1', @AcctInvNumber:= 0), CASE WHEN @AcctInvNumber = 1 THEN @UploadNumber:=@UploadNumber+1 ELSE @UploadNumber END AS UplNum, CASE WHEN @UploadNumber > (`NumOfOrders` DIV 500) THEN (`NumOfOrders` - (`NumOfOrders` DIV 500)*500) ELSE 500 END AS NumOfDist FROM `HSN`, (SELECT @AcctInvNumber:= 0) AS IU, (SELECT @UploadNumber:=0) AS UN, (SELECT @CountUp:=0) AS CU WHERE `ProcessedDate` = '" + dateTimePickerShipDate.Text + "' AND Quantity IS NOT NULL) AS H2 WHERE H1.`PO Number` = H2.`PO Number`;", MySQLConnection.connection);
                    iuq.ExecuteNonQuery();
                    DataSet sqds = new DataSet();
                    sq.Fill(sqds);
                    ResultSet rs = new ResultSet();
                    rs.Show();
                    rs.dataGridViewSQLResult.DataSource = sqds.Tables[0];
                    #endregion
                    
                    }
                    MySQLConnection.CloseConnection();
                }
            }
            else { MessageBox.Show("Select the correct ship date!"); }
        }

        private void buttonCW_Click(object sender, EventArgs e)
        {
            if (MySQLConnection.OpenConnection() == true)
            {
                MySqlDataAdapter tq;
                tq = new MySqlDataAdapter("SELECT `Sender`, `Receiver`, `PO Number`, `Release Number`, `PO Date`, `Terms Info`, `FOB Info`, `Ship-To Name`, `Ship-To Address 1`, `Ship-To Address 2`, `Ship-To Location`, `Ship-To City`, `Ship-To State`, CASE WHEN `Ship-To Postal Code` < 999 THEN CONCAT('00', `Ship-To Postal Code`, '-0000') WHEN `Ship-To Postal Code` < 9999 THEN CONCAT('0', `Ship-To Postal Code`, '-0000') WHEN `Ship-To Postal Code` < 99999 THEN CONCAT(`Ship-To Postal Code`, '-0000') WHEN `Ship-To Postal Code` < 99999999 THEN CONCAT('0',LEFT(`Ship-To Postal Code`, 4),'-',RIGHT(`Ship-To Postal Code`, 4)) ELSE CONCAT(LEFT(`Ship-To Postal Code`,5),'-',RIGHT(`Ship-To Postal Code`, 4)) END as 'Ship-To Postal Code', `Ship-To Country`, `Ship-To Contact`, `Bill-To Name`, `Bill-To Address 1`, `Bill-To Address 2`, `Bill-To Location`, `Bill-To City`, `Bill-To State`, `Bill-To PostalCode`, `Bill-To Country`, `Bill-To Contact`, `hdr_user_defined_field1`, `hdr_user_defined_field2`, `hdr_user_defined_field3`, `hdr_user_defined_field4`, `hdr_user_defined_field5`, `hdr_user_defined_field6`, `hdr_user_defined_field7`, `hdr_user_defined_field8`, `hdr_user_defined_field9`, `hdr_user_defined_field10`, `hdr_user_defined_field11`, `hdr_user_defined_field12`, `hdr_user_defined_field13`, `hdr_user_defined_field14`, `hdr_user_defined_field15`, `hdr_user_defined_field16`, `hdr_user_defined_field18`, `hdr_user_defined_field19`, `hdr_user_defined_field20`, `Notes`, `Line Nbr`, `Supplier Item Nbr`, `Item Description`, `Quantity`, `Unit Price`, `UOM	Basis of UOM`, `Buyer Item Nbr`, `Manufacturer Item Nbr`, `dtl_user_defined_field1`, `dtl_user_defined_field2`, `dtl_user_defined_field3`, `dtl_user_defined_field4`, `dtl_user_defined_field5`, `dtl_user_defined_field6`, `dtl_user_defined_field7`, `dtl_user_defined_field8`, `dtl_user_defined_field9`, `dtl_user_defined_field10`, `dtl_user_defined_field11`, `dtl_user_defined_field12`, `dtl_user_defined_field13`, `dtl_user_defined_field14`, `dtl_user_defined_field15`, `dtl_user_defined_field16`, `dtl_user_defined_field17`, `dtl_user_defined_field18`, `dtl_user_defined_field19`, `dtl_user_defined_field20`, `PO Purpose`, `SAC Info`, `Delivery Date Requested`, `Last Delivery Date Requested`, `Sub-Line Item`, `Item Info`, CONCAT('HSN', CAST(DATE_FORMAT(`ProcessedDate`, '%y%m%d') AS CHAR), '-', CASE WHEN `InvNumber` < '10' THEN CAST(CONCAT('00',`InvNumber`)AS CHAR) WHEN `InvNumber` > '9' AND `InvNumber` < '100' THEN CAST(CONCAT('0', `InvNumber`) AS CHAR) ELSE CAST(`InvNumber` AS CHAR) End) AS 'InvNumber' FROM `HSN` WHERE `ProcessedDate` = '" + dateTimePickerShipDate.Text + "' AND `Quantity` IS NOT NULL AND `ShipDate` IS NULL ORDER BY `InvNumber` ASC;", MySQLConnection.connection);
                DataSet tqds = new DataSet();
                tq.Fill(tqds);
                /** Opens the ResultSet form **/
                ResultSet rs = new ResultSet();
                rs.Show();
                rs.dataGridViewSQLResult.DataSource = tqds.Tables[0];
                MySQLConnection.CloseConnection();
            }
        }
    }
}
