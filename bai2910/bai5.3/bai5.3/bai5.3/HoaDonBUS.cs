using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bai5._3
{
    public class HoaDonBUS // BẮT BUỘC PHẢI CÓ public
    {
        public int GetUnpaidHoaDonIdByBan(int maBan)
        {
            string query = "SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0";
            MySqlParameter[] p = { new MySqlParameter("@MaBan", maBan) };
            object result = DatabaseHelper.ExecuteScalar(query, p);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public DataTable GetChiTietHoaDon(int maHoaDon)
        {
            string query = @"SELECT m.TenMon, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien, c.MaMon 
                            FROM ChiTietHoaDon c 
                            JOIN MonAn m ON c.MaMon = m.MaMon 
                            WHERE c.MaHoaDon = @MaHoaDon";
            MySqlParameter[] p = { new MySqlParameter("@MaHoaDon", maHoaDon) };
            return DatabaseHelper.ExecuteQuery(query, p);
        }

        public void GoiMon(int maBan, int maMon, int soLuong, decimal donGia)
        {
            int maHoaDon = GetUnpaidHoaDonIdByBan(maBan);

            if (maHoaDon == -1)
            {
                string sqlInsertHD = "INSERT INTO HoaDon (MaBan, GioVao, TrangThai) VALUES (@MaBan, NOW(), 0); SELECT LAST_INSERT_ID();";
                MySqlParameter[] p1 = { new MySqlParameter("@MaBan", maBan) };
                maHoaDon = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlInsertHD, p1));

                DatabaseHelper.ExecuteNonQuery("UPDATE BanAn SET TrangThai = 'Có khách' WHERE MaBan = " + maBan);
            }

            string sqlCheckCT = "SELECT SoLuong FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon";
            MySqlParameter[] pCheck = { new MySqlParameter("@MaHoaDon", maHoaDon), new MySqlParameter("@MaMon", maMon) };
            object exQuantity = DatabaseHelper.ExecuteScalar(sqlCheckCT, pCheck);

            if (exQuantity != null)
            {
                int newQty = Convert.ToInt32(exQuantity) + soLuong;
                if (newQty > 0)
                {
                    string sqlUpdate = "UPDATE ChiTietHoaDon SET SoLuong = @SoLuong WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon";
                    MySqlParameter[] pUp = {
                        new MySqlParameter("@SoLuong", newQty),
                        new MySqlParameter("@MaHoaDon", maHoaDon),
                        new MySqlParameter("@MaMon", maMon)
                    };
                    DatabaseHelper.ExecuteNonQuery(sqlUpdate, pUp);
                }
                else
                {
                    string sqlDel = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon";
                    DatabaseHelper.ExecuteNonQuery(sqlDel, pCheck);
                }
            }
            else if (soLuong > 0)
            {
                string sqlInsert = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia) VALUES (@MaHoaDon, @MaMon, @SoLuong, @DonGia)";
                MySqlParameter[] pIns = {
                    new MySqlParameter("@MaHoaDon", maHoaDon),
                    new MySqlParameter("@MaMon", maMon),
                    new MySqlParameter("@SoLuong", soLuong),
                    new MySqlParameter("@DonGia", donGia)
                };
                DatabaseHelper.ExecuteNonQuery(sqlInsert, pIns);
            }
        }

        public bool ThanhToan(int maHoaDon, int maBan, decimal tongTien)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryHD = "UPDATE HoaDon SET GioRa = NOW(), TongTien = @TongTien, TrangThai = 1 WHERE MaHoaDon = @MaHoaDon";
                    MySqlCommand cmdHD = new MySqlCommand(queryHD, conn, transaction);
                    cmdHD.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdHD.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdHD.ExecuteNonQuery();

                    string queryBan = "UPDATE BanAn SET TrangThai = 'Trống' WHERE MaBan = @MaBan";
                    MySqlCommand cmdBan = new MySqlCommand(queryBan, conn, transaction);
                    cmdBan.Parameters.AddWithValue("@MaBan", maBan);
                    cmdBan.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
