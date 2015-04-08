namespace HSN_Dropship
{
    partial class POVerify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POVerify));
            this.textBoxPOVerify = new System.Windows.Forms.TextBox();
            this.buttonPOVerify = new System.Windows.Forms.Button();
            this.textBoxPOCheck = new System.Windows.Forms.TextBox();
            this.buttonPOVHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCheckStatus = new System.Windows.Forms.Label();
            this.labelUpdated = new System.Windows.Forms.Label();
            this.buttonClearShipDate = new System.Windows.Forms.Button();
            this.ShipDatePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonSetShipDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPOVerify
            // 
            this.textBoxPOVerify.Location = new System.Drawing.Point(13, 28);
            this.textBoxPOVerify.Multiline = true;
            this.textBoxPOVerify.Name = "textBoxPOVerify";
            this.textBoxPOVerify.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPOVerify.Size = new System.Drawing.Size(131, 213);
            this.textBoxPOVerify.TabIndex = 0;
            // 
            // buttonPOVerify
            // 
            this.buttonPOVerify.Location = new System.Drawing.Point(150, 13);
            this.buttonPOVerify.Name = "buttonPOVerify";
            this.buttonPOVerify.Size = new System.Drawing.Size(75, 23);
            this.buttonPOVerify.TabIndex = 1;
            this.buttonPOVerify.Text = "PO Verify";
            this.buttonPOVerify.UseVisualStyleBackColor = true;
            this.buttonPOVerify.Click += new System.EventHandler(this.buttonPOVerify_Click);
            // 
            // textBoxPOCheck
            // 
            this.textBoxPOCheck.Location = new System.Drawing.Point(150, 167);
            this.textBoxPOCheck.Multiline = true;
            this.textBoxPOCheck.Name = "textBoxPOCheck";
            this.textBoxPOCheck.Size = new System.Drawing.Size(85, 90);
            this.textBoxPOCheck.TabIndex = 2;
            this.textBoxPOCheck.Text = "Takes value from big text box and pastes it into this textbox. This is invisible." +
    "";
            this.textBoxPOCheck.Visible = false;
            // 
            // buttonPOVHelp
            // 
            this.buttonPOVHelp.Location = new System.Drawing.Point(150, 138);
            this.buttonPOVHelp.Name = "buttonPOVHelp";
            this.buttonPOVHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonPOVHelp.TabIndex = 3;
            this.buttonPOVHelp.Text = "Help";
            this.buttonPOVHelp.UseVisualStyleBackColor = true;
            this.buttonPOVHelp.Click += new System.EventHandler(this.buttonPOVHelp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Paste PO Numbers Below";
            // 
            // labelCheckStatus
            // 
            this.labelCheckStatus.AutoSize = true;
            this.labelCheckStatus.Location = new System.Drawing.Point(147, 248);
            this.labelCheckStatus.Name = "labelCheckStatus";
            this.labelCheckStatus.Size = new System.Drawing.Size(90, 13);
            this.labelCheckStatus.TabIndex = 5;
            this.labelCheckStatus.Text = "labelCheckStatus";
            this.labelCheckStatus.Visible = false;
            // 
            // labelUpdated
            // 
            this.labelUpdated.AutoSize = true;
            this.labelUpdated.Location = new System.Drawing.Point(10, 248);
            this.labelUpdated.Name = "labelUpdated";
            this.labelUpdated.Size = new System.Drawing.Size(77, 13);
            this.labelUpdated.TabIndex = 6;
            this.labelUpdated.Text = "Last Updated: ";
            // 
            // buttonClearShipDate
            // 
            this.buttonClearShipDate.Location = new System.Drawing.Point(150, 42);
            this.buttonClearShipDate.Name = "buttonClearShipDate";
            this.buttonClearShipDate.Size = new System.Drawing.Size(75, 23);
            this.buttonClearShipDate.TabIndex = 7;
            this.buttonClearShipDate.Text = "Clear Date";
            this.buttonClearShipDate.UseVisualStyleBackColor = true;
            this.buttonClearShipDate.Click += new System.EventHandler(this.buttonClearShipDate_click);
            // 
            // ShipDatePicker
            // 
            this.ShipDatePicker.CustomFormat = "yyyy-MM-dd";
            this.ShipDatePicker.Enabled = false;
            this.ShipDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ShipDatePicker.Location = new System.Drawing.Point(150, 112);
            this.ShipDatePicker.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.ShipDatePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.ShipDatePicker.Name = "ShipDatePicker";
            this.ShipDatePicker.Size = new System.Drawing.Size(80, 20);
            this.ShipDatePicker.TabIndex = 10;
            // 
            // buttonSetShipDate
            // 
            this.buttonSetShipDate.Location = new System.Drawing.Point(150, 71);
            this.buttonSetShipDate.Name = "buttonSetShipDate";
            this.buttonSetShipDate.Size = new System.Drawing.Size(75, 23);
            this.buttonSetShipDate.TabIndex = 11;
            this.buttonSetShipDate.Text = "Set Date";
            this.buttonSetShipDate.UseVisualStyleBackColor = true;
            this.buttonSetShipDate.Click += new System.EventHandler(this.buttonSetShipDate_click);
            // 
            // POVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 269);
            this.Controls.Add(this.buttonSetShipDate);
            this.Controls.Add(this.ShipDatePicker);
            this.Controls.Add(this.buttonClearShipDate);
            this.Controls.Add(this.labelUpdated);
            this.Controls.Add(this.labelCheckStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPOVHelp);
            this.Controls.Add(this.textBoxPOCheck);
            this.Controls.Add(this.buttonPOVerify);
            this.Controls.Add(this.textBoxPOVerify);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(253, 308);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(253, 308);
            this.Name = "POVerify";
            this.Text = "POVerify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.POVerify_FormClosing);
            this.Load += new System.EventHandler(this.POVerify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPOVerify;
        private System.Windows.Forms.Button buttonPOVerify;
        private System.Windows.Forms.TextBox textBoxPOCheck;
        private System.Windows.Forms.Button buttonPOVHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCheckStatus;
        private System.Windows.Forms.Label labelUpdated;
        private System.Windows.Forms.Button buttonClearShipDate;
        public System.Windows.Forms.DateTimePicker ShipDatePicker;
        private System.Windows.Forms.Button buttonSetShipDate;
    }
}