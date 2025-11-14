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
    public class KiLuat_NhanVienDAL : DBConnection
    {
        public DataTable LayDanhSach()
        {
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT nv.MaNV, kl.MaKiLuat, kl.NoiDung, nv.NgayKiLuat, kl.TienPhat " +
                "FROM KiLuat_NhanVien nv " +
                "JOIN KiLuat kl ON nv.MaKiLuat = kl.MaKiLuat", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable LayKiLuatTheoNV(string maNV)
        {
            string sql = "SELECT * FROM KiLuat_NhanVien WHERE MaNV = @MaNV";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNV", maNV);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetKiLuatByMaNV_ThangNam(string maNV, int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = @"
            SELECT kl.MaKiLuat, kl.NoiDung, kl.TienPhat, klnv.NgayKiLuat
            FROM KiLuat kl
            INNER JOIN KiLuat_NhanVien klnv ON kl.MaKiLuat = klnv.MaKiLuat
            WHERE klnv.MaNV = @MaNV 
              AND MONTH(klnv.NgayKiLuat) = @Thang
              AND YEAR(klnv.NgayKiLuat) = @Nam";

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
                MessageBox.Show("Lỗi lấy Li luat theo tháng/năm: " + ex.Message);
            }
            return dt;
        }
        public bool ThemKLNV(string maKL, string maNV, DateTime ngayKL)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO KiLuat_NhanVien(MaKiLuat, MaNV, NgayKiLuat) VALUES(@MaKiLuat, @MaNV, @NgayKiLuat)", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKiLuat", maKL);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@NgayKiLuat", ngayKL);
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

        public void Xoa(string maKL, string maNV)
        {
            string sql = "DELETE FROM KiLuat_NhanVien WHERE MaKiLuat = @MaKiLuat AND MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKiLuat", maKL);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool SuaChiTiet(string maKL, string maNV, DateTime ngayMoi)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE KiLuat_NhanVien SET NgayKiLuat=@NgayMoi " +
                    "WHERE MaKiLuat=@MaKiLuat AND MaNV=@MaNV", conn))
                {
                    cmd.Parameters.AddWithValue("@NgayMoi", ngayMoi);
                    cmd.Parameters.AddWithValue("@MaKiLuat", maKL);
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
        public bool TonTaiKiLuatNhanVien(string maKL, string maNV)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KiLuat_NhanVien WHERE MaKiLuat = @MaKL AND MaNV = @MaNV", conn))
            {
                cmd.Parameters.AddWithValue("@MaKL", maKL);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

    }
}
