namespace HSN_Dropship
{
    partial class ResultSet
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
            this.dataGridViewSQLResult = new System.Windows.Forms.DataGridView();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.saveFileCSV = new System.Windows.Forms.SaveFileDialog();
            this.labelExportStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSQLResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSQLResult
            // 
            this.dataGridViewSQLResult.AllowUserToAddRows = false;
            this.dataGridViewSQLResult.AllowUserToDeleteRows = false;
            this.dataGridViewSQLResult.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewSQLResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSQLResult.Location = new System.Drawing.Point(0, 26);
            this.dataGridViewSQLResult.Name = "dataGridViewSQLResult";
            this.dataGridViewSQLResult.ReadOnly = true;
            this.dataGridViewSQLResult.RowHeadersVisible = false;
            this.dataGridViewSQLResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSQLResult.Size = new System.Drawing.Size(984, 460);
            this.dataGridViewSQLResult.TabIndex = 10;
            this.dataGridViewSQLResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewSQLResult_CellFormatting);
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Location = new System.Drawing.Point(2, 1);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(70, 23);
            this.buttonExportCSV.TabIndex = 11;
            this.buttonExportCSV.Text = "CSV Export";
            this.buttonExportCSV.UseVisualStyleBackColor = true;
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);
            // 
            // saveFileCSV
            // 
            this.saveFileCSV.DefaultExt = "csv";
            this.saveFileCSV.RestoreDirectory = true;
            this.saveFileCSV.Title = "Save CSV File";
            this.saveFileCSV.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileCSV_FileOk);
            // 
            // labelExportStatus
            // 
            this.labelExportStatus.AutoSize = true;
            this.labelExportStatus.Location = new System.Drawing.Point(78, 6);
            this.labelExportStatus.Name = "labelExportStatus";
            this.labelExportStatus.Size = new System.Drawing.Size(89, 13);
            this.labelExportStatus.TabIndex = 12;
            this.labelExportStatus.Text = "labelExportStatus";
            // 
            // ResultSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 486);
            this.Controls.Add(this.labelExportStatus);
            this.Controls.Add(this.buttonExportCSV);
            this.Controls.Add(this.dataGridViewSQLResult);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 525);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 525);
            this.Name = "ResultSet";
            this.ShowIcon = false;
            this.Text = "Query Results";
            this.Load += new System.EventHandler(this.ResultSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSQLResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewSQLResult;
        private System.Windows.Forms.Button buttonExportCSV;
        private System.Windows.Forms.SaveFileDialog saveFileCSV;
        private System.Windows.Forms.Label labelExportStatus;

    }
}