using System;
using System.Collections.Generic;
using System.Linq;
abstract class PhuongTien
{
    private string _maPT;
    private string _tenHang;
    private int _namSanXuat;
    private decimal _giaGoc;

    public string MaPT
    {
        get { return _maPT; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                _maPT = "PT000";
            else
                _maPT = value;
        }
    }

    public string TenHang
    {
        get { return _tenHang; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên hãng không được để trống!");

            _tenHang = value;
        }
    }

    public int NamSanXuat
    {
        get { return _namSanXuat; }
        set
        {
            int namHienTai = DateTime.Now.Year;

            if (value < 1900 || value > namHienTai)
                throw new ArgumentException("Năm sản xuất không hợp lệ!");

            _namSanXuat = value;
        }
    }

    public decimal GiaGoc
    {
        get { return _giaGoc; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Giá gốc phải lớn hơn 0!");

            _giaGoc = value;
        }
    }

    public PhuongTien(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc)
    {
        MaPT = maPT;
        TenHang = tenHang;
        NamSanXuat = namSanXuat;
        GiaGoc = giaGoc;
    }

    public abstract decimal TinhGiaLanBanh();

    public virtual string GetInfo()
    {
        return $"Mã: {MaPT} | Hãng: {TenHang} | " +
               $"Năm SX: {NamSanXuat} | " +
               $"Giá gốc: {GiaGoc:N0} VNĐ";
    }
}
class OTo : PhuongTien
{
    private int _soChoNgoi;
    private double _dungTichDongCo;

    public int SoChoNgoi
    {
        get { return _soChoNgoi; }
        set
        {
            if (value <= 0)
                throw new ArgumentException(
                    "Số chỗ ngồi phải lớn hơn 0!");

            _soChoNgoi = value;
        }
    }

    public double DungTichDongCo
    {
        get { return _dungTichDongCo; }
        set
        {
            if (value <= 0)
                throw new ArgumentException(
                    "Dung tích động cơ phải lớn hơn 0!");

            _dungTichDongCo = value;
        }
    }

    public OTo(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc,
        int soChoNgoi,
        double dungTichDongCo)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        SoChoNgoi = soChoNgoi;
        DungTichDongCo = dungTichDongCo;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (SoChoNgoi <= 9)
        {
            return GiaGoc
                + GiaGoc * 0.12m
                + GiaGoc * 0.30m;
        }

        return GiaGoc + GiaGoc * 0.10m;
    }

    public override string GetInfo()
    {
        return base.GetInfo()
            + $" | Số chỗ: {SoChoNgoi}"
            + $" | Động cơ: {DungTichDongCo} L";
    }
}
class XeMay : PhuongTien
{
    private int _dungTichXylanh;

    public int DungTichXylanh
    {
        get { return _dungTichXylanh; }
        set
        {
            if (value <= 0)
                throw new ArgumentException(
                    "Dung tích xylanh phải lớn hơn 0!");

            _dungTichXylanh = value;
        }
    }

    public XeMay(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc,
        int dungTichXylanh)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        DungTichXylanh = dungTichXylanh;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
            return GiaGoc + GiaGoc * 0.02m;

        return GiaGoc + GiaGoc * 0.05m;
    }

    public override string GetInfo()
    {
        return base.GetInfo()
            + $" | Xylanh: {DungTichXylanh} cc";
    }
}
class QuanLyPhuongTien
{
    private List<PhuongTien> danhSach =
        new List<PhuongTien>();

    public void AddPhuongTien(PhuongTien pt)
    {
        danhSach.Add(pt);
    }

    public void DisplayAll()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sách đang trống!");
            return;
        }

        Console.WriteLine("\n===== DANH SÁCH PHƯƠNG TIỆN =====");

        foreach (PhuongTien pt in danhSach)
        {
            Console.WriteLine(pt.GetInfo());
            Console.WriteLine(
                $"Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
            Console.WriteLine("--------------------------------------");
        }
    }

    public PhuongTien FindMaxGiaLanBanh()
    {
        if (danhSach.Count == 0)
            return null;

        return danhSach
            .OrderByDescending(pt => pt.TinhGiaLanBanh())
            .First();
    }

    public List<PhuongTien> SearchByName(string keyword)
    {
        return danhSach
            .Where(pt =>
                pt.TenHang.ToLower()
                .Contains(keyword.ToLower()))
            .ToList();
    }
}
class Program
{
    static QuanLyPhuongTien ql =
        new QuanLyPhuongTien();

