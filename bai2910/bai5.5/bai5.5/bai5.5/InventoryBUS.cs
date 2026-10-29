using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bai5._5
{
    public class InventoryBUS
    {
        public DataTable GetAllVatTu()
        {
            return DatabaseHelper.ExecuteQuery("SELECT MaVatTu, TenVatTu, DVT, SoLuongTon FROM VatTu");
        }
        public DataTable TimKiemVatTu(string keyword)
        {
            string query = "SELECT MaVatTu, TenVatTu, DVT, SoLuongTon FROM VatTu WHERE MaVatTu LIKE @KW OR TenVatTu LIKE @KW";
            MySqlParameter[] p = { new MySqlParameter("@KW", $"%{keyword}%") };
            return DatabaseHelper.ExecuteQuery(query, p);
        }

        public bool ThemVatTu(VatTuDTO vt)
        {
            string query = "INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES (@Ma, @Ten, @DVT, @Ton)";
            MySqlParameter[] p = {
                new MySqlParameter("@Ma", vt.MaVatTu),
                new MySqlParameter("@Ten", vt.TenVatTu),
                new MySqlParameter("@DVT", vt.DVT),
                new MySqlParameter("@Ton", vt.SoLuongTon)
            };
            return DatabaseHelper.ExecuteNonQuery(query, p) > 0;
        }
        public DataTable GetAllNhaCungCap()
        {
            return DatabaseHelper.ExecuteQuery("SELECT MaNCC, TenNCC, DienThoai, DiaChi FROM NhaCungCap");
        }
        public bool LapPhieuKho(PhieuKhoDTO phieu, List<ChiTietPhieuKhoDTO> listChiTiet, out string errorMessage)
        {
            errorMessage = "";
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string sqlPhieu = @"INSERT INTO PhieuKho (LoaiPhieu, NgayLap, MaNCC, TongTien) 
                                       VALUES (@LoaiPhieu, NOW(), @MaNCC, @TongTien);
                                       SELECT LAST_INSERT_ID();";
                    MySqlCommand cmdPhieu = new MySqlCommand(sqlPhieu, conn, trans);
                    cmdPhieu.Parameters.AddWithValue("@LoaiPhieu", phieu.LoaiPhieu);
                    cmdPhieu.Parameters.AddWithValue("@MaNCC", (object)phieu.MaNCC ?? DBNull.Value);
                    cmdPhieu.Parameters.AddWithValue("@TongTien", phieu.TongTien);

                    int maPhieuMoi = Convert.ToInt32(cmdPhieu.ExecuteScalar());
                    foreach (var item in listChiTiet)
                    {
                        string sqlCT = "INSERT INTO ChiTietPhieuKho (MaPhieu, MaVatTu, SoLuong, DonGia) VALUES (@MaPhieu, @MaVatTu, @SoLuong, @DonGia)";
                        MySqlCommand cmdCT = new MySqlCommand(sqlCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieuMoi);
                        cmdCT.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                        cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", item.DonGia);
                        cmdCT.ExecuteNonQuery();
                        if (phieu.LoaiPhieu == "XUAT")
                        {
                            string sqlCheck = "SELECT SoLuongTon FROM VatTu WHERE MaVatTu = @MaVatTu";
                            MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn, trans);
                            cmdCheck.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                            decimal tonHienTai = Convert.ToDecimal(cmdCheck.ExecuteScalar());

                            if (tonHienTai < item.SoLuong)
                            {
                                errorMessage = $"Vật tư '{item.TenVatTu}' (Mã: {item.MaVatTu}) chỉ còn tồn {tonHienTai} {item.DVT}, không đủ xuất {item.SoLuong}!";
                                return false;
                            }
                            string sqlSub = "UPDATE VatTu SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaVatTu = @MaVatTu";
                            MySqlCommand cmdSub = new MySqlCommand(sqlSub, conn, trans);
                            cmdSub.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmdSub.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                            cmdSub.ExecuteNonQuery();
                        }
                        else if (phieu.LoaiPhieu == "NHAP")
                        {
                            string sqlAdd = "UPDATE VatTu SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaVatTu = @MaVatTu";
                            MySqlCommand cmdAdd = new MySqlCommand(sqlAdd, conn, trans);
                            cmdAdd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmdAdd.Parameters.AddWithValue("@MaVatTu", item.MaVatTu);
                            cmdAdd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = "Lỗi hệ thống: " + ex.Message;
                    return false;
                }
            }
        }
        public DataTable GetVatTuCanhBaoTonKho(decimal nguongAnToan = 10)
        {
            string query = "SELECT MaVatTu, TenVatTu, DVT, SoLuongTon FROM VatTu WHERE SoLuongTon <= @Nguong";
            MySqlParameter[] p = { new MySqlParameter("@Nguong", nguongAnToan) };
            return DatabaseHelper.ExecuteQuery(query, p);
        }
        public decimal GetTongGiaTriTonKho()
        {
            string query = @"SELECT IFNULL(SUM(v.SoLuongTon * IFNULL(ct.DonGia, 0)), 0)
                            FROM VatTu v
                            LEFT JOIN (
                                SELECT MaVatTu, MAX(DonGia) AS DonGia 
                                FROM ChiTietPhieuKho 
                                GROUP BY MaVatTu
                            ) ct ON v.MaVatTu = ct.MaVatTu";
            object result = DatabaseHelper.ExecuteScalar(query);
            return Convert.ToDecimal(result);
        }
    }
}
