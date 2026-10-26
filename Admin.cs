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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void updateGroceryItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Grocery_Items frm = new Update_Grocery_Items();
            frm.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void updateMembToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Members frm = new Update_Members();
            frm.Show();
        }

        private void generateOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generate_Order_List frm = new Generate_Order_List();
            frm.Show();
        }

        private void mISReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MIS_Report frm = new MIS_Report ();
            frm.Show();
        }
    }
}
