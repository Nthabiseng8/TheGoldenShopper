using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//Allows connection to the database
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGoldenShopper
{
    public partial class password : Form
    {
        public password()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Database connecting 
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM tblUsers WHERE Password = @Password";

                //Initialize connection and command
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        try
                        {
                            conn.Open();
                            int count = (int)cmd.ExecuteScalar();
                            if (count > 0)
                            {
                                Admin frm = new Admin();
                                frm.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Password");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                } 
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            if (txtPassword.UseSystemPasswordChar)
            {
                btnShowPassword.Text = "Show Password";
            }
            else
            {
                btnShowPassword.Text = "Hide Password";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void password_Load(object sender, EventArgs e)
        {

        }
    }
}
