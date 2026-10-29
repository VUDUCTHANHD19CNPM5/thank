using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace bai5._4
{
    public class HotelBUS
    {
        public DataTable GetAllPhong()
        {
            string query = "SELECT SoPhong, LoaiPhong, GiaTheoGio, TrangThai FROM Phong";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public bool CapNhatTrangThaiPhong(string soPhong, string trangThaiMoi)
        {
            string query = "UPDATE Phong SET TrangThai = @TrangThai WHERE SoPhong = @SoPhong";
            MySqlParameter[] p = {
                new MySqlParameter("@TrangThai", trangThaiMoi),
                new MySqlParameter("@SoPhong", soPhong)
            };
            return DatabaseHelper.ExecuteNonQuery(query, p) > 0;
        }
        public KhachHangDTO GetKhachHangByCCCD(string cccd)
        {
            string query = "SELECT MaKH, HoTen, CCCD, SoDienThoai FROM KhachHang WHERE CCCD = @CCCD";
            MySqlParameter[] p = { new MySqlParameter("@CCCD", cccd) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new KhachHangDTO
                {
                    MaKH = Convert.ToInt32(r["MaKH"]),
                    HoTen = r["HoTen"].ToString(),
                    CCCD = r["CCCD"].ToString(),
                    SoDienThoai = r["SoDienThoai"].ToString()
                };
            }
            return null;
        }

        public int ThemKhachHang(KhachHangDTO kh)
        {
            string query = @"INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) VALUES (@HoTen, @CCCD, @SDT);
                            SELECT LAST_INSERT_ID();";
            MySqlParameter[] p = {
                new MySqlParameter("@HoTen", kh.HoTen),
                new MySqlParameter("@CCCD", kh.CCCD),
                new MySqlParameter("@SDT", kh.SoDienThoai)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, p));
        }
        public bool CheckIn(string soPhong, int maKH)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlPhieu = "INSERT INTO PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong) VALUES (@SoPhong, @MaKH, NOW())";
                    MySqlCommand cmdPhieu = new MySqlCommand(sqlPhieu, conn, trans);
                    cmdPhieu.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhieu.Parameters.AddWithValue("@MaKH", maKH);
                    cmdPhieu.ExecuteNonQuery();
                    string sqlPhong = "UPDATE Phong SET TrangThai = 'Đang ở' WHERE SoPhong = @SoPhong";
                    MySqlCommand cmdPhong = new MySqlCommand(sqlPhong, conn, trans);
                    cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhong.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
        public int GetActivePhieuBySoPhong(string soPhong)
        {
            string query = "SELECT MaPhieu FROM PhieuDatPhong WHERE SoPhong = @SoPhong AND NgayTraPhong IS NULL";
            MySqlParameter[] p = { new MySqlParameter("@SoPhong", soPhong) };
            object result = DatabaseHelper.ExecuteScalar(query, p);
            return result != null ? Convert.ToInt32(result) : -1;
        }
        public DataTable GetAllDichVu()
        {
            return DatabaseHelper.ExecuteQuery("SELECT MaDV, TenDV, DonGia FROM DichVu");
        }

        public bool GoiDichVu(int maPhieu, int maDV, int soLuong)
        {
            string query = "INSERT INTO SuDungDichVu (MaPhieu, MaDV, SoLuong, ThoiGian) VALUES (@MaPhieu, @MaDV, @SoLuong, NOW())";
            MySqlParameter[] p = {
                new MySqlParameter("@MaPhieu", maPhieu),
                new MySqlParameter("@MaDV", maDV),
                new MySqlParameter("@SoLuong", soLuong)
            };
            return DatabaseHelper.ExecuteNonQuery(query, p) > 0;
        }

        public DataTable GetDichVuDaSuDung(int maPhieu)
        {
            string query = @"SELECT dv.TenDV, sd.SoLuong, dv.DonGia, (sd.SoLuong * dv.DonGia) AS ThanhTien, sd.ThoiGian
                            FROM SuDungDichVu sd
                            JOIN DichVu dv ON sd.MaDV = dv.MaDV
                            WHERE sd.MaPhieu = @MaPhieu";
            MySqlParameter[] p = { new MySqlParameter("@MaPhieu", maPhieu) };
            return DatabaseHelper.ExecuteQuery(query, p);
        }
        public void GetThongTinThanhToan(int maPhieu, out DateTime ngayNhan, out decimal giaTheoGio, out decimal tongTienDV)
        {
            ngayNhan = DateTime.Now;
            giaTheoGio = 0;
            tongTienDV = 0;

            string sqlPhieu = @"SELECT p.NgayNhanPhong, ph.GiaTheoGio 
                               FROM PhieuDatPhong p 
                               JOIN Phong ph ON p.SoPhong = ph.SoPhong 
                               WHERE p.MaPhieu = @MaPhieu";
            MySqlParameter[] p1 = { new MySqlParameter("@MaPhieu", maPhieu) };
            DataTable dtPhieu = DatabaseHelper.ExecuteQuery(sqlPhieu, p1);

            if (dtPhieu.Rows.Count > 0)
            {
                ngayNhan = Convert.ToDateTime(dtPhieu.Rows[0]["NgayNhanPhong"]);
                giaTheoGio = Convert.ToDecimal(dtPhieu.Rows[0]["GiaTheoGio"]);
            }

            string sqlDV = "SELECT SUM(sd.SoLuong * dv.DonGia) FROM SuDungDichVu sd JOIN DichVu dv ON sd.MaDV = dv.MaDV WHERE sd.MaPhieu = @MaPhieu";
            object resDV = DatabaseHelper.ExecuteScalar(sqlDV, p1);
            if (resDV != DBNull.Value && resDV != null)
            {
                tongTienDV = Convert.ToDecimal(resDV);
            }
        }

        public bool CheckOut(int maPhieu, string soPhong, decimal tongTien)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlPhieu = "UPDATE PhieuDatPhong SET NgayTraPhong = NOW(), TongTienThanhToan = @TongTien WHERE MaPhieu = @MaPhieu";
                    MySqlCommand cmdPhieu = new MySqlCommand(sqlPhieu, conn, trans);
                    cmdPhieu.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdPhieu.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmdPhieu.ExecuteNonQuery();
                    string sqlPhong = "UPDATE Phong SET TrangThai = 'Đang dọn dẹp' WHERE SoPhong = @SoPhong";
                    MySqlCommand cmdPhong = new MySqlCommand(sqlPhong, conn, trans);
                    cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhong.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}
