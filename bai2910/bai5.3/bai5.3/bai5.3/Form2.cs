using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bai5._3
{
    public partial class Form2 : Form
    {
        private MonAnBUS monAnBUS = new MonAnBUS();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadDataGrid();
        }

        private void LoadCategories()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM DanhMuc");
            cbDanhMuc.DataSource = dt;
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadDataGrid()
        {
            dgvMonAn.DataSource = monAnBUS.GetAllMonAn();

            if (dgvMonAn.Columns["MaDanhMuc"] != null) dgvMonAn.Columns["MaDanhMuc"].Visible = false;
            if (dgvMonAn.Columns["MaMon"] != null) dgvMonAn.Columns["MaMon"].HeaderText = "Mã món";
            if (dgvMonAn.Columns["TenMon"] != null) dgvMonAn.Columns["TenMon"].HeaderText = "Tên món";
            if (dgvMonAn.Columns["TenDanhMuc"] != null) dgvMonAn.Columns["TenDanhMuc"].HeaderText = "Danh mục";
            if (dgvMonAn.Columns["DonGia"] != null) dgvMonAn.Columns["DonGia"].HeaderText = "Đơn giá";
        }

        // Khi click vào 1 hàng trên DataGridView -> Đổ dữ liệu lên TextBox
        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];
                txtMaMon.Text = row.Cells["MaMon"].Value.ToString();
                txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                cbDanhMuc.SelectedValue = row.Cells["MaDanhMuc"].Value;
            }
        }

        // Chức năng Thêm món
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                decimal donGia = 0;
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia)) donGia = -1;

                MonAnDTO mon = new MonAnDTO
                {
                    TenMon = txtTenMon.Text.Trim(),
                    MaDanhMuc = Convert.ToInt32(cbDanhMuc.SelectedValue),
                    DonGia = donGia
                };

                if (monAnBUS.AddMonAn(mon))
                {
                    MessageBox.Show("Thêm món mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cảnh báo: " + ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Chức năng Sửa món
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn món cần sửa từ bảng bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal donGia = 0;
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia)) donGia = -1;

                MonAnDTO mon = new MonAnDTO
                {
                    MaMon = Convert.ToInt32(txtMaMon.Text),
                    TenMon = txtTenMon.Text.Trim(),
                    MaDanhMuc = Convert.ToInt32(cbDanhMuc.SelectedValue),
                    DonGia = donGia
                };

                if (monAnBUS.UpdateMonAn(mon))
                {
                    MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cảnh báo: " + ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Chức năng Xóa món
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMon = Convert.ToInt32(txtMaMon.Text);
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (monAnBUS.DeleteMonAn(maMon))
                {
                    MessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ResetFields();
                }
            }
        }

        private void ResetFields()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtDonGia.Clear();
        }
    }
}
