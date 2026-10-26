namespace TheGoldenShopper
{
    partial class Update_Grocery_Items
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
            this.tlrHeading = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.txtLinkImage = new System.Windows.Forms.Label();
            this.AddIten = new System.Windows.Forms.Button();
            this.updateItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemIDD = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvGroceries = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroceries)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlrHeading
            // 
            this.tlrHeading.AutoSize = true;
            this.tlrHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlrHeading.Location = new System.Drawing.Point(230, 22);
            this.tlrHeading.Name = "tlrHeading";
            this.tlrHeading.Size = new System.Drawing.Size(522, 29);
            this.tlrHeading.TabIndex = 0;
            this.tlrHeading.Text = "ADD A NEW ITEM TO THE GROCERY LIST";
            this.tlrHeading.Click += new System.EventHandler(this.tlrHeading_Click);
            // 
            // txtItemId
            // 
            this.txtItemId.AutoSize = true;
            this.txtItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemId.Location = new System.Drawing.Point(43, 91);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(87, 25);
            this.txtItemId.TabIndex = 1;
            this.txtItemId.Text = "ItemID: ";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(36, 166);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(133, 25);
            this.description.TabIndex = 2;
            this.description.Text = "Description: ";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(43, 232);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(74, 25);
            this.price.TabIndex = 3;
            this.price.Text = "Price: ";
            // 
            // txtLinkImage
            // 
            this.txtLinkImage.AutoSize = true;
            this.txtLinkImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLinkImage.Location = new System.Drawing.Point(43, 449);
            this.txtLinkImage.Name = "txtLinkImage";
            this.txtLinkImage.Size = new System.Drawing.Size(162, 25);
            this.txtLinkImage.TabIndex = 5;
            this.txtLinkImage.Text = "Link To Image: ";
            this.txtLinkImage.Click += new System.EventHandler(this.LinkImage_Click);
            // 
            // AddIten
            // 
            this.AddIten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddIten.Location = new System.Drawing.Point(41, 532);
            this.AddIten.Name = "AddIten";
            this.AddIten.Size = new System.Drawing.Size(130, 58);
            this.AddIten.TabIndex = 6;
            this.AddIten.Text = "Add New Item";
            this.AddIten.UseVisualStyleBackColor = true;
            this.AddIten.Click += new System.EventHandler(this.AddIten_Click);
            // 
            // updateItem
            // 
            this.updateItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateItem.Location = new System.Drawing.Point(263, 532);
            this.updateItem.Name = "updateItem";
            this.updateItem.Size = new System.Drawing.Size(124, 58);
            this.updateItem.TabIndex = 7;
            this.updateItem.Text = "Update Item";
            this.updateItem.UseVisualStyleBackColor = true;
            this.updateItem.Click += new System.EventHandler(this.updateItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(485, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "List of groceries";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtItemIDD
            // 
            this.txtItemIDD.Location = new System.Drawing.Point(227, 97);
            this.txtItemIDD.Name = "txtItemIDD";
            this.txtItemIDD.Size = new System.Drawing.Size(160, 22);
            this.txtItemIDD.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(227, 152);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(160, 39);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(227, 232);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(160, 22);
            this.txtPrice.TabIndex = 11;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(211, 453);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(160, 22);
            this.txtLink.TabIndex = 12;
            this.txtLink.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(490, 170);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(108, 22);
            this.txtSearch.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(646, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 37);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvGroceries
            // 
            this.dgvGroceries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroceries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroceries.Location = new System.Drawing.Point(488, 222);
            this.dgvGroceries.Name = "dgvGroceries";
            this.dgvGroceries.RowHeadersWidth = 51;
            this.dgvGroceries.RowTemplate.Height = 24;
            this.dgvGroceries.Size = new System.Drawing.Size(472, 368);
            this.dgvGroceries.TabIndex = 18;
            this.dgvGroceries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroceries_CellClick);
            this.dgvGroceries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroceries_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNo);
            this.groupBox1.Controls.Add(this.rbYes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(41, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 98);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(70, 52);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(60, 29);
            this.rbNo.TabIndex = 1;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.Location = new System.Drawing.Point(68, 21);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(70, 29);
            this.rbYes.TabIndex = 0;
            this.rbYes.TabStop = true;
            this.rbYes.Text = "Yes";
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(377, 453);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Update_Grocery_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(986, 661);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvGroceries);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtItemIDD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateItem);
            this.Controls.Add(this.AddIten);
            this.Controls.Add(this.txtLinkImage);
            this.Controls.Add(this.price);
            this.Controls.Add(this.description);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.tlrHeading);
            this.Name = "Update_Grocery_Items";
            this.Text = "Update_Grocery_Items";
            this.Load += new System.EventHandler(this.Update_Grocery_Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroceries)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tlrHeading;
        private System.Windows.Forms.Label txtItemId;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label txtLinkImage;
        private System.Windows.Forms.Button AddIten;
        private System.Windows.Forms.Button updateItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemIDD;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvGroceries;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.Button btnBrowse;
    }
}