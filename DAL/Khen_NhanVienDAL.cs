using QUANLYNHANSU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.DAL
{
    public class KhenThuong_NhanVienDAL : DBConnection
    {
        public DataTable LayDanhSach()
        {
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT nv.MaNV, kt.MaKhenThuong, kt.NoiDung, nv.NgayKhenThuong, kt.TienKhenThuong " +
                "FROM Khen_NhanVien nv " +
                "JOIN KhenThuong kt ON nv.MaKhenThuong = kt.MaKhenThuong", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable GetKhenThuongByMaNV_ThangNam(string maNV, int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"
            SELECT kt.MaKhenThuong, kt.NoiDung, kt.TienKhenThuong, knv.NgayKhenThuong
            FROM KhenThuong kt
            INNER JOIN Khen_NhanVien knv ON kt.MaKhenThuong = knv.MaKhenThuong
            WHERE knv.MaNV = @MaNV 
              AND MONTH(knv.NgayKhenThuong) = @Thang
              AND YEAR(knv.NgayKhenThuong) = @Nam";

                // Mở kết nối trước khi dùng SqlCommand
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
                    cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Lỗi lấy khen thưởng theo tháng/năm: " + ex.Message);
            }
            return dt;
        }



        public bool ThemKLNV(string maKT, string maNV, DateTime ngayKT)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Khen_NhanVien(MaKhenThuong, MaNV, NgayKhenThuong) VALUES(@MaKhenThuong, @MaNV, @NgayKhenThuong)", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhenThuong", maKT);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@NgayKhenThuong", ngayKT);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Close();
                MessageBox.Show("Lỗi thêm chi tiết: " + ex.Message);
                return false;
            }
        }

        public void Xoa(string maKT, string maNV)
        {
            string sql = "DELETE FROM Khen_NhanVien WHERE MaKhenThuong = @MaKhenThuong AND MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKhenThuong", maKT);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool SuaChiTiet(string maKT, string maNV, DateTime ngayMoi)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Khen_NhanVien SET NgayKhenThuong=@NgayMoi " +
                    "WHERE MaKhenThuong=@MaKhenThuong AND MaNV=@MaNV", conn))
                {
                    cmd.Parameters.AddWithValue("@NgayMoi", ngayMoi);
                    cmd.Parameters.AddWithValue("@MaKhenThuong", maKT);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Lỗi cập nhật chi tiết: " + ex.Message);
                return false;
            }
        }
        public bool TonTaiKhenNhanVien(string maKT, string maNV)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Khen_NhanVien WHERE MaKhenThuong = @MaKT AND MaNV = @MaNV", conn))
            {
                cmd.Parameters.AddWithValue("@MaKT", maKT);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

    }
}
