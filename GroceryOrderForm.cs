using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TheGoldenShopper
{
    public partial class GroceryOrderForm : Form
    {
        private string memberID;
        private string memberName;
        private string memberContact;
        private string memberEmail;


        // 1. Declare the connection string safely inside the class level
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True";

        // This acts as the backend storage for our empty shopping cart on the right
        private DataTable shoppingCartTable = new DataTable();

        // Constructor that accepts the data passed from the Members form
        public GroceryOrderForm(string id, string name, string contact, string email)
        {
            InitializeComponent();
            memberID = id;
            memberName = name;
            memberContact = contact;
            memberEmail = email;

            // Setup the shopping cart data structure columns
            shoppingCartTable.Columns.Add("ItemID", typeof(string));
            shoppingCartTable.Columns.Add("Description", typeof(string));
            shoppingCartTable.Columns.Add("Price", typeof(decimal));
            shoppingCartTable.Columns.Add("Qty", typeof(int));
            shoppingCartTable.Columns.Add("Total", typeof(decimal));
        }

        private void GroceryOrderForm_Load(object sender, EventArgs e)
        {
            // Update your labels to display the tracking information
            lblDisplayID.Text = memberID;   // Displays the ID (e.g., 01-02)
            lblDisplayName.Text = memberName; // Displays the full name
            lblDisplayNumber.Text = memberContact; // <-- Displays phone number (e.g., 0815549021)
            lblDisplayEmail.Text = memberEmail;

            // Load the inventory grid automatically when the form opens
            LoadGroceryInventory();

            // Connects our background cart tracker to your new right-hand side grid layout
            dgvMyList.DataSource = shoppingCartTable;

            // --- ADD THIS TO FORMAT AND DISPLAY THE DATE ---
            // "dddd" gives the full day name, "dd/MM/yyyy" prints the numeric format
            string formattedDate = DateTime.Today.ToString("dddd, dd/MM/yyyy");
            lblOrderDate.Text = "Grocery Order for:    " + formattedDate;

        }

        // 2. The method declaration that fixes the missing context error
        private void LoadGroceryInventory()
        {
            string query = "SELECT ItemID, Description, Price FROM tblGroceryItems";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // 3. Targets your exact grid name: dgvGroceries
                        dgvGroceries.DataSource = dt;

                        // Optional UI cleanup: set user-friendly widths
                        if (dgvGroceries.Columns["ItemID"] != null) dgvGroceries.Columns["ItemID"].Width = 80;
                        if (dgvGroceries.Columns["Description"] != null) dgvGroceries.Columns["Description"].Width = 200;
                        if (dgvGroceries.Columns["Price"] != null) dgvGroceries.Columns["Price"].Width = 80;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load inventory: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Assumes your search box text control is named txtSearch
            string searchKeyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchKeyword))
            {
                LoadGroceryInventory();
                return;
            }

            string query = "SELECT ItemID, Description, Price, Image FROM tblGroceryItems WHERE Description LIKE @Search";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");

                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvGroceries.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No items match your search. Showing all items instead.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGroceryInventory();
                            txtSearch.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error searching for items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvGroceries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the user clicked on a valid data row, not the header text
            if (e.RowIndex >= 0)
            {
                // 1. Get the data from the selected row on the left grid
                DataGridViewRow selectedRow = dgvGroceries.Rows[e.RowIndex];

                string itemId = selectedRow.Cells["ItemID"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);

                

                // 2. Check if this item is already sitting in our shopping list table
                DataRow[] existingRows = shoppingCartTable.Select("ItemID = '" + itemId + "'");

                if (existingRows.Length > 0)
                {
                    // Item already exists in cart! Let's just increase the Quantity by 1
                    int currentQty = Convert.ToInt32(existingRows[0]["Qty"]);
                    existingRows[0]["Qty"] = currentQty + 1;

                    // Recalculate the line total for this row
                    existingRows[0]["Total"] = (currentQty + 1) * price;
                }
                else
                {
                    // Brand new item! Add a completely fresh row to our background cart structure
                    DataRow newRow = shoppingCartTable.NewRow();
                    newRow["ItemID"] = itemId;
                    newRow["Description"] = description;
                    newRow["Price"] = price;
                    newRow["Qty"] = 1;
                    newRow["Total"] = price; // 1 * price

                    shoppingCartTable.Rows.Add(newRow);
                }

                // 3. Keep the counters updated on screen for the user
                UpdateCartTotals();
            }
        }
        private void UpdateCartTotals()
        {
            int totalItemsCount = 0;
            decimal grandTotalCash = 0;

            // Loop through every row currently in our cart table structure
            foreach (DataRow row in shoppingCartTable.Rows)
            {
                totalItemsCount += Convert.ToInt32(row["Qty"]);
                grandTotalCash += Convert.ToDecimal(row["Total"]);
            }

            // Push the updated statistics straight to your labels
            lblItemCount.Text = totalItemsCount.ToString();
            lblTotalPrice.Text = grandTotalCash.ToString("0.00"); // Formats neatly with two decimal spots
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            // --- BUSINESS RULE 1: WEEKLY CUT-OFF TIME VALIDATION (FRIDAYS) ---
            // The system must prevent members from placing or modifying orders on Fridays.
            DayOfWeek currentDay = DateTime.Today.DayOfWeek;

            if (currentDay == DayOfWeek.Friday)
            {
                MessageBox.Show("The system prevents placing or modifying grocery orders after the weekly cut-off time (Fridays). " +
                                "Please submit your order between Saturday and Thursday.",
                                "Ordering Window Closed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Stops execution right here
            }

            // --- BUSINESS RULE 2: MAX ITEM QUANTITY VALIDATION ---
            // Calculate the total quantity of items currently listed in the cart table
            int totalItemsCount = 0;
            foreach (DataRow row in shoppingCartTable.Rows)
            {
                totalItemsCount += Convert.ToInt32(row["Qty"]);
            }

            // Block submission if they haven't chosen anything at all
            if (totalItemsCount == 0)
            {
                MessageBox.Show("Your shopping list is empty! Please add items before finalizing.",
                                "Notice",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // A member cannot select or place an order for more than 12 items total
            if (totalItemsCount > 12)
            {
                MessageBox.Show($"You have selected {totalItemsCount} items. A member cannot place an order for more than 12 items. " +
                                "Please reduce the quantities or remove items before submitting.",
                                "Order Limit Exceeded",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return; // Blocks the submission
            }

            // --- ALL BUSINESS RULES PASSED: WORK THE DONE NAVIGATION ---
            DialogResult result = MessageBox.Show("Are you finished with your grocery order and ready to submit?",
                                                  "Confirm Order Submission",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Find the open instance of your initial verification screen
                Members_Only loginScreen = (Members_Only)Application.OpenForms["Members_Only"];

                if (loginScreen != null)
                {
                    // --- CALL THE RESET METHOD HERE ---
                    loginScreen.ResetLoginForm();

                    // Show the cleanly wiped form
                    loginScreen.Show();
                    this.Close();
                }
                else
                {
                    // Fallback safety catch
                    Members_Only freshLoginScreen = new Members_Only();
                    freshLoginScreen.Show();
                    this.Close();
                }
            }
        }



        private void dgvGroceries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

                    
        }
       

        private void lblDisplayEmail_Click(object sender, EventArgs e)
        {

        }

        private void dgvMyList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked on a valid data row, not the header text
            if (e.RowIndex >= 0)
            {
                // 1. Find the selected row from the right-hand grid
                DataGridViewRow selectedGridRow = dgvMyList.Rows[e.RowIndex];
                string itemId = selectedGridRow.Cells["ItemID"].Value.ToString();

                // 2. Find that matching row inside our background data table
                DataRow[] cartRows = shoppingCartTable.Select("ItemID = '" + itemId + "'");

                if (cartRows.Length > 0)
                {
                    DataRow rowToUpdate = cartRows[0];
                    int currentQty = Convert.ToInt32(rowToUpdate["Qty"]);
                    decimal price = Convert.ToDecimal(rowToUpdate["Price"]);

                    if (currentQty > 1)
                    {
                        // Reduce the quantity by 1
                        rowToUpdate["Qty"] = currentQty - 1;
                        rowToUpdate["Total"] = (currentQty - 1) * price;
                    }
                    else
                    {
                        // If quantity is 1, clicking it again removes it completely
                        shoppingCartTable.Rows.Remove(rowToUpdate);
                    }

                    // 3. Refresh our screen counters dynamically
                    UpdateCartTotals();
                }
            }
        }

        private void picItemImage_Click(object sender, EventArgs e)
        {
           
             
        }

        private void picItemImage_Click_1(object sender, EventArgs e)
        {
          
        }

        private void lblMyList_Click(object sender, EventArgs e)
        {

        }
    }
    }
