using System;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.DAL
{
    public class NhanVienDAL : DBConnection
    {
        public DataTable LayDanhSachNhanVien()
        {
            const string sql = "SELECT * FROM NhanVien";
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LayNhanVienTheoMa(string maNV)
        {
            string sql = "SELECT * FROM NhanVien WHERE MaNV = @ma";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ma", maNV);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public void  Them(
            string ma, string ten, bool gioiTinh, DateTime ngaySinh, string sdt, string cccd,
            string diaChi, string email, string trangThai, string maPhong, string maTrinhDo,
            string chucVu, string soBH, decimal mucDong, string stk)
        {
            const string sql = @"
                INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, SDT, CCCD, DiaChi, Email, TrangThai,
                                      MaPhongBan, MaTrinhDo, ChucVu, SoBaoHiemXaHoi, MucDong, SoTaiKhoan)
                VALUES (@Ma, @Ten, @GT, @NgaySinh, @SDT, @CCCD, @DiaChi, @Email, @TrangThai, 
                        @Phong, @TrinhDo, @ChucVu, @SoBH, @MucDong, @STK)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", ma);
                    cmd.Parameters.AddWithValue("@Ten", ten);
                    cmd.Parameters.AddWithValue("@GT", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@CCCD", cccd);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@Phong", maPhong);
                    cmd.Parameters.AddWithValue("@TrinhDo", maTrinhDo);
                    cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                    cmd.Parameters.AddWithValue("@SoBH", soBH);
                    cmd.Parameters.AddWithValue("@MucDong", mucDong);
                    cmd.Parameters.AddWithValue("@STK", stk);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // 🧩 Cập nhật nhân viên
        public void Sua(
            string ma, string ten, bool gioiTinh, DateTime ngaySinh, string sdt, string cccd,
            string diaChi, string email, string trangThai, string maPhong, string maTrinhDo,
            string chucVu,string soBH, decimal mucDong, string stk)
        {
            const string sql = @"
                UPDATE NhanVien SET 
                    HoTen=@Ten, GioiTinh=@GT, NgaySinh=@NgaySinh, SDT=@SDT, CCCD=@CCCD, 
                    DiaChi=@DiaChi, Email=@Email, TrangThai=@TrangThai, 
                    MaPhongBan=@Phong, MaTrinhDo=@TrinhDo, ChucVu=@ChucVu,
                    SoBaoHiemXaHoi=@SoBH, MucDong=@MucDong, SoTaiKhoan=@STK
                WHERE MaNV=@Ma";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", ma);
                    cmd.Parameters.AddWithValue("@Ten", ten);
                    cmd.Parameters.AddWithValue("@GT", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@CCCD", cccd);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@Phong", maPhong);
                    cmd.Parameters.AddWithValue("@TrinhDo", maTrinhDo);
                    cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                    cmd.Parameters.AddWithValue("@SoBH", soBH);
                    cmd.Parameters.AddWithValue("@MucDong", mucDong);
                    cmd.Parameters.AddWithValue("@STK", stk);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // 🧩 Xóa nhân viên
        public bool Xoa(string ma)
        {
            const string sql = "DELETE FROM NhanVien WHERE MaNV=@Ma";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", ma);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // 🧩 Tìm kiếm nhân viên
        public DataTable TimKiem(string maNV, string hoTen)
        {
            string sql = "SELECT * FROM NhanVien WHERE 1=1";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(maNV))
                {
                    sql += " AND MaNV LIKE '%' + @MaNV + '%'";
                    cmd.Parameters.AddWithValue("@MaNV", maNV.Trim());
                }

                if (!string.IsNullOrWhiteSpace(hoTen))
                {
                    sql += " AND HoTen LIKE N'%' + @HoTen + '%'";
                    cmd.Parameters.AddWithValue("@HoTen", hoTen.Trim());
                }

                cmd.CommandText = sql;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 🧩 Lấy nhân viên nam
        public DataTable LayNhanVienNam()
        {
            const string sql = "SELECT * FROM NhanVien WHERE GioiTinh = 1";
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 🧩 Lọc theo trình độ
        public DataTable LocTheoTrinhDo(string tenTrinhDo)
        {
            const string sql = @"
                SELECT nv.* 
                FROM NhanVien nv
                INNER JOIN TrinhDo td ON nv.MaTrinhDo = td.MaTrinhDo
                WHERE td.TenTrinhDo = @TenTrinhDo";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenTrinhDo", tenTrinhDo);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 🧩 Sắp xếp theo lương giảm dần
        public DataTable SapXepTheoLuongGiam()
        {
            const string sql = "SELECT * FROM NhanVien ORDER BY LuongCoBan DESC";
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 🧩 Lấy nhân viên theo phòng ban
        public DataTable LayNhanVienTheoPhongBan(string maPhong)
        {
            const string sql = "SELECT * FROM NhanVien WHERE MaPhongBan = @MaPhongBan";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhongBan", maPhong);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
       

    }
}
