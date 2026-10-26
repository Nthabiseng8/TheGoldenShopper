using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGoldenShopper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Code to link Form 1 to all other forms
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.Show();
        }

        private void adminFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            password frm = new password();
            frm.Show();
        }


        private void membersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Members_Only frm = new Members_Only();
            frm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
