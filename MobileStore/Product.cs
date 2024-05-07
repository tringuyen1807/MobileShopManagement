using BUS;
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
    public partial class Product : Form
    {
        BUS_Product p;
        public Product()
        {
            InitializeComponent();
            p = new BUS_Product("", "", "", "", 0);
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
    }
}
