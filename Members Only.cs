using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TheGoldenShopper
{
    public partial class Members_Only : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True";
        public Members_Only()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string inputID = maskedTextBox1.Text.Trim();

                string query = "SELECT Name, Surname, Contact, Email " +
                    "FROM tblMembers WHERE MemberID = @MemberID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", inputID);

                        try
                        {
                            conn.Open();
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    lblFirstName.Text = reader["Name"].ToString();
                                    lblSurname.Text = reader["Surname"].ToString();
                                    lblContact.Text = reader["Contact"].ToString();
                                    lblEmail.Text = reader["Email"].ToString();
                                    lblIsThisYou.Visible = true; 
                                    rbYes.Visible = true;
                                    rbNo.Visible = true;
                                    btnContinue.Visible = true;

                                    btnContinue.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("Member not found.", "Error", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ClearLabels();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Database error: " + ex.Message, "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void ClearLabels()
        {
            lblFirstName.Text = "";
            lblSurname.Text = "";
            lblContact.Text = "";
            lblEmail.Text = "";
            rbYes.Checked = false;
            rbNo.Checked = false;

            // Hide the verification step 
            lblIsThisYou.Visible = false;
            rbYes.Visible = false;
            rbNo.Visible = false;
            btnContinue.Visible = false;
            btnContinue.Enabled = false;
            btnContinue.BackColor = System.Drawing.SystemColors.Control;
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            btnContinue.Enabled = true;

            btnContinue.BackColor = System.Drawing.Color.LightGreen;
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                MessageBox.Show("Please try entering your member number again.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset the form
                maskedTextBox1.Clear();
                ClearLabels();

                // Reset the selection controls
                rbYes.Checked = false;
                rbNo.Checked = false;
                btnContinue.Enabled = false;
                btnContinue.BackColor = System.Drawing.SystemColors.Control;

                // Put the cursor back in the input box automatically
                maskedTextBox1.Focus();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string currentID = maskedTextBox1.Text.Trim();
            string fullName = lblFirstName.Text + " " + lblSurname.Text;
            string contact = lblContact.Text;
            string email = lblEmail.Text;

            GroceryOrderForm groceryScreen = new GroceryOrderForm(currentID, fullName, contact, email);
            groceryScreen.Show();
            this.Hide();
        }

        public void ResetLoginForm()
        {
            maskedTextBox1.Text = "";
            lblFirstName.Text = "";
            lblSurname.Text = "";
            lblContact.Text = "";
            lblEmail.Text = "";

            rbYes.Checked = false; 
            rbNo.Checked = false;

            btnContinue.Visible = false; 
        }

        private void Members_Only_Load(object sender, EventArgs e)
        {

        }
    }
}
