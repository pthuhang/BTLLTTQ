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
                "SELECT nv.MaNV, kl.MaKiLuat, kl.NoiDung, nv.NgayKiLuat, nv.TienPhat " +
                "FROM KiLuat_NhanVien nv " +
                "JOIN KiLuat kl ON nv.MaKiLuat = kl.MaKiLuat", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool ThemKLNV(string maKL, string maNV, DateTime ngayKL, decimal tienPhat)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO KiLuat_NhanVien(MaKiLuat, MaNV, NgayKiLuat, TienPhat) VALUES(@MaKiLuat, @MaNV, @NgayKiLuat, @TienPhat)", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKiLuat", maKL);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@NgayKiLuat", ngayKL);
                    cmd.Parameters.AddWithValue("@TienPhat", tienPhat);

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

        public bool SuaChiTiet(string maKL, string maNV, DateTime ngayMoi, decimal tienMoi)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE KiLuat_NhanVien SET NgayKiLuat=@NgayMoi, TienPhat=@TienMoi " +
                    "WHERE MaKiLuat=@MaKiLuat AND MaNV=@MaNV", conn))
                {
                    cmd.Parameters.AddWithValue("@NgayMoi", ngayMoi);
                    cmd.Parameters.AddWithValue("@TienMoi", tienMoi);
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
