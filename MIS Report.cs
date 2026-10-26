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

namespace TheGoldenShopper
{
    public partial class MIS_Report : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
        Initial Catalog=groceryDB;Integrated Security=True";

        public MIS_Report()
        {
            InitializeComponent();
            SetupFormDefaults();

        }
        private void SetupFormDefaults()
        {

            cmbTop.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9 ", "10" });
            cmbLow.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9 ", "10" });

            cmbTop.SelectedIndex = -1;
            cmbLow.SelectedIndex = -1;

            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
        }

        private void btnGroceryReport_Click_1(object sender, EventArgs e)
        {

            DateTime startDate = dtpFrom.Value.Date;
            DateTime endDate = dtpTo.Value.Date.AddDays(1).AddTicks(-1);


            int topCount = (cmbTop.SelectedItem != null) ? int.Parse(cmbTop.SelectedItem.ToString()) : 5;
            int lowCount = (cmbLow.SelectedItem != null) ? int.Parse(cmbLow.SelectedItem.ToString()) : 5;

            string query = @"
        SELECT 
            i.ItemID,
            i.Description,
            ISNULL(SUM(o.Quantity), 0) AS TotalQuantity
        FROM tblGroceryItems i
        LEFT JOIN tblMemberOrders o 
            ON i.ItemID = o.ItemID 
            AND o.OrderDate >= @StartDate AND o.OrderDate <= @EndDate
        GROUP BY i.ItemID, i.Description
        ORDER BY TotalQuantity DESC";

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No data found for the selected date range.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ==========================================
            // 2. BUILD DATAGRIDVIEW REPORT DATA
            // ==========================================
            DataTable reportTable = new DataTable();
            reportTable.Columns.Add("ItemID", typeof(string));
            reportTable.Columns.Add("Description", typeof(string));
            reportTable.Columns.Add("Total Quantity", typeof(int));
            reportTable.Columns.Add("Rank", typeof(string));

            // Top N items
            var topRows = dt.AsEnumerable().Take(topCount);
            foreach (var row in topRows)
            {
                reportTable.Rows.Add(row["ItemID"], row["Description"], row["TotalQuantity"], "Top");
            }

            // Low N items
            var lowRows = dt.AsEnumerable().OrderBy(r => r.Field<int>("TotalQuantity")).Take(lowCount);
            foreach (var row in lowRows)
            {
                string itemId = row.Field<string>("ItemID");
                if (!reportTable.AsEnumerable().Any(r => r.Field<string>("ItemID") == itemId))
                {
                    reportTable.Rows.Add(row["ItemID"], row["Description"], row["TotalQuantity"], "Low");
                }
            }

            dgvGroceryReport.DataSource = reportTable;

            // ==========================================
            // 3. CALCULATE & DISPLAY SUMMARY STATS
            // ==========================================
            UpdateSummaryStats(dt);
        }

        private void UpdateSummaryStats(DataTable dt)
        {
            // Total units across all items
            int totalUnits = dt.AsEnumerable().Sum(r => r.Field<int>("TotalQuantity"));

            // Most ordered item (First row since table is ordered DESC)
            var mostRow = dt.AsEnumerable().OrderByDescending(r => r.Field<int>("TotalQuantity")).FirstOrDefault();
            string mostOrderedText = mostRow != null
                ? $"{mostRow["Description"]} ({mostRow["TotalQuantity"]} units)"
                : "N/A";

            // Least ordered item (First row when ordered ASC)
            var leastRow = dt.AsEnumerable().OrderBy(r => r.Field<int>("TotalQuantity")).FirstOrDefault();
            string leastOrderedText = leastRow != null
                ? $"{leastRow["Description"]} ({leastRow["TotalQuantity"]} units)"
                : "N/A";

            // Update Label UI
            lblMostOrdered.Text = $" Most Ordered Item:  {mostOrderedText}";
            lblLeastOrdered.Text = $" Least Ordered Item: {leastOrderedText}";
            lblTotalUnits.Text = $" Total Units Ordered: {totalUnits:N0} units";
        }

        private void btnMmemberReport_Click(object sender, EventArgs e)
        {

            DateTime startDate = dtpFrom.Value.Date;
            DateTime endDate = dtpTo.Value.Date.AddDays(1).AddTicks(-1);

            double totalDays = (endDate - startDate).TotalDays;
            int opportunities = (int)Math.Max(1, Math.Ceiling(totalDays / 7.0));

            string query = @"
            SELECT 
                m.MemberID,
                (m.Name + ' ' + m.Surname) AS MemberName,
                COUNT(DISTINCT CAST(o.OrderDate AS DATE)) AS OrdersMade
            FROM tblMembers m
            LEFT JOIN tblMemberOrders o 
                ON m.MemberID = o.MemberID 
                AND o.OrderDate >= @StartDate AND o.OrderDate <= @EndDate
            WHERE m.Active = 'Y'
            GROUP BY m.MemberID, m.Name, m.Surname";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No active members or order data found for the selected date range.",
                                    "Report Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                DataTable reportTable = new DataTable();
                reportTable.Columns.Add("Member ID", typeof(string));
                reportTable.Columns.Add("Name", typeof(string));
                reportTable.Columns.Add("Orders Made", typeof(int));
                reportTable.Columns.Add("Opportunities", typeof(int));
                reportTable.Columns.Add("Participation %", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    int ordersMade = Convert.ToInt32(row["OrdersMade"]);
                    double percentage = Math.Min(100.0, ((double)ordersMade / opportunities) * 100);

                    reportTable.Rows.Add(
                        row["MemberID"].ToString(),
                        row["MemberName"].ToString(),
                        ordersMade,
                        opportunities,
                        $"{percentage:F1}%"
                    );
                }


                dgvMemberReport.DataSource = reportTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {

            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;

            cmbTop.SelectedIndex = -1;
            cmbLow.SelectedIndex = -1;

            dgvGroceryReport.DataSource = null;
            dgvMemberReport.DataSource = null;

            lblMostOrdered.Text = null;
            lblLeastOrdered.Text = null;
            lblTotalUnits.Text = null;
            MessageBox.Show("Reports cleared successfully!", "Refreshed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void cmbTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Your event code here
        }

        private void lblGrocery_Click(object sender, EventArgs e) { }
        private void lblSummary_Click(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblTotalUnits_Click(object sender, EventArgs e) { }
        private void MIS_Report_Load(object sender, EventArgs e) { }
        private void dgvIndividualOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle data grid cell click
        }

        private void Generate_Order_List_Load(object sender, EventArgs e)
        {
            // Form load logic here
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {
        }

        private void lblWeek_Click(object sender, EventArgs e)
        {
        }
    }
}

    


