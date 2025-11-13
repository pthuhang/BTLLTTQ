using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class TaiKhoanDAL : DBConnection
    {
        public DataTable LayDanhSachTaiKhoan()
        {
            string sql = "SELECT * FROM TaiKhoan";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LayTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            string sql = @"select * from TaiKhoan Where TenDangNhap=@tenDangNhap";
            using(SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
        //Thêm, sửa, xóa
        public void Them(string maNguoiDung, string tenDangNhap, string matKhau, string maNV, string vaiTro)
        {
            string sql = "INSERT INTO TaiKhoan VALUES(@MaNguoiDung, @TenDangNhap, @MatKhau, @MaNV, @VaiTro)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void Sua(string maNguoiDung, string tenDangNhap, string matKhau, string maNV, string vaiTro)
        {
            string sql = @"UPDATE TaiKhoan 
                           SET TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, MaNV=@MaNV, VaiTro=@VaiTro
                           WHERE MaNguoiDung=@MaNguoiDung";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void Xoa(string maNguoiDung)
        {
            string sql = "DELETE FROM TaiKhoan WHERE MaNguoiDung=@MaNguoiDung";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        //Kiểm tra 
        public DataRow KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@TenDangNhap AND MatKhau=@MatKhau";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) return dt.Rows[0];
                return null;
            }
        }
        public bool UpdateOne(string maNguoiDung, string maNhanVien, string tenDangNhap, string matKhau, string vaiTro)
        {
            
                string query = @"UPDATE TaiKhoan 
                             SET MaNV=@MaNV, TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, VaiTro=@VaiTro
                             WHERE MaNguoiDung=@MaNguoiDung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                cmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            
        }
        public bool CapNhatTaiKhoan(string tenDangNhap, string matKhau, string vaiTro)
        {
            string sql = @"UPDATE TaiKhoan 
                   SET MatKhau = @MatKhau, VaiTro = @VaiTro
                   WHERE TenDangNhap = @TenDangNhap";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                return rows > 0;
            }
        }

    }
}
