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
                "SELECT nv.MaNV, kt.MaKhenThuong, kt.NoiDung, nv.NgayKhenThuong, nv.TienKhenThuong " +
                "FROM Khen_NhanVien nv " +
                "JOIN KhenThuong kt ON nv.MaKhenThuong = kt.MaKhenThuong", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool ThemKLNV(string maKT, string maNV, DateTime ngayKT, decimal tienKhenThuong)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Khen_NhanVien(MaKhenThuong, MaNV, NgayKhenThuong, TienKhenThuong) VALUES(@MaKhenThuong, @MaNV, @NgayKhenThuong, @TienKhenThuong)", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhenThuong", maKT);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@NgayKhenThuong", ngayKT);
                    cmd.Parameters.AddWithValue("@TienKhenThuong", tienKhenThuong);

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

        public bool SuaChiTiet(string maKT, string maNV, DateTime ngayMoi, decimal tienMoi)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Khen_NhanVien SET NgayKhenThuong=@NgayMoi, TienKhenThuong=@TienMoi " +
                    "WHERE MaKhenThuong=@MaKhenThuong AND MaNV=@MaNV", conn))
                {
                    cmd.Parameters.AddWithValue("@NgayMoi", ngayMoi);
                    cmd.Parameters.AddWithValue("@TienMoi", tienMoi);
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
