using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;  //Allow connection to database
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; //Pattern matching and validation 
using System.Windows.Forms;

namespace TheGoldenShopper
{
    public partial class Update_Members : Form
    {
        // Database connection 
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True";
        public Update_Members()
        {
            InitializeComponent();
        }

        private void lblSurname_Click(object sender, EventArgs e)
        {

        }

        private void Update_Members_Load(object sender, EventArgs e)
        {
            // Fetch data when the form opens
            DisplayDataInGrid();
        }

        // Members records from the database
        private void DisplayDataInGrid()
        {
            string query = "SELECT MemberID, Name, Surname, Email, Active FROM tblMembers";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvMembers.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Connection Error: " + ex.Message);
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];

                txtMemberID.Text = row.Cells["MemberID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSurname.Text = row.Cells["Surname"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();

                string active = row.Cells["Active"].Value.ToString();

                if (active == "Y" || active == "Yes")
                {
                    rbYes.Checked = true;
                }
                else
                {
                    rbNo.Checked = true;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchMember.Text.Trim();

                if (searchValue == "")
                  {
                    DisplayDataInGrid();
                    return;
                }
                string query = "SELECT MemberID, Name, Surname, Email, Active FROM tblMembers " +
                               "WHERE MemberID LIKE @Search " +
                               "OR Name LIKE @Search " +
                               "OR Surname LIKE @Search";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Search", "%" + searchValue + "%");

                            try
                            {
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    dgvMembers.DataSource = dt;
                                }
                                else
                                {
                                    MessageBox.Show("No matching member found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    dgvMembers.DataSource = null;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error while searching: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
             }
         }

        private void btnAddNew_Click(object sender, EventArgs e)

        {
            // Validation for member ID, Name, Surname, Email, RadioButton 
            if (string.IsNullOrWhiteSpace(txtMemberID.Text))
            {
                MessageBox.Show("Error: Member ID is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberID.Focus();
                return; 
            }

            if (!txtMemberID.MaskCompleted)
            {
                MessageBox.Show("Error: Please enter a complete Member ID!", "Validation Error");
                return; 
            }
         
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Error: Name is required!",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return; 
            }
           
            if (!Regex.IsMatch(txtName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Error: The name field must only contain letters." +
                    " Numbers and special characters are not allowed.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return; 
            }
          
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Error: Surname is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSurname.Focus();
                return; 
            }
            
            if (!Regex.IsMatch(txtSurname.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Error: The name field must only contain letters." +
                    " Numbers and special characters are not allowed.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return; 
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Error: Email is required!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return; 
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
            {
                MessageBox.Show("Error: Please enter a valid email address structure (e.g., thabo@domain.com).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return; 
            }
           
            if (!rbYes.Checked && !rbNo.Checked)
            {
                MessageBox.Show("Error: Please select if the member is Active (Yes/No)!", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            string active = rbYes.Checked ? "Y" : "N";

            string query = "INSERT INTO tblMembers (MemberID, Name, Surname, Email, Active) " +
                           "VALUES (@MemberID, @Name, @Surname, @Email, @Active)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", txtMemberID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Active", active);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Member Added Successfully");
                        DisplayDataInGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding member: " + ex.Message);
                    }
                }

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validation 
            if (!string.IsNullOrWhiteSpace(txtMemberID.Text))
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Error: Name cannot be left empty!", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    MessageBox.Show("Error: Surname cannot be left empty!", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSurname.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Error: Email cannot be left empty!", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!rbYes.Checked && !rbNo.Checked)
                {
                    MessageBox.Show("Error: Please specify if the member is Active!", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string active = rbYes.Checked ? "Y" : "N";

                string query = "UPDATE tblMembers SET Name=@Name, Surname=@Surname, Email=@Email, Active=@Active " +
                               "WHERE MemberID=@MemberID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", txtMemberID.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Active", active);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Member Updated Successfully");
                            DisplayDataInGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating member: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: Member ID is required to perform an update!",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberID.Focus();
                return;
            }
        }

        private void gbActive_Enter(object sender, EventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();     //Closes the About Form when the button is clicked
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

       
