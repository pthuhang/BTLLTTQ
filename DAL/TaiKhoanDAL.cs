using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    //public class TaiKhoanDAL : DBConnection
    //{
    //    //public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
    //    //{
    //    //    string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @user AND MatKhau = @pass";

    //    //    SqlCommand cmd = new SqlCommand(sql, conn);
    //    //    cmd.Parameters.AddWithValue("@user", tenDangNhap);
    //    //    cmd.Parameters.AddWithValue("@pass", matKhau);

    //    //    conn.Open();
    //    //    int count = (int)cmd.ExecuteScalar();
    //    //    conn.Close();

    //    //    return count > 0;
    //    //}
    //}
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
        public void Them(string maNguoiDung, string tenDangNhap, string matKhau, string maNV, string vaiTro)
        {
            string sql = "INSERT INTO TaiKhoan VALUES(@MaNguoiDung, @TenDangNhap, @MatKhau, @MaNV, @VaiTro)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", matKhau);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Sua(string maNguoiDung, string tenDangNhap, string matKhau, string maNV, string vaiTro)
        {
            string sql = @"UPDATE TaiKhoan 
                           SET TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, MaNV=@MaNV, VaiTro=@VaiTro
                           WHERE MaNguoiDung=@MaNguoiDung";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", matKhau);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Xoa(string maNguoiDung)
        {
            string sql = "DELETE FROM TaiKhoan WHERE MaNguoiDung=@MaNguoiDung";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Kiểm tra đăng nhập

        public DataRow KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@TenDangNhap AND MatKhau=@MatKhau";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", matKhau);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }
    }
}
