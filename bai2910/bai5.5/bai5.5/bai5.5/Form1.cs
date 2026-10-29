using System.Data;

namespace bai5._5
{
    public partial class Form1 : Form
    {
        private InventoryBUS inventoryBUS = new InventoryBUS();
        private List<ChiTietPhieuKhoDTO> listChiTietTam = new List<ChiTietPhieuKhoDTO>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadVatTuToGrid();
            LoadNhaCungCapToCombo();
            InitLoaiPhieuCombo();
            RefreshChiTietGrid();
            CapNhatThongKeTonKho();
        }
        private void LoadVatTuToGrid()
        {
            dgvVatTu.DataSource = inventoryBUS.GetAllVatTu();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvVatTu.DataSource = inventoryBUS.TimKiemVatTu(txtTimKiem.Text.Trim());
        }

        private void LoadNhaCungCapToCombo()
        {
            cbNhaCungCap.DataSource = inventoryBUS.GetAllNhaCungCap();
            cbNhaCungCap.DisplayMember = "TenNCC";
            cbNhaCungCap.ValueMember = "MaNCC";
        }

        private void InitLoaiPhieuCombo()
        {
            cbLoaiPhieu.Items.Clear();
            cbLoaiPhieu.Items.Add("NHAP");
            cbLoaiPhieu.Items.Add("XUAT");
            cbLoaiPhieu.SelectedIndex = 0;
        }
        private void cbLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiPhieu.SelectedItem.ToString() == "XUAT")
            {
                cbNhaCungCap.Enabled = false;
                cbNhaCungCap.SelectedIndex = -1;
            }
            else
            {
                cbNhaCungCap.Enabled = true;
                if (cbNhaCungCap.Items.Count > 0) cbNhaCungCap.SelectedIndex = 0;
            }
        }
        private void dgvVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVatTu.Rows[e.RowIndex];
                txtMaVatTuChon.Text = row.Cells["MaVatTu"].Value.ToString();
                txtTenVatTuChon.Text = row.Cells["TenVatTu"].Value.ToString();
                txtDVTChon.Text = row.Cells["DVT"].Value.ToString();
            }
        }

        private void btnThemVatTuVaoPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaVatTuChon.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 vật tư từ bảng bên trái!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal soLuong = nudSoLuong.Value;
            decimal donGia = nudDonGia.Value;

            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng vật tư trong danh sách tạm
            var existing = listChiTietTam.Find(x => x.MaVatTu == txtMaVatTuChon.Text);
            if (existing != null)
            {
                existing.SoLuong += soLuong;
                existing.DonGia = donGia;
                existing.DVT = txtDVTChon.Text; // <--- Thêm nếu đã tồn tại
            }
            else
            {
                listChiTietTam.Add(new ChiTietPhieuKhoDTO
                {
                    MaVatTu = txtMaVatTuChon.Text,
                    TenVatTu = txtTenVatTuChon.Text,
                    DVT = txtDVTChon.Text,       // <--- BỔ SUNG DÒNG NÀY ĐỂ HIỂN THỊ ĐVT
                    SoLuong = soLuong,
                    DonGia = donGia
                });
            }

            RefreshChiTietGrid();
        }

        private void RefreshChiTietGrid()
        {
            dgvChiTietPhieu.DataSource = null;
            dgvChiTietPhieu.DataSource = listChiTietTam;

            decimal tongTien = 0;
            foreach (var item in listChiTietTam)
            {
                tongTien += item.ThanhTien;
            }

            lblTongTienPhieu.Text = $"Tổng tiền phiếu: {tongTien:N0} VNĐ";
            lblTongTienPhieu.Tag = tongTien;
        }
        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (listChiTietTam.Count == 0)
            {
                MessageBox.Show("Chưa có vật tư nào trong phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiPhieu = cbLoaiPhieu.SelectedItem.ToString();
            int? maNCC = null;

            if (loaiPhieu == "NHAP")
            {
                if (cbNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Phiếu nhập bắt buộc phải chọn Nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                maNCC = Convert.ToInt32(cbNhaCungCap.SelectedValue);
            }

            PhieuKhoDTO phieu = new PhieuKhoDTO
            {
                LoaiPhieu = loaiPhieu,
                MaNCC = maNCC,
                TongTien = Convert.ToDecimal(lblTongTienPhieu.Tag)
            };

            string errorMsg;
            if (inventoryBUS.LapPhieuKho(phieu, listChiTietTam, out errorMsg))
            {
                MessageBox.Show($"Lập {loaiPhieu} kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listChiTietTam.Clear();
                RefreshChiTietGrid();
                LoadVatTuToGrid();
                CapNhatThongKeTonKho();
            }
            else
            {
                MessageBox.Show(errorMsg, "Lỗi Giao Dịch Kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CapNhatThongKeTonKho()
        {
            DataTable dtCanhBao = inventoryBUS.GetVatTuCanhBaoTonKho(10);
            dgvCanhBao.DataSource = dtCanhBao;
            decimal tongGiaTri = inventoryBUS.GetTongGiaTriTonKho();
            lblTongGiaTriKho.Text = $"TỔNG GIÁ TRỊ TỒN KHO: {tongGiaTri:N0} VNĐ";
        }
    }
}
