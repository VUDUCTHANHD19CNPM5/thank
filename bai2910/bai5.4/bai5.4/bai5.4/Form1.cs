using System.Data;

namespace bai5._4
{
    public partial class Form1 : Form
    {
        private HotelBUS hotelBUS = new HotelBUS();
        private DataTable dtPhong;
        private DataView dvPhong; // Dùng DataView để Lọc ngắt kết nối
        private string selectedSoPhong = "";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitFilterData();
            LoadPhongData();
            LoadDichVuCombo();
        }
        private void InitFilterData()
        {
            cbFilterLoai.Items.Clear();
            cbFilterLoai.Items.AddRange(new string[] { "Tất cả", "Đơn", "Đôi", "VIP" });
            cbFilterLoai.SelectedIndex = 0;

            cbFilterTrangThai.Items.Clear();
            cbFilterTrangThai.Items.AddRange(new string[] { "Tất cả", "Trống", "Đang ở", "Đang dọn dẹp" });
            cbFilterTrangThai.SelectedIndex = 0;
        }

        private void LoadPhongData()
        {
            dtPhong = hotelBUS.GetAllPhong();
            dvPhong = new DataView(dtPhong);
            dgvPhong.DataSource = dvPhong;
            if (dgvPhong.Columns["SoPhong"] != null) dgvPhong.Columns["SoPhong"].HeaderText = "Số phòng";
            if (dgvPhong.Columns["LoaiPhong"] != null) dgvPhong.Columns["LoaiPhong"].HeaderText = "Loại phòng";
            if (dgvPhong.Columns["GiaTheoGio"] != null) dgvPhong.Columns["GiaTheoGio"].HeaderText = "Giá / Giờ";
            if (dgvPhong.Columns["TrangThai"] != null) dgvPhong.Columns["TrangThai"].HeaderText = "Trạng thái";
        }
        private void ApplyFilter(object sender, EventArgs e)
        {
            if (dvPhong == null) return;

            string filter = "1=1";
            if (cbFilterLoai.SelectedIndex > 0)
                filter += $" AND LoaiPhong = '{cbFilterLoai.SelectedItem}'";

            if (cbFilterTrangThai.SelectedIndex > 0)
                filter += $" AND TrangThai = '{cbFilterTrangThai.SelectedItem}'";

            dvPhong.RowFilter = filter;
        }
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
                selectedSoPhong = row.Cells["SoPhong"].Value.ToString();
                string trangThai = row.Cells["TrangThai"].Value.ToString();

                lblCurrentRoom.Text = $"Đang chọn: Phòng {selectedSoPhong} ({trangThai})";

