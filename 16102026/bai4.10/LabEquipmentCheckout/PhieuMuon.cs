namespace LabEquipmentCheckout;

public class PhieuMuon
{
    public string MaPhieu { get; set; } = "";
    public string MaSV { get; set; } = "";
    public string HoTen { get; set; } = "";
    public string ThietBi { get; set; } = "";
    public int SoLuong { get; set; }
    public DateTime NgayMuon { get; set; }
    public DateTime HanTra { get; set; }
    public DateTime? NgayTraThucTe { get; set; }

    public string TrangThai =>
        NgayTraThucTe.HasValue ? "Đã trả" :
        HanTra.Date < DateTime.Today ? "Quá hạn" : "Đang mượn";
}
