namespace TheGoldenShopper
{
    partial class Generate_Order_List
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
            this.lblWeek = new System.Windows.Forms.Label();
            this.txtSelectedWeek = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCreateBulkPdf = new System.Windows.Forms.Button();
            this.btnViewIndividual = new System.Windows.Forms.Button();
            this.btnGenerateIndividualPDFs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.calendarWeek = new System.Windows.Forms.MonthCalendar();
            this.dgvCombinedOrder = new System.Windows.Forms.DataGridView();
            this.dgvIndividualOrders = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinedOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndividualOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeek.Location = new System.Drawing.Point(26, 234);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(244, 19);
            this.lblWeek.TabIndex = 1;
            this.lblWeek.Text = "Generate Combined List Week: ";
            this.lblWeek.Click += new System.EventHandler(this.lblWeek_Click);
            // 
            // txtSelectedWeek
            // 
            this.txtSelectedWeek.Location = new System.Drawing.Point(30, 273);
            this.txtSelectedWeek.Name = "txtSelectedWeek";
            this.txtSelectedWeek.Size = new System.Drawing.Size(161, 22);
            this.txtSelectedWeek.TabIndex = 2;
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(395, 255);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(97, 40);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnCreateBulkPdf
            // 
            this.btnCreateBulkPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBulkPdf.Location = new System.Drawing.Point(583, 74);
            this.btnCreateBulkPdf.Name = "btnCreateBulkPdf";
            this.btnCreateBulkPdf.Size = new System.Drawing.Size(148, 72);
            this.btnCreateBulkPdf.TabIndex = 5;
            this.btnCreateBulkPdf.Text = "Create PDF(for Bulk buy)";
            this.btnCreateBulkPdf.UseVisualStyleBackColor = true;
            this.btnCreateBulkPdf.Click += new System.EventHandler(this.btnCreateBulkPdf_Click);
            // 
            // btnViewIndividual
            // 
            this.btnViewIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewIndividual.Location = new System.Drawing.Point(751, 74);
            this.btnViewIndividual.Name = "btnViewIndividual";
            this.btnViewIndividual.Size = new System.Drawing.Size(145, 72);
            this.btnViewIndividual.TabIndex = 6;
            this.btnViewIndividual.Text = "View individual orders";
            this.btnViewIndividual.UseVisualStyleBackColor = true;
            this.btnViewIndividual.Click += new System.EventHandler(this.btnViewIndividual_Click);
            // 
            // btnGenerateIndividualPDFs
            // 
            this.btnGenerateIndividualPDFs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateIndividualPDFs.Location = new System.Drawing.Point(908, 74);
            this.btnGenerateIndividualPDFs.Name = "btnGenerateIndividualPDFs";
            this.btnGenerateIndividualPDFs.Size = new System.Drawing.Size(146, 72);
            this.btnGenerateIndividualPDFs.TabIndex = 7;
            this.btnGenerateIndividualPDFs.Text = "Generate PDFs(for indiviual orders)";
            this.btnGenerateIndividualPDFs.UseVisualStyleBackColor = true;
            this.btnGenerateIndividualPDFs.Click += new System.EventHandler(this.btnGenerateIndividualPDFs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select List Week";
            // 
            // calendarWeek
            // 
            this.calendarWeek.Location = new System.Drawing.Point(230, 18);
            this.calendarWeek.Name = "calendarWeek";
            this.calendarWeek.TabIndex = 9;
            this.calendarWeek.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // dgvCombinedOrder
            // 
            this.dgvCombinedOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCombinedOrder.Location = new System.Drawing.Point(28, 348);
            this.dgvCombinedOrder.Name = "dgvCombinedOrder";
            this.dgvCombinedOrder.RowHeadersWidth = 51;
            this.dgvCombinedOrder.RowTemplate.Height = 24;
            this.dgvCombinedOrder.Size = new System.Drawing.Size(464, 408);
            this.dgvCombinedOrder.TabIndex = 10;
            // 
            // dgvIndividualOrders
            // 
            this.dgvIndividualOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndividualOrders.Location = new System.Drawing.Point(583, 190);
            this.dgvIndividualOrders.Name = "dgvIndividualOrders";
            this.dgvIndividualOrders.RowHeadersWidth = 51;
            this.dgvIndividualOrders.RowTemplate.Height = 24;
            this.dgvIndividualOrders.Size = new System.Drawing.Size(471, 566);
            this.dgvIndividualOrders.TabIndex = 11;
            this.dgvIndividualOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIndividualOrders_CellContentClick);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(325, 319);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(24, 24);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "R";
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // Generate_Order_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1107, 825);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvIndividualOrders);
            this.Controls.Add(this.dgvCombinedOrder);
            this.Controls.Add(this.calendarWeek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerateIndividualPDFs);
            this.Controls.Add(this.btnViewIndividual);
            this.Controls.Add(this.btnCreateBulkPdf);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtSelectedWeek);
            this.Controls.Add(this.lblWeek);
            this.Name = "Generate_Order_List";
            this.Text = "Generate_Order_List";
            this.Load += new System.EventHandler(this.Generate_Order_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinedOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndividualOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.TextBox txtSelectedWeek;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnCreateBulkPdf;
        private System.Windows.Forms.Button btnViewIndividual;
        private System.Windows.Forms.Button btnGenerateIndividualPDFs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar calendarWeek;
        private System.Windows.Forms.DataGridView dgvCombinedOrder;
        private System.Windows.Forms.DataGridView dgvIndividualOrders;
        private System.Windows.Forms.Label lblTotal;
    }
}