                LoadChiTietPhongActive();
            }
        }

        private void LoadChiTietPhongActive()
        {
            if (string.IsNullOrEmpty(selectedSoPhong)) return;

            int maPhieu = hotelBUS.GetActivePhieuBySoPhong(selectedSoPhong);
            if (maPhieu != -1)
            {
                DataTable dtDV = hotelBUS.GetDichVuDaSuDung(maPhieu);
                dgvDichVuDaDung.DataSource = dtDV;

                if (dgvDichVuDaDung.Columns["TenDV"] != null) dgvDichVuDaDung.Columns["TenDV"].HeaderText = "Tên dịch vụ";
                if (dgvDichVuDaDung.Columns["SoLuong"] != null) dgvDichVuDaDung.Columns["SoLuong"].HeaderText = "Số lượng";
                if (dgvDichVuDaDung.Columns["DonGia"] != null) dgvDichVuDaDung.Columns["DonGia"].HeaderText = "Đơn giá";
                if (dgvDichVuDaDung.Columns["ThanhTien"] != null) dgvDichVuDaDung.Columns["ThanhTien"].HeaderText = "Thành tiền";
                if (dgvDichVuDaDung.Columns["ThoiGian"] != null) dgvDichVuDaDung.Columns["ThoiGian"].HeaderText = "Thời gian gọi";

                TinhTongTienThoiDiemHienTai(maPhieu);
            }
            else
            {
                dgvDichVuDaDung.DataSource = null;
                lblTongTien.Text = "TỔNG CỘNG: 0 VNĐ";
                lblTongTien.Tag = (decimal)0;
            }
        }
        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (!string.IsNullOrEmpty(cccd))
            {
                KhachHangDTO kh = hotelBUS.GetKhachHangByCCCD(cccd);
                if (kh != null)
                {
                    txtHoTen.Text = kh.HoTen;
                    txtSDT.Text = kh.SoDienThoai;
                    txtCCCD.Tag = kh.MaKH;
                }
                else
                {
                    txtHoTen.Clear();
                    txtSDT.Clear();
                    txtCCCD.Tag = null;
                }
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoPhong))
            {
                MessageBox.Show("Vui lòng chọn một phòng từ bảng danh sách trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int activePhieu = hotelBUS.GetActivePhieuBySoPhong(selectedSoPhong);
            if (activePhieu != -1)
            {
                MessageBox.Show("Phòng này hiện đang có khách ở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cccd = txtCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Số CCCD và Họ tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKH;
            if (txtCCCD.Tag != null)
            {
                maKH = Convert.ToInt32(txtCCCD.Tag);
            }
            else
            {
                KhachHangDTO khMoi = new KhachHangDTO
                {
                    HoTen = hoTen,
                    CCCD = cccd,
                    SoDienThoai = txtSDT.Text.Trim()
                };
                maKH = hotelBUS.ThemKhachHang(khMoi);
            }

            if (hotelBUS.CheckIn(selectedSoPhong, maKH))
            {
                MessageBox.Show($"Check-in thành công cho Phòng {selectedSoPhong}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhongData();
                LoadChiTietPhongActive();
            }
            else
            {
                MessageBox.Show("Check-in thất bại! Đã xảy ra lỗi hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDichVuCombo()
        {
            DataTable dt = hotelBUS.GetAllDichVu();
            cbDichVu.DataSource = dt;
            cbDichVu.DisplayMember = "TenDV";
            cbDichVu.ValueMember = "MaDV";
        }

        private void btnGoiDV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng cần gọi dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu = hotelBUS.GetActivePhieuBySoPhong(selectedSoPhong);
            if (maPhieu == -1)
            {
                MessageBox.Show("Phòng chọn hiện đang trống, không thể gọi dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbDichVu.SelectedValue == null) return;

            int maDV = Convert.ToInt32(cbDichVu.SelectedValue);
            int soLuong = (int)nudSoLuongDV.Value;

            if (hotelBUS.GoiDichVu(maPhieu, maDV, soLuong))
            {
                MessageBox.Show("Đặt dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadChiTietPhongActive();
            }
        }
        private decimal TinhTongTienThoiDiemHienTai(int maPhieu)
        {
            DateTime ngayNhan;
            decimal giaTheoGio, tongDV;

            hotelBUS.GetThongTinThanhToan(maPhieu, out ngayNhan, out giaTheoGio, out tongDV);
            TimeSpan thoiGianO = DateTime.Now - ngayNhan;
            int soGio = (int)Math.Ceiling(thoiGianO.TotalHours);
            if (soGio < 1) soGio = 1;

            decimal tienPhong = soGio * giaTheoGio;
            decimal tongTien = tienPhong + tongDV;

            lblTongTien.Text = $"Thời gian: {soGio} giờ | Tiền phòng: {tienPhong:N0}đ | Tiền DV: {tongDV:N0}đ\nTỔNG CỘNG: {tongTien:N0} VNĐ";
            lblTongTien.Tag = tongTien;

            return tongTien;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng cần Check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu = hotelBUS.GetActivePhieuBySoPhong(selectedSoPhong);
            if (maPhieu == -1)
            {
                MessageBox.Show("Phòng này không có phiếu lưu trú chưa thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal tongTien = TinhTongTienThoiDiemHienTai(maPhieu);

            if (MessageBox.Show($"Xác nhận thanh toán và Check-out cho Phòng {selectedSoPhong}?\nTổng số tiền: {tongTien:N0} VNĐ",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (hotelBUS.CheckOut(maPhieu, selectedSoPhong, tongTien))
                {
                    MessageBox.Show("Thanh toán thành công! Trạng thái phòng chuyển sang 'Đang dọn dẹp'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhongData();
                    LoadChiTietPhongActive();
                }
                else
                {
                    MessageBox.Show("Check-out thất bại! Đã xảy ra lỗi giao dịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnHoanTatDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng vừa dọn xong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (hotelBUS.CapNhatTrangThaiPhong(selectedSoPhong, "Trống"))
            {
                MessageBox.Show($"Phòng {selectedSoPhong} đã dọn dẹp xong và sẵn sàng đón khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhongData();
            }
        }
    }
}
