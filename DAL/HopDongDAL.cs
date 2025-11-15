using QUANLYNHANSU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class HopDongDAL : DBConnection
    {
        public DataTable LayDanhSachHopDong()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM HopDong";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                con.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.Fill(dt);
                }
                con.Close();
            }

            return dt;
        }
        public DataTable LayHopDongTheoTenDangNhap(string tenDangNhap)
        {
            string sql = @"
                SELECT hd.*, tk.TenDangNhap
                FROM TaiKhoan tk
                INNER JOIN NhanVien nv ON nv.MaNV = tk.MaNV
                INNER JOIN HopDong hd on hd.MaNV= nv.MaNV
                WHERE tk.TenDangNhap = @TenDangNhap";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
        //
        public bool KiemTraHopDongTonTai(string maNV, DateTime ngayBatDau, DateTime ngayKetThuc, string maHDHienTai = null)
        {
            string sql = @"
                SELECT COUNT(*) 
                FROM HopDong 
                WHERE MaNV = @MaNV
                  AND ((NgayBatDau <= @KetThuc AND NgayKetThuc >= @BatDau))";

            if (!string.IsNullOrEmpty(maHDHienTai))
            {
                sql += " AND MaHopDong <> @MaHD";
            }

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV;
                cmd.Parameters.Add("@BatDau", SqlDbType.Date).Value = ngayBatDau;
                cmd.Parameters.Add("@KetThuc", SqlDbType.Date).Value = ngayKetThuc;

                if (!string.IsNullOrEmpty(maHDHienTai))
                {
                    cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 10).Value = maHDHienTai;
                }

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                return count > 0;
            }
        }

        public bool KiemTraNhanVienTonTai(string maNV)
        {
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV;

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                return count > 0; 
            }
        }

        //----
        public string TaoMaHopDong(string maNV, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            string maNVPart = maNV.Length >= 4 ? maNV.Substring(maNV.Length - 4) : maNV.PadLeft(4, '0');

            string namBD = ngayBatDau.Year.ToString().Substring(2, 2);
            string namKT = ngayKetThuc.Year.ToString().Substring(2, 2);

            string maHD = $"HD{maNVPart}{namBD}{namKT}";

            return maHD;
        }


        //-----Thêm, sửa, xóa----
        public void Them(string ma, string thoiHan, DateTime batDau, DateTime ketThuc, string noiDung, string lanKi, float heSoLuong, decimal luongCB, string maNV)
        {
            string sql = @"INSERT INTO HopDong 
                           VALUES (@Ma, @ThoiHan, @BatDau, @KetThuc, @NoiDung, @LanKi,  @HeSoLuong, @MaNV, @LuongCB )";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@Ma", SqlDbType.VarChar, 10).Value = ma;

                if (string.IsNullOrEmpty(thoiHan))
                    cmd.Parameters.Add("@ThoiHan", SqlDbType.NVarChar, 50).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@ThoiHan", SqlDbType.NVarChar, 50).Value = thoiHan;

                cmd.Parameters.Add("@BatDau", SqlDbType.Date).Value = batDau;
                cmd.Parameters.Add("@KetThuc", SqlDbType.Date).Value = ketThuc;

                if (string.IsNullOrEmpty(noiDung))
                    cmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 300).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 300).Value = noiDung;

                if (string.IsNullOrEmpty(lanKi))
                    cmd.Parameters.Add("@LanKi", SqlDbType.Int).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@LanKi", SqlDbType.Int).Value = int.Parse(lanKi);

                cmd.Parameters.Add("@HeSoLuong", SqlDbType.Float).Value = heSoLuong;
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV;

                var pLuongCB = cmd.Parameters.Add("@LuongCB", SqlDbType.Decimal);
                pLuongCB.Value = luongCB;
                pLuongCB.Precision = 18;
                pLuongCB.Scale = 2;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Sua(string ma, string thoiHan, DateTime batDau, DateTime ketThuc, string noiDung, string lanKi, float heSoLuong, decimal luongCB, string maNV)
        {
            string sql = @"UPDATE HopDong 
                           SET ThoiHan=@ThoiHan, NgayBatDau=@BatDau, NgayKetThuc=@KetThuc, NoiDung=@NoiDung, LanKi=@LanKi,
                               HeSoLuong=@HeSoLuong, LuongCoBan = @LuongCB, MaNV=@MaNV 
                           WHERE MaHopDong=@Ma";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                cmd.Parameters.AddWithValue("@ThoiHan", thoiHan);
                cmd.Parameters.AddWithValue("@BatDau", batDau);
                cmd.Parameters.AddWithValue("@KetThuc", ketThuc);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@LanKi", lanKi);

                cmd.Parameters.AddWithValue("@HeSoLuong", heSoLuong);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@LuongCB", luongCB);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Xoa(string maHD)
        {
            string sql = "DELETE FROM HopDong WHERE MaHopDong=@MaHD";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 10).Value = maHD;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public DataTable TimKiemHopDong(string maHopDong, string maNV)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT *
                   FROM HopDong
                   WHERE (@MaHopDong = '' OR MaHopDong = @MaHopDong)
                     AND (@MaNV = '' OR MaNV = @MaNV)";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@MaHopDong", SqlDbType.VarChar, 10).Value = maHopDong;
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable LayHopDongSapHetHan(int soNgay)
        {
            string sql = @"
                SELECT *
                FROM HopDong
                WHERE DATEDIFF(day, GETDATE(), NgayKetThuc) <= @SoNgay
                      AND DATEDIFF(day, GETDATE(), NgayKetThuc) >= 0";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@SoNgay", soNgay);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
