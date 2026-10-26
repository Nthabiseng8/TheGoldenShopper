using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient; //Connection to database
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;//Pattern matching and validation 
using System.Windows.Forms;


namespace TheGoldenShopper
{
    public partial class Update_Grocery_Items : Form
    {

        public Update_Grocery_Items()
        {
            InitializeComponent();
        }

        private void tlrHeading_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Grocery_Items_Load(object sender, EventArgs e)
        {
            DisplayDataInGrid();
        }

        private void DisplayDataInGrid()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True;";

            string query = "SELECT ItemID, Description, Price, Image, Available FROM tblGroceryItems";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvGroceries.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Connection Error: " + ex.Message);
                    }
                }
            }
        }

        private void LinkImage_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)

        {
            string searchValue = txtSearch.Text.Trim();

            if (searchValue == "")
            {
                DisplayDataInGrid(); // Show all records
                return;
            }

            string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True";

            string query = @"SELECT ItemID, Description, Price, Image, Available
                     FROM tblGroceryItems
                     WHERE ItemID LIKE @Search
                     OR Description LIKE @Search";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                adapter.SelectCommand.Parameters.AddWithValue(
                    "@Search",
                    "%" + searchValue + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dgvGroceries.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No grocery item found.");
                }
            }
        }



        private void dgvGroceries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvGroceries.Rows[e.RowIndex];

                    txtItemIDD.Text = row.Cells["ItemID"].Value.ToString();
                    txtDescription.Text = row.Cells["Description"].Value.ToString();
                    txtPrice.Text = row.Cells["Price"].Value.ToString();
                    txtLink.Text = row.Cells["Image"].Value.ToString();

                    string available = row.Cells["Available"].Value.ToString();

                    if (available == "Y")
                        rbYes.Checked = true;
                    else
                        rbNo.Checked = true;
                }
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvGroceries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddIten_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemIDD.Text))
            {
                MessageBox.Show("Error: Item ID is required!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemIDD.Focus();
                return; // Stops execution completely
            }
            if (!Regex.IsMatch(txtItemIDD.Text.Trim(), @"^[A-Z]{2}[0-9]{4}$"))
            {
                MessageBox.Show("Error: Invalid Item ID format! " +
                    "Must be 2 uppercase letters followed by 4 digits (e.g., BR0001, CF0002).", "" +
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemIDD.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Error: Description cannot be blank!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Error: Price is required!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLink.Text))
            {
                MessageBox.Show("Error: Image link pathway is required!",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLink.Focus();
                return;
            }
            if (!rbYes.Checked && !rbNo.Checked)
            {
                MessageBox.Show("Error: Please specify if the item is Available (Yes or No)!", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string available = rbYes.Checked ? "Y" : "N";

            string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True";

            string query = @"INSERT INTO tblGroceryItems
                     (ItemID, Description, Price, Image, Available)
                     VALUES
                     (@ItemID,@Description,@Price,@Image,@Available)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ItemID", txtItemIDD.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Image", txtLink.Text);
                cmd.Parameters.AddWithValue("@Available", available);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item Added Successfully");

                DisplayDataInGrid();
            }
        }

        private void updateItem_Click(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(txtItemIDD.Text))
            {
                MessageBox.Show("Error: Item ID is required to identify which item to update!", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemIDD.Focus();
                return;
            }
            if (!Regex.IsMatch(txtItemIDD.Text.Trim(), @"^[A-Z]{2}[0-9]{4}$"))
            {
                MessageBox.Show("Error: Invalid Item ID format! Must be 2 uppercase letters followed by 4 digits (e.g., BR0001)." ,
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemIDD.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Error: Description cannot be left blank!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Error: Price is required!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            string cleanPriceInput = txtPrice.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(cleanPriceInput, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal validatedPrice) || validatedPrice < 0)
            {
                MessageBox.Show("Error: Please enter a valid positive numerical price (e.g., 15.99).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            if (!txtPrice.Text.Contains(".") && !txtPrice.Text.Contains(","))
            {
                validatedPrice = validatedPrice / 100;
            }
            txtPrice.Text = validatedPrice.ToString("0.00",
                System.Globalization.CultureInfo.InvariantCulture);

            if (string.IsNullOrWhiteSpace(txtLink.Text))
            {
                MessageBox.Show("Error: Image path link is required!",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLink.Focus();
                return;
            }
            if (!rbYes.Checked && !rbNo.Checked)
            {
                MessageBox.Show("Error: Please specify if the item is Available (Yes or No)!", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string available = rbYes.Checked ? "Y" : "N";

            string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True";

            string query = @"UPDATE tblGroceryItems
                     SET Description=@Description,
                         Price=@Price,
                         Image=@Image,
                         Available=@Available
                     WHERE ItemID=@ItemID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ItemID", txtItemIDD.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Image", txtLink.Text);
                cmd.Parameters.AddWithValue("@Available", available);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item Updated Successfully");

                DisplayDataInGrid();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Select Grocery Item Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLink.Text = openFileDialog.FileName;
            }
        }
    }


  } 
 
    
 