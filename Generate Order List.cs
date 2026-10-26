using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGoldenShopper
{
    public partial class Generate_Order_List : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=groceryDB;Integrated Security=True;";
        public Generate_Order_List()
        {
            InitializeComponent();
        }
        private void LoadIndividualMemberOrders(DateTime orderDate)
        {
            string query = @"
        SELECT 
            m.MemberID,
            (m.MemberID + ' - ' + m.Name + ' ' + m.Surname) AS MemberHeader,
            i.Description AS Item,
            o.Quantity AS Qty,
            o.TotalPrice AS TotalPrice
        FROM tblMemberOrders o
        INNER JOIN tblMembers m ON o.MemberID = m.MemberID
        INNER JOIN tblGroceryItems i ON o.ItemID = i.ItemID
        WHERE CAST(o.OrderDate AS DATE) = @SelectedDate
        ORDER BY m.MemberID, i.ItemID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@SelectedDate", SqlDbType.Date).Value = orderDate.Date;

                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        BuildGroupedMemberGrid(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading member summaries: " + ex.Message, 
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BuildGroupedMemberGrid(DataTable dt)
        {
            DataTable displayTable = new DataTable();
            displayTable.Columns.Add("Member / Item", typeof(string));
            displayTable.Columns.Add("Qty", typeof(string));
            displayTable.Columns.Add("Total (R)", typeof(string));

            string currentMember = "";
            decimal memberTotal = 0;

            foreach (DataRow row in dt.Rows)
            {
                string memberHeader = row["MemberHeader"].ToString();

              
                if (currentMember != "" && currentMember != memberHeader)
                {
                    displayTable.Rows.Add("TOTAL", "", memberTotal.ToString("N2"));
                    displayTable.Rows.Add("", "", "");
                    memberTotal = 0;
                }

                if (currentMember != memberHeader)
                {
                    currentMember = memberHeader;
                    displayTable.Rows.Add(currentMember, "", "");
                }

             
                string item = row["Item"].ToString();
                int qty = Convert.ToInt32(row["Qty"]);
                decimal price = Convert.ToDecimal(row["TotalPrice"]);

                displayTable.Rows.Add("    " + item, qty.ToString(), price.ToString("N2"));
                memberTotal += price;
            }

           
            if (dt.Rows.Count > 0)
            {
                displayTable.Rows.Add("TOTAL", "", memberTotal.ToString("N2"));
            }

            
            dgvIndividualOrders.DataSource = displayTable;
            dgvIndividualOrders.AllowUserToAddRows = false;
            dgvIndividualOrders.RowHeadersVisible = false;

            dgvIndividualOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtSelectedWeek.Text = calendarWeek.SelectionStart.ToString("dd/MM/yyyy");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = calendarWeek.SelectionStart;

            if (selectedDate.DayOfWeek != DayOfWeek.Friday)
            {
                MessageBox.Show("Please select a valid order date (Friday).", 
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtSelectedWeek.Text = selectedDate.ToString("dd/MM/yyyy");
            LoadConsolidatedOrders(selectedDate);
        }

        private void LoadConsolidatedOrders(DateTime orderDate)
        {
            string query = @"
                SELECT 
                    i.ItemID,
                    i.Description AS Item,
                    SUM(o.Quantity) AS Quantity,
                    SUM(o.TotalPrice) AS [Total R]
                FROM tblMemberOrders o
                INNER JOIN tblGroceryItems i ON o.ItemID = i.ItemID
                WHERE o.OrderDate = @SelectedDate
                GROUP BY i.ItemID, i.Description
                ORDER BY i.ItemID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", orderDate.Date);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                      
                        dgvCombinedOrder.DataSource = dt;

                      
                        decimal totalAmount = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            totalAmount += Convert.ToDecimal(row["Total R"]);
                        }

                      
                        lblTotal.Text = "R " + totalAmount.ToString("N2");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading orders: " + ex.Message, 
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnViewIndividual_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = calendarWeek.SelectionStart;

            if (selectedDate.DayOfWeek != DayOfWeek.Friday)
            {
                MessageBox.Show("Please select a valid order date (Friday).", 
                    "Invalid Date Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtSelectedWeek.Text = selectedDate.ToString("dd/MM/yyyy");

  
            LoadConsolidatedOrders(selectedDate);

       
            LoadIndividualMemberOrders(selectedDate);
        }

        private void btnCreateBulkPdf_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = calendarWeek.SelectionStart;

            if (selectedDate.DayOfWeek != DayOfWeek.Friday)
            {
                MessageBox.Show("Please select a valid Friday order date first.", 
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = $"{selectedDate:yyyyMMdd}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25f, 25f, 30f, 30f);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    pdfDoc.Open();

                    iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16f);
                    iTextSharp.text.Font subTitleFont = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
                    iTextSharp.text.Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10f);
                    iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10f);

                    pdfDoc.Add(new Paragraph("Weekly Grocery Order", titleFont));
                    pdfDoc.Add(new Paragraph($"Order Date: {selectedDate:dd/MM/yyyy}\n\n", subTitleFont));

                 
                    PdfPTable pdfTable = new PdfPTable(4) { WidthPercentage = 100f };
                    pdfTable.SetWidths(new float[] { 2f, 5f, 2f, 2f });

                
                    pdfTable.AddCell(new PdfPCell(new Phrase("Item ID", headerFont)));
                    pdfTable.AddCell(new PdfPCell(new Phrase("Item Description", headerFont)));
                    pdfTable.AddCell(new PdfPCell(new Phrase("Quantity", headerFont)));
                    pdfTable.AddCell(new PdfPCell(new Phrase("Total (R)", headerFont)));

                    
                    string query = @"
                SELECT 
                    i.ItemID,
                    i.Description AS Item,
                    SUM(o.Quantity) AS Quantity,
                    SUM(o.TotalPrice) AS [Total R]
                FROM tblMemberOrders o
                INNER JOIN tblGroceryItems i ON o.ItemID = i.ItemID
                WHERE CAST(o.OrderDate AS DATE) = @SelectedDate
                GROUP BY i.ItemID, i.Description
                ORDER BY i.ItemID;";

                    decimal totalAmount = 0;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@SelectedDate", SqlDbType.Date).Value = selectedDate.Date;
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                pdfTable.AddCell(new Phrase(reader["ItemID"].ToString(), cellFont));
                                pdfTable.AddCell(new Phrase(reader["Item"].ToString(), cellFont));
                                pdfTable.AddCell(new Phrase(reader["Quantity"].ToString(), cellFont));

                                decimal itemTotal = Convert.ToDecimal(reader["Total R"]);
                                totalAmount += itemTotal;
                                pdfTable.AddCell(new Phrase($"R {itemTotal:N2}", cellFont));
                            }
                        }
                    }

                    pdfDoc.Add(pdfTable);

                 
                    Paragraph grandTotalPara = new Paragraph($"\nGrand Total: R {totalAmount:N2}", titleFont)
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };
                    pdfDoc.Add(grandTotalPara);

                    pdfDoc.Close();
                    MessageBox.Show("Bulk Order PDF generated successfully!", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating PDF: " + ex.Message, "PDF Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    DateTime selectedOrderDate = calendarWeek.SelectionStart;

                    if (selectedOrderDate.DayOfWeek != DayOfWeek.Friday)
                    {
                        MessageBox.Show("Please select a valid Friday order date first.", 
                            "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                FolderBrowserDialog folderDialog = new FolderBrowserDialog
                {
                    Description = "Select a folder to save individual member PDFs"
                };

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetFolder = folderDialog.SelectedPath;

                    string memberQuery = @"
                    SELECT DISTINCT m.MemberID, m.Name, m.Surname
                    FROM tblMemberOrders o
                    INNER JOIN tblMembers m ON o.MemberID = m.MemberID
                    WHERE CAST(o.OrderDate AS DATE) = @SelectedDate;";

                    try
                    {
                        int pdfCount = 0;
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            SqlCommand cmdMembers = new SqlCommand(memberQuery, conn);
                            cmdMembers.Parameters.Add("@SelectedDate",
                                SqlDbType.Date).Value = selectedOrderDate.Date;

                            DataTable dtMembers = new DataTable();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmdMembers);
                            adapter.Fill(dtMembers);

                            foreach (DataRow memberRow in dtMembers.Rows)
                            {
                                string memberId = memberRow["MemberID"].ToString();
                                string fullName = $"{memberRow["Name"]} {memberRow["Surname"]}";
                                string fileName = Path.Combine(targetFolder, 
                                    $"MemberOrder_{memberId}_{selectedOrderDate:yyyyMMdd}.pdf");

                                GenerateSingleMemberPdf(memberId, fullName, selectedOrderDate, fileName);
                                pdfCount++;
                            }
                        }

                        MessageBox.Show($"Generated PDFs for {pdfCount} members successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating individual PDFs: " + ex.Message,
                            "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GenerateSingleMemberPdf(string memberId, string fullName, DateTime orderDate, string filePath)
        {
   
            iTextSharp.text.Document pdfDoc = new 
                iTextSharp.text.Document(iTextSharp.text.PageSize.A5, 20f, 20f, 20f, 20f);
            PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
            pdfDoc.Open();

            iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14f);
            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10f);
            iTextSharp.text.Font textFont = FontFactory.GetFont(FontFactory.HELVETICA, 10f);

            pdfDoc.Add(new Paragraph("Member Grocery Order Summary", titleFont));
            pdfDoc.Add(new Paragraph($"Member: {memberId} - {fullName}", textFont));
            pdfDoc.Add(new Paragraph($"Date: {orderDate:dd/MM/yyyy}\n\n", textFont));

            PdfPTable table = new PdfPTable(3) { WidthPercentage = 100f };
            table.SetWidths(new float[] { 5f, 2f, 3f });

            table.AddCell(new PdfPCell(new Phrase("Item Description", headerFont)));
            table.AddCell(new PdfPCell(new Phrase("Qty", headerFont)));
            table.AddCell(new PdfPCell(new Phrase("Total (R)", headerFont)));

            string query = @"
            SELECT i.Description, o.Quantity, o.TotalPrice
            FROM tblMemberOrders o
            INNER JOIN tblGroceryItems i ON o.ItemID = i.ItemID
            WHERE o.MemberID = @MemberID AND CAST(o.OrderDate AS DATE) = @SelectedDate;";

            decimal memberTotal = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", memberId);
                    cmd.Parameters.Add("@SelectedDate", SqlDbType.Date).Value = orderDate.Date;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        table.AddCell(new Phrase(reader["Description"].ToString(), textFont));
                        table.AddCell(new Phrase(reader["Quantity"].ToString(), textFont));

                        decimal price = Convert.ToDecimal(reader["TotalPrice"]);
                        memberTotal += price;
                        table.AddCell(new Phrase($"R {price:N2}", textFont));
                    }
                }
            }

            pdfDoc.Add(table);
            pdfDoc.Add(new Paragraph($"\nMember Total: R {memberTotal:N2}", titleFont)
             { Alignment = Element.ALIGN_RIGHT });

            pdfDoc.Close();
        }

        private void btnGenerateIndividualPDFs_Click(object sender, EventArgs e)
        {
            DateTime selectedOrderDate = calendarWeek.SelectionStart;

            if (selectedOrderDate.DayOfWeek != DayOfWeek.Friday)
            {
                MessageBox.Show("Please select a valid Friday order date first.", "Invalid Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select folder to save individual member receipt PDFs";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetFolder = folderDialog.SelectedPath;

                   
                    string memberQuery = @"
                    SELECT DISTINCT m.MemberID, m.Name, m.Surname
                    FROM tblMemberOrders o
                    INNER JOIN tblMembers m ON o.MemberID = m.MemberID
                    WHERE CAST(o.OrderDate AS DATE) = @SelectedDate
                    ORDER BY m.MemberID;";

                    try
                    {
                        int generatedCount = 0;

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmdMembers = new SqlCommand(memberQuery, conn))
                            {
                                cmdMembers.Parameters.Add("@SelectedDate", SqlDbType.Date).Value = selectedOrderDate.Date;

                                DataTable dtMembers = new DataTable();
                                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdMembers))
                                {
                                    adapter.Fill(dtMembers);
                                }

                                if (dtMembers.Rows.Count == 0)
                                {
                                    MessageBox.Show("No member orders were found for the selected date.", "No Orders",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                
                                foreach (DataRow memberRow in dtMembers.Rows)
                                {
                                    string memberId = memberRow["MemberID"].ToString();
                                    string fullName = $"{memberRow["Name"]} {memberRow["Surname"]}";
                                    string safeFileName = $"Receipt_{memberId}_{selectedOrderDate:yyyyMMdd}.pdf";
                                    string fullPath = Path.Combine(targetFolder, safeFileName);

                                    GenerateIndividualMemberPdf(memberId, fullName, selectedOrderDate, fullPath);
                                    generatedCount++;
                                }
                            }
                        }

                        MessageBox.Show($"Successfully generated {generatedCount} individual PDF receipts in:\n{targetFolder}", 
                            "PDF Generation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating individual PDFs: " + ex.Message,
                            "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GenerateIndividualMemberPdf(string memberId, string fullName, DateTime orderDate, string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                iTextSharp.text.Document pdfDoc =
                    new iTextSharp.text.Document(iTextSharp.text.PageSize.A5, 20f, 20f, 20f, 20f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();


                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14f);
                iTextSharp.text.Font subTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10f);
                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9f);
                iTextSharp.text.Font textFont = FontFactory.GetFont(FontFactory.HELVETICA, 9f);


                pdfDoc.Add(new Paragraph("MEMBER ORDER SUMMARY RECEIPT", titleFont));
                pdfDoc.Add(new Paragraph($"Member ID : {memberId}", subTitleFont));
                pdfDoc.Add(new Paragraph($"Member    : {fullName}", textFont));
                pdfDoc.Add(new Paragraph($"Order Date: {orderDate:dd/MM/yyyy}\n\n", textFont));


                PdfPTable table = new PdfPTable(3) { WidthPercentage = 100f };
                table.SetWidths(new float[] { 5f, 2f, 3f });

                table.AddCell(new PdfPCell(new Phrase("Item Description", headerFont)) { Padding = 5f });
                table.AddCell(new PdfPCell(new Phrase("Qty", headerFont)) { Padding = 5f });
                table.AddCell(new PdfPCell(new Phrase("Total (R)", headerFont)) { Padding = 5f });


                string itemQuery = @"
                SELECT i.Description, o.Quantity, o.TotalPrice
                FROM tblMemberOrders o
                INNER JOIN tblGroceryItems i ON o.ItemID = i.ItemID
                WHERE o.MemberID = @MemberID AND CAST(o.OrderDate AS DATE) = @SelectedDate
                ORDER BY i.ItemID;";

                decimal memberTotal = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(itemQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberId);
                        cmd.Parameters.Add("@SelectedDate", SqlDbType.Date).Value = orderDate.Date;
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string desc = reader["Description"].ToString();
                                string qty = reader["Quantity"].ToString();
                                decimal price = Convert.ToDecimal(reader["TotalPrice"]);
                                memberTotal += price;

                                table.AddCell(new PdfPCell(new Phrase(desc, textFont)) { Padding = 4f });
                                table.AddCell(new PdfPCell(new Phrase(qty, textFont)) { Padding = 4f });
                                table.AddCell(new PdfPCell(new Phrase($"R {price:N2}", textFont)) { Padding = 4f });
                            }
                        }
                    }
                }

                pdfDoc.Add(table);

                Paragraph totalPara = new Paragraph($"\nTotal Amount Due: R {memberTotal:N2}", titleFont)
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                pdfDoc.Add(totalPara);

                pdfDoc.Close();
            }
        }
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
