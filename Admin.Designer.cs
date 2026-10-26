namespace TheGoldenShopper
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.updateGroceryItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateOrderListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mISReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateGroceryItemsToolStripMenuItem,
            this.updateMembersToolStripMenuItem,
            this.generateOrderListToolStripMenuItem,
            this.mISReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // updateGroceryItemsToolStripMenuItem
            // 
            this.updateGroceryItemsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateGroceryItemsToolStripMenuItem.Name = "updateGroceryItemsToolStripMenuItem";
            this.updateGroceryItemsToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.updateGroceryItemsToolStripMenuItem.Text = "Update Grocery Items";
            this.updateGroceryItemsToolStripMenuItem.Click += new System.EventHandler(this.updateGroceryItemsToolStripMenuItem_Click);
            // 
            // updateMembersToolStripMenuItem
            // 
            this.updateMembersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateMembersToolStripMenuItem.Name = "updateMembersToolStripMenuItem";
            this.updateMembersToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.updateMembersToolStripMenuItem.Text = "Update Members";
            this.updateMembersToolStripMenuItem.Click += new System.EventHandler(this.updateMembersToolStripMenuItem_Click);
            // 
            // generateOrderListToolStripMenuItem
            // 
            this.generateOrderListToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateOrderListToolStripMenuItem.Name = "generateOrderListToolStripMenuItem";
            this.generateOrderListToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.generateOrderListToolStripMenuItem.Text = "Generate Order List";
            this.generateOrderListToolStripMenuItem.Click += new System.EventHandler(this.generateOrderListToolStripMenuItem_Click);
            // 
            // mISReportToolStripMenuItem
            // 
            this.mISReportToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mISReportToolStripMenuItem.Name = "mISReportToolStripMenuItem";
            this.mISReportToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            this.mISReportToolStripMenuItem.Text = "MIS Report";
            this.mISReportToolStripMenuItem.Click += new System.EventHandler(this.mISReportToolStripMenuItem_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateGroceryItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateMembersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateOrderListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mISReportToolStripMenuItem;
    }
}