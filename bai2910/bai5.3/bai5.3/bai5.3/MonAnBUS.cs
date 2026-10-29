using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bai5._3
{
    public class MonAnDTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public int MaDanhMuc { get; set; }
        public decimal DonGia { get; set; }
    }

    // Lớp BUS xử lý nghiệp vụ Món Ăn
    public class MonAnBUS
    {
        // Lấy toàn bộ danh sách món ăn kèm tên danh mục
        public DataTable GetAllMonAn()
        {
            string query = @"SELECT m.MaMon, m.TenMon, d.TenDanhMuc, m.DonGia, m.MaDanhMuc 
                            FROM MonAn m 
                            JOIN DanhMuc d ON m.MaDanhMuc = d.MaDanhMuc";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // Lấy danh sách món ăn lọc theo Mã Danh Mục
        public DataTable GetMonAnByDanhMuc(int maDanhMuc)
        {
            string query = "SELECT MaMon, TenMon, DonGia FROM MonAn WHERE MaDanhMuc = @MaDanhMuc";
            MySqlParameter[] p = { new MySqlParameter("@MaDanhMuc", maDanhMuc) };
            return DatabaseHelper.ExecuteQuery(query, p);
        }

        // Thêm món ăn mới (Có kiểm tra Validation)
        public bool AddMonAn(MonAnDTO mon)
        {
            ValidateMonAn(mon);
            string query = "INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES (@TenMon, @MaDanhMuc, @DonGia)";
            MySqlParameter[] p = {
                new MySqlParameter("@TenMon", mon.TenMon),
                new MySqlParameter("@MaDanhMuc", mon.MaDanhMuc),
                new MySqlParameter("@DonGia", mon.DonGia)
            };
            return DatabaseHelper.ExecuteNonQuery(query, p) > 0;
        }

        // Cập nhật thông tin món ăn (Có kiểm tra Validation)
        public bool UpdateMonAn(MonAnDTO mon)
        {
            ValidateMonAn(mon);
            string query = "UPDATE MonAn SET TenMon = @TenMon, MaDanhMuc = @MaDanhMuc, DonGia = @DonGia WHERE MaMon = @MaMon";
            MySqlParameter[] p = {
                new MySqlParameter("@MaMon", mon.MaMon),
                new MySqlParameter("@TenMon", mon.TenMon),
                new MySqlParameter("@MaDanhMuc", mon.MaDanhMuc),
                new MySqlParameter("@DonGia", mon.DonGia)
            };
            return DatabaseHelper.ExecuteNonQuery(query, p) > 0;
        }

        // Xóa món ăn theo Mã món
        public bool DeleteMonAn(int maMon)
        {
            string query = "DELETE FROM MonAn WHERE MaMon = @MaMon";
            MySqlParameter[] p = { new MySqlParameter("@MaMon", maMon) };
            return DatabaseHelper.ExecuteNonQuery(query, p) > 0;
        }

        // Bắt lỗi ràng buộc dữ liệu đầu vào (Validation)
        private void ValidateMonAn(MonAnDTO mon)
        {
            if (string.IsNullOrWhiteSpace(mon.TenMon))
                throw new ArgumentException("Tên món ăn không được để trống!");
            if (mon.DonGia < 0)
                throw new ArgumentException("Đơn giá phải lớn hơn hoặc bằng 0!");
        }
    }
}
