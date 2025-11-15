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
        //Tọ mã
        public string TaoMaTaiKhoan(string maNV)
        {
            if (string.IsNullOrEmpty(maNV))
                throw new ArgumentException("Mã nhân viên không được rỗng");

            string phanSo = new string(maNV.Where(char.IsDigit).ToArray());

            phanSo = phanSo.PadLeft(4, '0');

            string maTK = $"TK{phanSo}";

            return maTK;
        }
        public DataTable LayTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            string sql = @"select * from TaiKhoan Where TenDangNhap=@tenDangNhap";

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                return dt;
            }
        }

        //
        public bool KiemTraNhanVienTonTai(string maNV)
        {
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV.Trim();
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool KiemTraTonTaiTaiKhoan(string maNV)
        {
            string sql = @"SELECT COUNT(*) FROM TaiKhoan WHERE MaNV = @MaNV";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV;

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraTonTaiTenDangNhap(string tenDangNhap, string maNguoiDungHienTai = null)
        {
            string sql = @"SELECT COUNT(*) 
                   FROM TaiKhoan 
                   WHERE TenDangNhap = @TenDangNhap";

            if (!string.IsNullOrEmpty(maNguoiDungHienTai))
                sql += " AND MaNguoiDung <> @MaNguoiDung";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;

                if (!string.IsNullOrEmpty(maNguoiDungHienTai))
                    cmd.Parameters.Add("@MaNguoiDung", SqlDbType.VarChar, 10).Value = maNguoiDungHienTai;

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }



        //Thêm, sửa, xóa
        public bool Them(string maNguoiDung, string tenDangNhap, string matKhau, string maNV, string vaiTro)
        {
            string sql = "INSERT INTO TaiKhoan VALUES(@MaNguoiDung,@MaNV, @TenDangNhap, @MatKhau, @VaiTro)";
            try
            {
                using (SqlConnection con = new SqlConnection(conn.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@MaNguoiDung", SqlDbType.VarChar, 10).Value = maNguoiDung;
                    cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV;
                    cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = matKhau;
                    cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20).Value = vaiTro;

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }
        public bool Sua(string maNguoiDung, string tenDangNhap, string matKhau, string maNV, string vaiTro)
        {
            string sql = @"UPDATE TaiKhoan 
                           SET TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, MaNV=@MaNV, VaiTro=@VaiTro
                           WHERE MaNguoiDung=@MaNguoiDung";
            try
            {
                using (SqlConnection con = new SqlConnection(conn.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@MaNguoiDung", SqlDbType.VarChar, 10).Value = maNguoiDung;
                    cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = matKhau;
                    cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV;
                    cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20).Value = vaiTro;

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa tài khoản: " + ex.Message);
            }
        }
        public bool Xoa(string maNguoiDung)
        {
            string sql = "DELETE FROM TaiKhoan WHERE MaNguoiDung=@MaNguoiDung";
            try
            {
                using (SqlConnection con = new SqlConnection(conn.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@MaNguoiDung", SqlDbType.VarChar, 10).Value = maNguoiDung;

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }
        //Kiểm tra 
        public DataRow KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@TenDangNhap AND MatKhau=@MatKhau";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = matKhau;

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }
        public bool UpdateOne(string maNguoiDung, string maNhanVien, string tenDangNhap, string matKhau, string vaiTro)
        {
            string sql = @"UPDATE TaiKhoan 
                    SET MaNV=@MaNV, TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, VaiTro=@VaiTro
                    WHERE MaNguoiDung=@MaNguoiDung";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@MaNguoiDung", SqlDbType.VarChar, 10).Value = maNguoiDung;
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNhanVien;
                cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = matKhau;
                cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20).Value = vaiTro;

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }

        }
        public bool CapNhatTaiKhoan(string tenDangNhap, string matKhau, string vaiTro)
        {
            string sql = @"UPDATE TaiKhoan 
                   SET MatKhau = @MatKhau, VaiTro = @VaiTro
                   WHERE TenDangNhap = @TenDangNhap";
            try
            {
                using (SqlConnection con = new SqlConnection(conn.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = matKhau;
                    cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20).Value = vaiTro;
                    cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
        }

    }
}
