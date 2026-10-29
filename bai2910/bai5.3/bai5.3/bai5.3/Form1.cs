using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace bai5._3
{
    public partial class Form1 : Form
    {
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();
        private MonAnBUS monAnBUS = new MonAnBUS();

        private int selectedTableId = -1;
        private string selectedTableName = "";

        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form tải lên
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTableLayout();
            LoadCategories();
        }

        // 1. Hiển thị sơ đồ bàn dạng Button động
        public void LoadTableLayout()
        {
            flpTable.Controls.Clear();
            DataTable dtBan = DatabaseHelper.ExecuteQuery("SELECT * FROM BanAn");

            foreach (DataRow row in dtBan.Rows)
            {
                Button btn = new Button();
                btn.Width = 90;
                btn.Height = 90;
                btn.Tag = row["MaBan"];

                string trangThai = row["TrangThai"].ToString();
                btn.Text = $"{row["TenBan"]}\n({trangThai})";
                btn.Font = new Font("Arial", 9, FontStyle.Bold);

                // Màu sắc trực quan theo trạng thái bàn
                if (trangThai == "Trống")
                {
                    btn.BackColor = Color.LightGreen;
                    btn.ForeColor = Color.DarkGreen;
                }
                else
                {
                    btn.BackColor = Color.Salmon;
                    btn.ForeColor = Color.DarkRed;
                }

                btn.Click += BtnTable_Click;
                flpTable.Controls.Add(btn);
            }
        }

        // Sự kiện Click chọn Bàn
        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            selectedTableId = Convert.ToInt32(btn.Tag);
            selectedTableName = btn.Text.Split('\n')[0];

            lblTableTitle.Text = "Đang chọn: " + selectedTableName;

            LoadBillDetails();
        }

        // 2. Nạp chi tiết hóa đơn vào DataGridView
        private void LoadBillDetails()
        {
            if (selectedTableId == -1) return;

            int maHoaDon = hoaDonBUS.GetUnpaidHoaDonIdByBan(selectedTableId);
            if (maHoaDon != -1)
            {
                DataTable dt = hoaDonBUS.GetChiTietHoaDon(maHoaDon);
                dgvBill.DataSource = dt;

                // Tự động định dạng tên cột
                if (dgvBill.Columns["MaMon"] != null) dgvBill.Columns["MaMon"].Visible = false;
                if (dgvBill.Columns["TenMon"] != null) dgvBill.Columns["TenMon"].HeaderText = "Tên món";
                if (dgvBill.Columns["SoLuong"] != null) dgvBill.Columns["SoLuong"].HeaderText = "Số lượng";
                if (dgvBill.Columns["DonGia"] != null) dgvBill.Columns["DonGia"].HeaderText = "Đơn giá";
                if (dgvBill.Columns["ThanhTien"] != null) dgvBill.Columns["ThanhTien"].HeaderText = "Thành tiền";

                // Tính tổng tiền
                decimal tongTien = 0;
                foreach (DataRow r in dt.Rows)
                {
                    tongTien += Convert.ToDecimal(r["ThanhTien"]);
                }
                txtTongTien.Text = tongTien.ToString("N0") + " VNĐ";
                txtTongTien.Tag = tongTien;
            }
            else
            {
                dgvBill.DataSource = null;
                txtTongTien.Text = "0 VNĐ";
                txtTongTien.Tag = (decimal)0;
            }
        }

        // Nạp danh mục món vào ComboBox
        private void LoadCategories()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM DanhMuc");
            cbCategory.DataSource = dt;
            cbCategory.DisplayMember = "TenDanhMuc";
            cbCategory.ValueMember = "MaDanhMuc";
        }

        // Sự kiện đổi danh mục -> Nạp món ăn tương ứng
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue != null && int.TryParse(cbCategory.SelectedValue.ToString(), out int idDanhMuc))
            {
                DataTable dtMon = monAnBUS.GetMonAnByDanhMuc(idDanhMuc);
                cbMonAn.DataSource = dtMon;
                cbMonAn.DisplayMember = "TenMon";
                cbMonAn.ValueMember = "MaMon";
            }
        }

        // Chức năng Thêm món vào bàn
        private void btnAddMon_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn một bàn trước khi thêm món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbMonAn.SelectedItem == null) return;

            int maMon = Convert.ToInt32(cbMonAn.SelectedValue);
            int soLuong = (int)nudSoLuong.Value;

            DataRowView rowView = (DataRowView)cbMonAn.SelectedItem;
            decimal donGia = Convert.ToDecimal(rowView["DonGia"]);

            // Gọi BUS thêm món
            hoaDonBUS.GoiMon(selectedTableId, maMon, soLuong, donGia);

            LoadTableLayout(); // Cập nhật màu sắc bàn
            LoadBillDetails();  // Cập nhật lại danh sách hóa đơn
        }

        // Chức năng Thanh toán (dùng MySqlTransaction trong BUS)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHoaDon = hoaDonBUS.GetUnpaidHoaDonIdByBan(selectedTableId);
            if (maHoaDon == -1)
            {
                MessageBox.Show("Bàn này hiện không có hóa đơn chưa thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal tongTien = txtTongTien.Tag != null ? (decimal)txtTongTien.Tag : 0;

            if (MessageBox.Show($"Xác nhận thanh toán cho {selectedTableName}?\nTổng số tiền: {tongTien:N0} VNĐ",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = hoaDonBUS.ThanhToan(maHoaDon, selectedTableId, tongTien);
                if (result)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableLayout();
                    LoadBillDetails();
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại! Đã xảy ra lỗi giao dịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút chuyển sang màn hình Quản lý Menu
        private void btnQuanLyMenu_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            LoadCategories(); // Refresh danh mục khi đóng màn hình quản lý
        }
    }
}