    static void Main(string[] args)
    {
        Console.OutputEncoding =
            System.Text.Encoding.UTF8;

        int chon;

        do
        {
            Console.WriteLine("\n========== AUTO SPEED ==========");
            Console.WriteLine("1. Thêm ô tô");
            Console.WriteLine("2. Thêm xe máy");
            Console.WriteLine("3. Hiển thị tất cả");
            Console.WriteLine("4. Tìm phương tiện giá lăn bánh cao nhất");
            Console.WriteLine("5. Tìm phương tiện theo hãng");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("================================");

            Console.Write("Nhập lựa chọn: ");
            chon = int.Parse(Console.ReadLine());

            try
            {
                switch (chon)
                {
                    case 1:
                        ThemOTo();
                        break;

                    case 2:
                        ThemXeMay();
                        break;

                    case 3:
                        ql.DisplayAll();
                        break;

                    case 4:
                        TimGiaCaoNhat();
                        break;

                    case 5:
                        TimTheoHang();
                        break;

                    case 0:
                        Console.WriteLine("Đã thoát chương trình!");
                        break;

                    default:
                        Console.WriteLine(
                            "Lựa chọn không hợp lệ!");
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(
                    $"Lỗi: {ex.Message}");
            }

        } while (chon != 0);
    }
    static void ThemOTo()
    {
        Console.WriteLine("\n===== THÊM Ô TÔ =====");

        Console.Write("Mã phương tiện: ");
        string ma = Console.ReadLine();

        Console.Write("Tên hãng: ");
        string hang = Console.ReadLine();

        Console.Write("Năm sản xuất: ");
        int nam = int.Parse(Console.ReadLine());

        Console.Write("Giá gốc: ");
        decimal gia = decimal.Parse(Console.ReadLine());

        Console.Write("Số chỗ ngồi: ");
        int soCho = int.Parse(Console.ReadLine());

        Console.Write("Dung tích động cơ (L): ");
        double dungTich =
            double.Parse(Console.ReadLine());

        OTo oto = new OTo(
            ma,
            hang,
            nam,
            gia,
            soCho,
            dungTich
        );

        ql.AddPhuongTien(oto);

        Console.WriteLine(
            "Thêm ô tô thành công!");
    }
    static void ThemXeMay()
    {
        Console.WriteLine("\n===== THÊM XE MÁY =====");

        Console.Write("Mã phương tiện: ");
        string ma = Console.ReadLine();

        Console.Write("Tên hãng: ");
        string hang = Console.ReadLine();

        Console.Write("Năm sản xuất: ");
        int nam = int.Parse(Console.ReadLine());

        Console.Write("Giá gốc: ");
        decimal gia = decimal.Parse(Console.ReadLine());

        Console.Write("Dung tích xylanh (cc): ");
        int xylanh =
            int.Parse(Console.ReadLine());

        XeMay xeMay = new XeMay(
            ma,
            hang,
            nam,
            gia,
            xylanh
        );

        ql.AddPhuongTien(xeMay);

        Console.WriteLine(
            "Thêm xe máy thành công!");
    }
    static void TimGiaCaoNhat()
    {
        PhuongTien pt =
            ql.FindMaxGiaLanBanh();

        if (pt == null)
        {
            Console.WriteLine(
                "Danh sách phương tiện đang trống!");
            return;
        }

        Console.WriteLine(
            "\n===== PHƯƠNG TIỆN GIÁ CAO NHẤT =====");

        Console.WriteLine(pt.GetInfo());

        Console.WriteLine(
            $"Giá lăn bánh: " +
            $"{pt.TinhGiaLanBanh():N0} VNĐ");
    }
    static void TimTheoHang()
    {
        Console.Write("\nNhập tên hãng cần tìm: ");
        string keyword = Console.ReadLine();

        List<PhuongTien> ketQua =
            ql.SearchByName(keyword);

        if (ketQua.Count == 0)
        {
            Console.WriteLine(
                "Không tìm thấy phương tiện!");
            return;
        }

        Console.WriteLine(
            "\n===== KẾT QUẢ TÌM KIẾM =====");

        foreach (PhuongTien pt in ketQua)
        {
            Console.WriteLine(pt.GetInfo());

            Console.WriteLine(
                $"Giá lăn bánh: " +
                $"{pt.TinhGiaLanBanh():N0} VNĐ");

            Console.WriteLine("--------------------------------");
        }
    }
}