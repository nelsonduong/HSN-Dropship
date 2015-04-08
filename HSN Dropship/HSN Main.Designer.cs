namespace HSN_Dropship
{
    partial class HSNDropship
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HSNDropship));
            this.buttonImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSummary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxBatches = new System.Windows.Forms.CheckBox();
            this.textBoxBatchQty = new System.Windows.Forms.TextBox();
            this.labelTextBatchQty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.dateTimePickerShipDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelOutstanding = new System.Windows.Forms.Label();
            this.labelUploadStatus = new System.Windows.Forms.Label();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonImport
            // 
            this.buttonImport.Enabled = false;
            this.buttonImport.Location = new System.Drawing.Point(6, 38);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(108, 23);
            this.buttonImport.TabIndex = 4;
            this.buttonImport.Text = "Import / Update";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 212);
            this.label1.MaximumSize = new System.Drawing.Size(500, 0);
            this.label1.MinimumSize = new System.Drawing.Size(0, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "<-- Will import the PO Raw File and \"update\" the database. Then it will check if " +
    "the POs have already been imported by checking for a process date. I need to tes" +
    "t the performance of updating. ";
            this.label1.Visible = false;
            // 
            // buttonSummary
            // 
            this.buttonSummary.Enabled = false;
            this.buttonSummary.Location = new System.Drawing.Point(6, 67);
            this.buttonSummary.Name = "buttonSummary";
            this.buttonSummary.Size = new System.Drawing.Size(108, 23);
            this.buttonSummary.TabIndex = 5;
            this.buttonSummary.Text = "Generate Summary";
            this.buttonSummary.UseVisualStyleBackColor = true;
            this.buttonSummary.Click += new System.EventHandler(this.buttonSummary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 246);
            this.label2.MaximumSize = new System.Drawing.Size(500, 0);
            this.label2.MinimumSize = new System.Drawing.Size(0, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "<-- Generate the daily shipped summary + inv. numbers + daily shipped numbers. It" +
    " asks where you where you want the file to be saved.";
            this.label2.Visible = false;
            // 
            // buttonCW
            // 
            this.buttonCW.Enabled = false;
            this.buttonCW.Location = new System.Drawing.Point(6, 96);
            this.buttonCW.Name = "buttonCW";
            this.buttonCW.Size = new System.Drawing.Size(108, 23);
            this.buttonCW.TabIndex = 6;
            this.buttonCW.Text = "Generate CW Files";
            this.buttonCW.UseVisualStyleBackColor = true;
            this.buttonCW.Click += new System.EventHandler(this.buttonCW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 275);
            this.label3.MaximumSize = new System.Drawing.Size(500, 0);
            this.label3.MinimumSize = new System.Drawing.Size(0, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(495, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.Visible = false;
            // 
            // checkBoxBatches
            // 
            this.checkBoxBatches.AutoSize = true;
            this.checkBoxBatches.Enabled = false;
            this.checkBoxBatches.Location = new System.Drawing.Point(29, 127);
            this.checkBoxBatches.Name = "checkBoxBatches";
            this.checkBoxBatches.Size = new System.Drawing.Size(64, 17);
            this.checkBoxBatches.TabIndex = 7;
            this.checkBoxBatches.Text = "Batches";
            this.checkBoxBatches.UseVisualStyleBackColor = true;
            // 
            // textBoxBatchQty
            // 
            this.textBoxBatchQty.Enabled = false;
            this.textBoxBatchQty.Location = new System.Drawing.Point(29, 163);
            this.textBoxBatchQty.Name = "textBoxBatchQty";
            this.textBoxBatchQty.Size = new System.Drawing.Size(63, 20);
            this.textBoxBatchQty.TabIndex = 8;
            // 
            // labelTextBatchQty
            // 
            this.labelTextBatchQty.AutoSize = true;
            this.labelTextBatchQty.Enabled = false;
            this.labelTextBatchQty.Location = new System.Drawing.Point(24, 147);
            this.labelTextBatchQty.Name = "labelTextBatchQty";
            this.labelTextBatchQty.Size = new System.Drawing.Size(74, 13);
            this.labelTextBatchQty.TabIndex = 6;
            this.labelTextBatchQty.Text = "Qty Per Batch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 321);
            this.label5.MaximumSize = new System.Drawing.Size(500, 0);
            this.label5.MinimumSize = new System.Drawing.Size(0, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(483, 35);
            this.label5.TabIndex = 1;
            this.label5.Text = "<-- Check the box if we are planning on batch printing. If we are the Qty Per Bat" +
    "ch Textbox becomes visible.\r\n";
            this.label5.Visible = false;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.dateTimePickerShipDate);
            this.groupBoxMain.Controls.Add(this.label4);
            this.groupBoxMain.Controls.Add(this.buttonImport);
            this.groupBoxMain.Controls.Add(this.labelTextBatchQty);
            this.groupBoxMain.Controls.Add(this.buttonSummary);
            this.groupBoxMain.Controls.Add(this.textBoxBatchQty);
            this.groupBoxMain.Controls.Add(this.buttonCW);
            this.groupBoxMain.Controls.Add(this.checkBoxBatches);
            this.groupBoxMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxMain.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMain.Location = new System.Drawing.Point(12, 9);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(121, 189);
            this.groupBoxMain.TabIndex = 7;
            this.groupBoxMain.TabStop = false;
            // 
            // dateTimePickerShipDate
            // 
            this.dateTimePickerShipDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerShipDate.Enabled = false;
            this.dateTimePickerShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerShipDate.Location = new System.Drawing.Point(20, 13);
            this.dateTimePickerShipDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerShipDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerShipDate.Name = "dateTimePickerShipDate";
            this.dateTimePickerShipDate.Size = new System.Drawing.Size(80, 20);
            this.dateTimePickerShipDate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Main";
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(79, 246);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(47, 23);
            this.buttonHelp.TabIndex = 2;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(18, 246);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(47, 23);
            this.buttonLogin.TabIndex = 1;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(39, 204);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(63, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.Visible = false;
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // labelOutstanding
            // 
            this.labelOutstanding.AutoSize = true;
            this.labelOutstanding.Location = new System.Drawing.Point(3, 207);
            this.labelOutstanding.MinimumSize = new System.Drawing.Size(138, 0);
            this.labelOutstanding.Name = "labelOutstanding";
            this.labelOutstanding.Size = new System.Drawing.Size(138, 13);
            this.labelOutstanding.TabIndex = 8;
            this.labelOutstanding.Text = "160, 315";
            this.labelOutstanding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelOutstanding.Visible = false;
            // 
            // labelUploadStatus
            // 
            this.labelUploadStatus.AutoSize = true;
            this.labelUploadStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUploadStatus.ForeColor = System.Drawing.Color.HotPink;
            this.labelUploadStatus.Location = new System.Drawing.Point(3, 227);
            this.labelUploadStatus.MinimumSize = new System.Drawing.Size(138, 0);
            this.labelUploadStatus.Name = "labelUploadStatus";
            this.labelUploadStatus.Size = new System.Drawing.Size(138, 13);
            this.labelUploadStatus.TabIndex = 8;
            this.labelUploadStatus.Text = "labelOutstanding";
            this.labelUploadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelUploadStatus.Visible = false;
            // 
            // HSNDropship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(144, 276);
            this.Controls.Add(this.labelOutstanding);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUploadStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(160, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(160, 315);
            this.Name = "HSNDropship";
            this.ShowIcon = false;
            this.Text = "HSN Dropship";
            this.TopMost = true;
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //this.Load += new System.EventHandler(MySQLConnection.HSNDropship_Load);
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxBatches;
        private System.Windows.Forms.TextBox textBoxBatchQty;
        private System.Windows.Forms.Label labelTextBatchQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelOutstanding;
        public System.Windows.Forms.Label labelUploadStatus;
        public System.Windows.Forms.DateTimePicker dateTimePickerShipDate;
        public System.Windows.Forms.Button buttonSummary;
    }
}

