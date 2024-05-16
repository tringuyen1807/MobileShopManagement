using BUS;
using ClosedXML.Excel;

namespace MobileStore
{
    public partial class Product : Form
    {
        BUS_Product p;
        public Product()
        {
            InitializeComponent();
            p = new BUS_Product("", "", "", "", 0);
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            // Tạo một danh sách các hãng điện thoại và các model tương ứng
            Dictionary<string, List<string>> phoneModels = new Dictionary<string, List<string>>
            {
                {"Samsung", new List<string>{"Galaxy S21", "Galaxy Note 20", "Galaxy A52", "Galaxy M32", "Galaxy Z Fold 3"}},
                {"Apple", new List<string>{"iPhone 13 Pro", "iPhone SE 2020", "iPhone 12 Mini", "iPhone XR", "iPhone 11"}},
                {"OPPO", new List<string>{"OPPO Find X3 Pro", "OPPO Reno6", "OPPO A95", "OPPO F19 Pro", "OPPO K9"}},
                {"Vivo", new List<string>{"Vivo X60 Pro", "Vivo V21", "Vivo Y53s", "Vivo S10 Pro", "Vivo iQOO 9"}},
                {"Xiaomi", new List<string>{"Xiaomi Mi 11 Ultra", "Redmi Note 10 Pro", "Redmi K40", "Poco X3 Pro", "Black Shark 4"}},
                {"Realme", new List<string>{"Realme GT Master Edition", "Realme X7 Pro", "Realme Narzo 50", "Realme C25", "Realme GT Neo 2"}},
                {"Nokia", new List<string>{"Nokia G50", "Nokia X20", "Nokia C30", "Nokia 8.3", "Nokia 5.4"}},
                {"Huawei", new List<string>{"Huawei P50 Pro", "Huawei Mate 40", "Huawei Nova 8", "Huawei Y9a", "Honor 50"}},
                {"Motorola", new List<string>{"Motorola Edge 20", "Motorola Moto G60", "Motorola One Fusion+", "Motorola Moto E7 Plus", "Motorola Razr 5G"}},
                {"Sony", new List<string>{"Sony Xperia 1 III", "Sony Xperia 10 III", "Sony Xperia L4", "Sony Xperia XZ3", "Sony Xperia XZ2 Compact"}}
            };

            // Thêm các hãng điện thoại vào ComboBox
            foreach (var brand in phoneModels.Keys)
            {
                cbMBName.Items.Add(brand);
            }

            // Xử lý sự kiện khi chọn một hãng điện thoại
            cbMBName.SelectedIndexChanged += (sender, e) =>
            {
                // Xóa các model cũ trước khi thêm model mới
                cbSeries.Items.Clear();

                // Lấy hãng điện thoại được chọn
                string selectedBrand = cbMBName.SelectedItem.ToString();

                // Thêm các model của hãng điện thoại được chọn vào ComboBox
                foreach (var model in phoneModels[selectedBrand])
                {
                    cbSeries.Items.Add(model);
                }
            };
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            grdProduct.DataSource = p.selectQuery();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMBID.Text != "" && cbMBName.Text != "" && cbSeries.Text != "" && txtStorage.Text != "" && txtPrice.Text != "")
            {
                p = new BUS_Product(txtMBID.Text, cbMBName.Text, cbSeries.Text, txtStorage.Text, float.Parse(txtPrice.Text));
                p.addQuery();
            }
            else
            {
                MessageBox.Show("Please fill all required information");
            }
            grdProduct.DataSource = p.selectQuery();
            txtMBID.Text = "";
            cbMBName.Text = "";
            cbSeries.Text = "";
            txtStorage.Text = "";
            txtPrice.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMBID.Text != "" && cbMBName.Text != "" && cbSeries.Text != "" && txtStorage.Text != "" && txtPrice.Text != "")
            {
                p = new BUS_Product(txtMBID.Text, cbMBName.Text, cbSeries.Text, txtStorage.Text, float.Parse(txtPrice.Text));
                p.updateQuery();
            }
            else
            {
                MessageBox.Show("Please fill all required information");
            }
            grdProduct.DataSource = p.selectQuery();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (grdProduct.CurrentRow != null)
            {
                // Lấy giá trị của cột MobileID từ hàng được chọn
                string mobileID = grdProduct.CurrentRow.Cells["MobileID"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Are you sure you want to delete product with ID " + mobileID + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra xem người dùng đã chọn Yes hay không
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Thực hiện xóa dữ liệu
                        p.deleteQuery(mobileID);

                        // Cập nhật lại dữ liệu trên DataGridView
                        grdProduct.DataSource = p.selectQuery();
                        txtMBID.Text = "";
                        cbMBName.Text = "";
                        cbSeries.Text = "";
                        txtStorage.Text = "";
                        txtPrice.Text = "";
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi cho người dùng
                        MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Hiển thị thông báo cho người dùng nếu không có hàng nào được chọn
                MessageBox.Show("Please select a product to delete.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void grdProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMBID.Text = grdProduct.CurrentRow.Cells[0].Value.ToString();
            cbMBName.Text = grdProduct.CurrentRow.Cells[1].Value.ToString();
            cbSeries.Text = grdProduct.CurrentRow.Cells[2].Value.ToString();
            txtStorage.Text = grdProduct.CurrentRow.Cells[3].Value.ToString();
            txtPrice.Text = grdProduct.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMBID.Text = "";
            cbMBName.Text = "";
            cbSeries.Text = "";
            txtStorage.Text = "";
            txtPrice.Text = "";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {

                            wb.Worksheets.Add((System.Data.DataTable)grdProduct.DataSource, "Products");
                            wb.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Data exported successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
