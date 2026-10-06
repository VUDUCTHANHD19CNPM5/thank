using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bai5_3
{
    public partial class Form1 : Form
    {
        List<Product> products = new List<Product>();

        public Form1()
        {
            InitializeComponent();

            cboCategory.Items.Add("Điện thoại");
            cboCategory.Items.Add("Laptop");
            cboCategory.Items.Add("Phụ kiện");

            bsProducts.DataSource = products;
            dgvProducts.DataSource = bsProducts;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "" ||
                txtProductName.Text == "" ||
                txtUnitPrice.Text == "" ||
                txtQuantity.Text == "" ||
                cboCategory.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            double unitPrice;
            int quantity;

            if (!double.TryParse(txtUnitPrice.Text, out unitPrice))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            Product product = new Product();

            product.ProductId = txtProductId.Text;
            product.ProductName = txtProductName.Text;
            product.UnitPrice = unitPrice;
            product.Quantity = quantity;
            product.Category = cboCategory.SelectedItem.ToString();

            products.Add(product);

            bsProducts.DataSource = null;
            bsProducts.DataSource = products;

            dgvProducts.DataSource = bsProducts;

            ClearInput();

            MessageBox.Show("Thêm sản phẩm thành công!");
        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Product product = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;

            if (product != null)
            {
                txtProductId.Text = product.ProductId;
                txtProductName.Text = product.ProductName;
                txtUnitPrice.Text = product.UnitPrice.ToString();
                txtQuantity.Text = product.Quantity.ToString();
                cboCategory.Text = product.Category;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
                return;

            Product product =
                dgvProducts.CurrentRow.DataBoundItem as Product;

            if (product == null)
                return;

            double unitPrice;
            int quantity;

            if (!double.TryParse(txtUnitPrice.Text, out unitPrice))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            product.ProductId = txtProductId.Text;
            product.ProductName = txtProductName.Text;
            product.UnitPrice = unitPrice;
            product.Quantity = quantity;
            product.Category = cboCategory.Text;

            bsProducts.ResetBindings(false);

            MessageBox.Show("Sửa sản phẩm thành công!");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
                return;

            Product product =
                dgvProducts.CurrentRow.DataBoundItem as Product;

            if (product == null)
                return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                products.Remove(product);

                bsProducts.ResetBindings(false);

                ClearInput();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (keyword == "")
            {
                bsProducts.DataSource = products;
                return;
            }

            List<Product> result = products
                .Where(p => p.ProductName.ToLower().Contains(keyword))
                .ToList();

            bsProducts.DataSource = result;
        }
        private void ClearInput()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            cboCategory.SelectedIndex = -1;

            txtProductId.Focus();
        }
    }
}
