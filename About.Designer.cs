namespace TheGoldenShopper
{
    partial class About
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.lblGoldenShopper = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblModuleCode = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescriptiom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblGoldenShopper
            // 
            this.lblGoldenShopper.AutoSize = true;
            this.lblGoldenShopper.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoldenShopper.Location = new System.Drawing.Point(356, 31);
            this.lblGoldenShopper.Name = "lblGoldenShopper";
            this.lblGoldenShopper.Size = new System.Drawing.Size(196, 22);
            this.lblGoldenShopper.TabIndex = 2;
            this.lblGoldenShopper.Text = "The Golden Shopper";
            this.lblGoldenShopper.UseMnemonic = false;
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModule.Location = new System.Drawing.Point(357, 71);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(180, 16);
            this.lblModule.TabIndex = 3;
            this.lblModule.Text = "Version ICT3715 2026 v1 ";
            this.lblModule.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.Location = new System.Drawing.Point(356, 112);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(227, 18);
            this.lblStudent.TabIndex = 5;
            this.lblStudent.Text = "Nthabiseng Ndaba: 15212408";
            this.lblStudent.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(680, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblModuleCode
            // 
            this.lblModuleCode.AutoSize = true;
            this.lblModuleCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuleCode.Location = new System.Drawing.Point(357, 152);
            this.lblModuleCode.Name = "lblModuleCode";
            this.lblModuleCode.Size = new System.Drawing.Size(103, 16);
            this.lblModuleCode.TabIndex = 7;
            this.lblModuleCode.Text = "ICT3715_2026";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.BackgroundImage = global::TheGoldenShopper.Properties.Resources.About1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 426);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescriptiom
            // 
            this.lblDescriptiom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptiom.Location = new System.Drawing.Point(357, 201);
            this.lblDescriptiom.Name = "lblDescriptiom";
            this.lblDescriptiom.Size = new System.Drawing.Size(420, 153);
            this.lblDescriptiom.TabIndex = 8;
            this.lblDescriptiom.Text = "The Golden Shopper is a system for an old age home. The elderly can order groceri" +
    "es here. The matron of the old age can do a variety of functions like update mem" +
    "bers information and so on. ";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDescriptiom);
            this.Controls.Add(this.lblModuleCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.lblGoldenShopper);
            this.Controls.Add(this.pictureBox1);
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGoldenShopper;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblModuleCode;
        private System.Windows.Forms.Label lblDescriptiom;
    }
}