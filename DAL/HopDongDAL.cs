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
            string sql = @"SELECT MaHopDong, ThoiHan, NgayBatDau, NgayKetThuc,HeSoLuong, MaNV FROM HopDong";

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

        // ✅ Kiểm tra mã nhân viên tồn tại trong bảng NhanVien
        public bool KiemTraMaNVTonTai(string maNV)
        {
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                return count > 0;
            }
        }

        // ✅ Thêm hợp đồng mới
        public void Them(string ma, string thoiHan, DateTime batDau, DateTime ketThuc, float heSoLuong, string maNV)
        {
            string sql = @"INSERT INTO HopDong (MaHopDong, ThoiHan, NgayBatDau, NgayKetThuc, HeSoLuong, MaNV)
                           VALUES (@Ma, @ThoiHan, @BatDau, @KetThuc, @HeSoLuong, @MaNV)";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                cmd.Parameters.AddWithValue("@ThoiHan", thoiHan ?? "");
                cmd.Parameters.AddWithValue("@BatDau", batDau);
                cmd.Parameters.AddWithValue("@KetThuc", ketThuc);
                cmd.Parameters.AddWithValue("@HeSoLuong", heSoLuong);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // ✅ Sửa hợp đồng
        public void Sua(string ma, string thoiHan, DateTime batDau, DateTime ketThuc, float heSoLuong, string maNV)
        {
            string sql = @"UPDATE HopDong 
                           SET ThoiHan=@ThoiHan, NgayBatDau=@BatDau, NgayKetThuc=@KetThuc, 
                               HeSoLuong=@HeSoLuong, MaNV=@MaNV 
                           WHERE MaHopDong=@Ma";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                cmd.Parameters.AddWithValue("@ThoiHan", thoiHan);
                cmd.Parameters.AddWithValue("@BatDau", batDau);
                cmd.Parameters.AddWithValue("@KetThuc", ketThuc);
                cmd.Parameters.AddWithValue("@HeSoLuong", heSoLuong);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // ✅ Xóa hợp đồng
        public void Xoa(string ma)
        {
            string sql = "DELETE FROM HopDong WHERE MaHopDong=@Ma";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Tìm kiếm hợp đồng
        public DataTable TimKiemHopDong(string maHopDong, string maNV)
        {
            string sql = @"SELECT MaHopDong, ThoiHan, NgayBatDau, NgayKetThuc, HeSoLuong, MaNV
                   FROM HopDong
                   WHERE (@MaHopDong = '' OR MaHopDong = @MaHopDong)
                   AND (@MaNV = '' OR MaNV = @MaNV)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHopDong", maHopDong);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Thông báo hợp đồng sắp hết hạn
        public DataTable LayHopDongSapHetHan(int soNgay)
        {
            string sql = @"
        SELECT MaHopDong, ThoiHan, NgayBatDau, NgayKetThuc, HeSoLuong, MaNV
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
