using BUS;

namespace MobileStore
{
    public partial class Customer : Form
    {
        BUS_Customer c;
        public Customer()
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

        private void Customer_Load(object sender, EventArgs e)
        {
            grdCustomer.DataSource = c.selectQuery();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCID.Text != "" && txtCName.Text != "" && cbGender.Text != "" && txtPurchase.Text != "" && txtBill.Text != "")
            {
                c = new BUS_Customer(txtCID.Text, txtCName.Text, cbGender.Text, txtPurchase.Text, float.Parse(txtBill.Text));
                c.addQuery();
            }
            else
            {
                MessageBox.Show("Please fill all required information");
            }
            grdCustomer.DataSource = c.selectQuery();
            txtCID.Text = "";
            txtCName.Text = "";
            cbGender.Text = "";
            txtPurchase.Text = "";
            txtBill.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCID.Text != "" && txtCName.Text != "" && cbGender.Text != "" && txtPurchase.Text != "" && txtBill.Text != "")
            {
                c = new BUS_Customer(txtCID.Text, txtCName.Text, cbGender.Text, txtPurchase.Text, float.Parse(txtBill.Text));
                c.updateQuery();
            }
            else
            {
                MessageBox.Show("Please fill all required information");
            }
            grdCustomer.DataSource = c.selectQuery();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (grdCustomer.CurrentRow != null)
            {
                // Lấy giá trị của cột CustomerID từ hàng được chọn
                string customerID = grdCustomer.CurrentRow.Cells["CustomerID"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Are you sure you want to delete customer with ID " + customerID + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra xem người dùng đã chọn Yes hay không
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Thực hiện xóa dữ liệu
                        c.deleteQuery(customerID);

                        // Cập nhật lại dữ liệu trên DataGridView
                        grdCustomer.DataSource = c.selectQuery();
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi cho người dùng
                        MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Hiển thị thông báo cho người dùng nếu không có hàng nào được chọn
                MessageBox.Show("Please select a customer to delete.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCID.Text = "";
            txtCName.Text = "";
            cbGender.Text = "";
            txtPurchase.Text = "";
            txtBill.Text = "";
        }

        private void grdCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCID.Text = grdCustomer.CurrentRow.Cells[0].Value.ToString();
            txtCName.Text = grdCustomer.CurrentRow.Cells[1].Value.ToString();
            cbGender.Text = grdCustomer.CurrentRow.Cells[2].Value.ToString();
            txtPurchase.Text = grdCustomer.CurrentRow.Cells[3].Value.ToString();
            txtBill.Text = grdCustomer.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
