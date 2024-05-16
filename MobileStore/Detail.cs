using BUS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileStore
{
    public partial class Detail : Form
    {
        BUS_Customer c;
        public Detail()
        {
            InitializeComponent();
            c = new BUS_Customer("", "", "", "", 0);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void Detail_Load(object sender, EventArgs e)
        {

        }

        private void FetchCus()
        {
            try
            {
                string customerID = txtCID.Text; // Lấy customerID từ TextBox txtCID

                // Gọi phương thức select1ID từ đối tượng BUS_Customer để lấy thông tin của khách hàng
                DataTable customerData = c.select1ID(customerID);

                // Nếu có thông tin của khách hàng
                if (customerData.Rows.Count > 0)
                {
                    // Lấy thông tin từ dòng đầu tiên của DataTable
                    DataRow row = customerData.Rows[0];

                    string customerName = row["CustomerName"].ToString();
                    string gender = row["Gender"].ToString();
                    string purchasedMobile = row["PurchasedMobile"].ToString();
                    decimal bill = Convert.ToDecimal(row["Bill"]);

                    // Hiển thị thông tin của khách hàng lên các Label hoặc các điều khiển khác trên giao diện người dùng
                    lbCID.Text = customerID;
                    lbCName.Text = customerName;
                    lbGender.Text = gender;
                    lbPurchased.Text = purchasedMobile;
                    lbBill.Text = bill.ToString();

                    lbCID.Visible = true;
                    lbCName.Visible = true;
                    lbGender.Visible = true;
                    lbPurchased.Visible = true;
                    lbBill.Visible = true;
                }
                else
                {
                    MessageBox.Show("Have no information about this Customer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReferesh_Click(object sender, EventArgs e)
        {
            FetchCus();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (lbCID.Visible)
            {
                try
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF files|*.pdf", FileName = "CustomerDetail.pdf" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            Document doc = new Document(PageSize.A4);
                            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                            doc.Open();

                            // Thêm tiêu đề
                            doc.Add(new Paragraph("Customer Details"));
                            doc.Add(new Paragraph(" ")); // Dòng trống

                            // Thêm thông tin khách hàng
                            doc.Add(new Paragraph("Customer ID: " + lbCID.Text));
                            doc.Add(new Paragraph("Customer Name: " + lbCName.Text));
                            doc.Add(new Paragraph("Gender: " + lbGender.Text));
                            doc.Add(new Paragraph("Purchased Mobile: " + lbPurchased.Text));
                            doc.Add(new Paragraph("Bill: " + lbBill.Text));

                            doc.Close();
                            MessageBox.Show("PDF file created successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fetch customer information before exporting to PDF.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
