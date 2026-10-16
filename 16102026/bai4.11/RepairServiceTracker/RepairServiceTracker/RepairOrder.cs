using System;

namespace RepairServiceTracker
{
    public class RepairOrder
    {
        public string MaDon { get; set; } = "";
        public string TenKhachHang { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        public string LoaiThietBi { get; set; } = "";
        public string MoTaLoi { get; set; } = "";
        public DateTime NgayTiepNhan { get; set; } = DateTime.Today;
        public decimal ChiPhiDuKien { get; set; }
        public string TrangThai { get; set; } = "Mới tiếp nhận";
        public string DuongDanAnh { get; set; } = "";
    }
}
