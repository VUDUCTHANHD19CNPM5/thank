using System;
using System.Collections.Generic;
using System.Text;

namespace bai5._5
{
    public class NhaCungCapDTO
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
    }

    public class VatTuDTO
    {
        public string MaVatTu { get; set; }
        public string TenVatTu { get; set; }
        public string DVT { get; set; }
        public decimal SoLuongTon { get; set; }
    }

    public class PhieuKhoDTO
    {
        public int MaPhieu { get; set; }
        public string LoaiPhieu { get; set; }
        public DateTime NgayLap { get; set; }
        public int? MaNCC { get; set; }
        public decimal TongTien { get; set; }
    }

    public class ChiTietPhieuKhoDTO
    {
        public int MaPhieu { get; set; }
        public string MaVatTu { get; set; }
        public string TenVatTu { get; set; }
        public string DVT { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }
}
