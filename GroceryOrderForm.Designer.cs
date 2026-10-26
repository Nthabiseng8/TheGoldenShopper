namespace TheGoldenShopper
{
    partial class GroceryOrderForm
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
            this.lblDisplayID = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvGroceries = new System.Windows.Forms.DataGridView();
            this.lblMyList = new System.Windows.Forms.Label();
            this.lblNumberItems = new System.Windows.Forms.Label();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.dgvMyList = new System.Windows.Forms.DataGridView();
            this.btnDone = new System.Windows.Forms.Button();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblDisplayNumber = new System.Windows.Forms.Label();
            this.lblDisplayEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroceries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDisplayID
            // 
            this.lblDisplayID.AutoSize = true;
            this.lblDisplayID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDisplayID.Location = new System.Drawing.Point(750, 19);
            this.lblDisplayID.Name = "lblDisplayID";
            this.lblDisplayID.Size = new System.Drawing.Size(70, 25);
            this.lblDisplayID.TabIndex = 0;
            this.lblDisplayID.Text = "label1";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDisplayName.Location = new System.Drawing.Point(750, 53);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(70, 25);
            this.lblDisplayName.TabIndex = 1;
            this.lblDisplayName.Text = "label2";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(230, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(142, 47);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(25, 167);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 30);
            this.txtSearch.TabIndex = 3;
            // 
            // dgvGroceries
            // 
            this.dgvGroceries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroceries.Location = new System.Drawing.Point(25, 242);
            this.dgvGroceries.Name = "dgvGroceries";
            this.dgvGroceries.RowHeadersWidth = 51;
            this.dgvGroceries.RowTemplate.Height = 24;
            this.dgvGroceries.Size = new System.Drawing.Size(436, 484);
            this.dgvGroceries.TabIndex = 4;
            this.dgvGroceries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroceries_CellContentClick);
            this.dgvGroceries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroceries_CellContentClick);
            this.dgvGroceries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroceries_CellDoubleClick);
            // 
            // lblMyList
            // 
            this.lblMyList.AutoSize = true;
            this.lblMyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyList.Location = new System.Drawing.Point(569, 62);
            this.lblMyList.Name = "lblMyList";
            this.lblMyList.Size = new System.Drawing.Size(108, 29);
            this.lblMyList.TabIndex = 5;
            this.lblMyList.Text = "My List: ";
            this.lblMyList.Click += new System.EventHandler(this.lblMyList_Click);
            // 
            // lblNumberItems
            // 
            this.lblNumberItems.AutoSize = true;
            this.lblNumberItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberItems.Location = new System.Drawing.Point(577, 211);
            this.lblNumberItems.Name = "lblNumberItems";
            this.lblNumberItems.Size = new System.Drawing.Size(226, 31);
            this.lblNumberItems.TabIndex = 6;
            this.lblNumberItems.Text = "Number of items: ";
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCount.Location = new System.Drawing.Point(778, 211);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(30, 31);
            this.lblItemCount.TabIndex = 7;
            this.lblItemCount.Text = "0";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(875, 211);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(33, 31);
            this.lblR.TabIndex = 8;
            this.lblR.Text = "R";
            this.lblR.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(945, 211);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(68, 31);
            this.lblTotalPrice.TabIndex = 9;
            this.lblTotalPrice.Text = "0.00";
            // 
            // dgvMyList
            // 
            this.dgvMyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyList.Location = new System.Drawing.Point(574, 263);
            this.dgvMyList.Name = "dgvMyList";
            this.dgvMyList.RowHeadersWidth = 51;
            this.dgvMyList.RowTemplate.Height = 24;
            this.dgvMyList.Size = new System.Drawing.Size(440, 407);
            this.dgvMyList.TabIndex = 10;
            this.dgvMyList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyList_CellClick);
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(881, 695);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(133, 51);
            this.btnDone.TabIndex = 11;
            this.btnDone.Text = "DONE";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(29, 19);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(174, 22);
            this.lblOrderDate.TabIndex = 12;
            this.lblOrderDate.Text = "Grocery Order for:";
            // 
            // lblDisplayNumber
            // 
            this.lblDisplayNumber.AutoSize = true;
            this.lblDisplayNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDisplayNumber.Location = new System.Drawing.Point(750, 91);
            this.lblDisplayNumber.Name = "lblDisplayNumber";
            this.lblDisplayNumber.Size = new System.Drawing.Size(70, 25);
            this.lblDisplayNumber.TabIndex = 14;
            this.lblDisplayNumber.Text = "label3";
            // 
            // lblDisplayEmail
            // 
            this.lblDisplayEmail.AutoSize = true;
            this.lblDisplayEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDisplayEmail.Location = new System.Drawing.Point(750, 128);
            this.lblDisplayEmail.Name = "lblDisplayEmail";
            this.lblDisplayEmail.Size = new System.Drawing.Size(70, 25);
            this.lblDisplayEmail.TabIndex = 15;
            this.lblDisplayEmail.Text = "label4";
            this.lblDisplayEmail.Click += new System.EventHandler(this.lblDisplayEmail_Click);
            // 
            // GroceryOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 753);
            this.Controls.Add(this.lblDisplayEmail);
            this.Controls.Add(this.lblDisplayNumber);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.dgvMyList);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.lblNumberItems);
            this.Controls.Add(this.lblMyList);
            this.Controls.Add(this.dgvGroceries);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.lblDisplayID);
            this.Name = "GroceryOrderForm";
            this.Text = "GroceryOrderForm";
            this.Load += new System.EventHandler(this.GroceryOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroceries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisplayID;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvGroceries;
        private System.Windows.Forms.Label lblMyList;
        private System.Windows.Forms.Label lblNumberItems;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.DataGridView dgvMyList;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblDisplayNumber;
        private System.Windows.Forms.Label lblDisplayEmail;
    }
}