namespace TheGoldenShopper
{
    partial class MIS_Report
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
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.cmbTop = new System.Windows.Forms.ComboBox();
            this.cmbLow = new System.Windows.Forms.ComboBox();
            this.btnGroceryReport = new System.Windows.Forms.Button();
            this.btnMmemberReport = new System.Windows.Forms.Button();
            this.dgvGroceryReport = new System.Windows.Forms.DataGridView();
            this.dgvMemberReport = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblGrocery = new System.Windows.Forms.Label();
            this.lblMembers = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.lblTotalUnits = new System.Windows.Forms.Label();
            this.lblLeastOrdered = new System.Windows.Forms.Label();
            this.lblMostOrdered = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroceryReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(301, 66);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(673, 68);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // cmbTop
            // 
            this.cmbTop.FormattingEnabled = true;
            this.cmbTop.Location = new System.Drawing.Point(127, 206);
            this.cmbTop.Name = "cmbTop";
            this.cmbTop.Size = new System.Drawing.Size(103, 24);
            this.cmbTop.TabIndex = 2;
           this.cmbTop.SelectedIndexChanged += new System.EventHandler(this.cmbTop_SelectedIndexChanged);
            // 
            // cmbLow
            // 
            this.cmbLow.FormattingEnabled = true;
            this.cmbLow.Location = new System.Drawing.Point(349, 206);
            this.cmbLow.Name = "cmbLow";
            this.cmbLow.Size = new System.Drawing.Size(121, 24);
            this.cmbLow.TabIndex = 3;
            // 
            // btnGroceryReport
            // 
            this.btnGroceryReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroceryReport.Location = new System.Drawing.Point(196, 139);
            this.btnGroceryReport.Name = "btnGroceryReport";
            this.btnGroceryReport.Size = new System.Drawing.Size(121, 49);
            this.btnGroceryReport.TabIndex = 4;
            this.btnGroceryReport.Text = "Create Report";
            this.btnGroceryReport.UseVisualStyleBackColor = true;
            this.btnGroceryReport.Click += new System.EventHandler(this.btnGroceryReport_Click_1);
            // 
            // btnMmemberReport
            // 
            this.btnMmemberReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMmemberReport.Location = new System.Drawing.Point(775, 139);
            this.btnMmemberReport.Name = "btnMmemberReport";
            this.btnMmemberReport.Size = new System.Drawing.Size(121, 49);
            this.btnMmemberReport.TabIndex = 5;
            this.btnMmemberReport.Text = "Create Report";
            this.btnMmemberReport.UseVisualStyleBackColor = true;
            this.btnMmemberReport.Click += new System.EventHandler(this.btnMmemberReport_Click);
            // 
            // dgvGroceryReport
            // 
            this.dgvGroceryReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroceryReport.Location = new System.Drawing.Point(23, 251);
            this.dgvGroceryReport.Name = "dgvGroceryReport";
            this.dgvGroceryReport.RowHeadersWidth = 51;
            this.dgvGroceryReport.RowTemplate.Height = 24;
            this.dgvGroceryReport.Size = new System.Drawing.Size(478, 334);
            this.dgvGroceryReport.TabIndex = 6;
            // 
            // dgvMemberReport
            // 
            this.dgvMemberReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemberReport.Location = new System.Drawing.Point(616, 251);
            this.dgvMemberReport.Name = "dgvMemberReport";
            this.dgvMemberReport.RowHeadersWidth = 51;
            this.dgvMemberReport.RowTemplate.Height = 24;
            this.dgvMemberReport.Size = new System.Drawing.Size(454, 334);
            this.dgvMemberReport.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(272, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(551, 31);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "MANAGEMENT INFORMATION (MIS) SYSTEM";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(233, 71);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(56, 19);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "From: ";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(603, 73);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(36, 19);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "To: ";
            // 
            // lblGrocery
            // 
            this.lblGrocery.AutoSize = true;
            this.lblGrocery.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrocery.Location = new System.Drawing.Point(122, 105);
            this.lblGrocery.Name = "lblGrocery";
            this.lblGrocery.Size = new System.Drawing.Size(261, 25);
            this.lblGrocery.TabIndex = 11;
            this.lblGrocery.Text = "GROCERY ORDERS REPORT";
            this.lblGrocery.Click += new System.EventHandler(this.lblGrocery_Click);
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembers.Location = new System.Drawing.Point(678, 105);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(275, 25);
            this.lblMembers.TabIndex = 12;
            this.lblMembers.Text = "MEMBERS ACTIVITY REPORT";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(470, 604);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(142, 31);
            this.lblSummary.TabIndex = 13;
            this.lblSummary.Text = "SUMMARY";
            this.lblSummary.Click += new System.EventHandler(this.lblSummary_Click);
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.Location = new System.Drawing.Point(58, 209);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(52, 18);
            this.lblTop.TabIndex = 17;
            this.lblTop.Text = "TOP: ";
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLow.Location = new System.Drawing.Point(275, 209);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(49, 18);
            this.lblLow.TabIndex = 18;
            this.lblLow.Text = "Low: ";
            // 
            // lblTotalUnits
            // 
            this.lblTotalUnits.AutoSize = true;
            this.lblTotalUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUnits.Location = new System.Drawing.Point(20, 723);
            this.lblTotalUnits.Name = "lblTotalUnits";
            this.lblTotalUnits.Size = new System.Drawing.Size(166, 18);
            this.lblTotalUnits.TabIndex = 16;
            this.lblTotalUnits.Text = "Total Units Ordered: ";
            this.lblTotalUnits.Click += new System.EventHandler(this.lblTotalUnits_Click);
            // 
            // lblLeastOrdered
            // 
            this.lblLeastOrdered.AutoSize = true;
            this.lblLeastOrdered.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeastOrdered.Location = new System.Drawing.Point(19, 689);
            this.lblLeastOrdered.Name = "lblLeastOrdered";
            this.lblLeastOrdered.Size = new System.Drawing.Size(122, 19);
            this.lblLeastOrdered.TabIndex = 15;
            this.lblLeastOrdered.Text = "Least Ordered: ";
            // 
            // lblMostOrdered
            // 
            this.lblMostOrdered.AutoSize = true;
            this.lblMostOrdered.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostOrdered.Location = new System.Drawing.Point(19, 656);
            this.lblMostOrdered.Name = "lblMostOrdered";
            this.lblMostOrdered.Size = new System.Drawing.Size(121, 19);
            this.lblMostOrdered.TabIndex = 14;
            this.lblMostOrdered.Text = "Most Ordered: ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1015, 689);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 61);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MIS_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1130, 762);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblLow);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.lblTotalUnits);
            this.Controls.Add(this.lblLeastOrdered);
            this.Controls.Add(this.lblMostOrdered);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblMembers);
            this.Controls.Add(this.lblGrocery);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvMemberReport);
            this.Controls.Add(this.dgvGroceryReport);
            this.Controls.Add(this.btnMmemberReport);
            this.Controls.Add(this.btnGroceryReport);
            this.Controls.Add(this.cmbLow);
            this.Controls.Add(this.cmbTop);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Name = "MIS_Report";
            this.Text = "MIS_Report";
            this.Load += new System.EventHandler(this.MIS_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroceryReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.ComboBox cmbTop;
        private System.Windows.Forms.ComboBox cmbLow;
        private System.Windows.Forms.Button btnGroceryReport;
        private System.Windows.Forms.Button btnMmemberReport;
        private System.Windows.Forms.DataGridView dgvGroceryReport;
        private System.Windows.Forms.DataGridView dgvMemberReport;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblGrocery;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.Label lblTotalUnits;
        private System.Windows.Forms.Label lblLeastOrdered;
        private System.Windows.Forms.Label lblMostOrdered;
        private System.Windows.Forms.Button btnRefresh;
    }
}