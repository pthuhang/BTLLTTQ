using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QUANLYNHANSU.DAL
{
    public class NhanVienDAL : DBConnection
    {
        //-----Lấy NHÂN VIÊN-----
        public DataTable LayDanhSachNhanVien()
        {
            const string sql = "SELECT * FROM NhanVien";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
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
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable LayNhanVienTheoTenDangNhap(string tenDangNhap)
        {
            string sql = @"
                SELECT nv.*, td.TenTrinhDo, pb.TenPhongBan
                FROM NhanVien nv
                INNER JOIN TaiKhoan tk ON nv.MaNV = tk.MaNV
                LEFT JOIN TrinhDo td on td.MaTrinhDo = nv.MaTrinhDo
                LEFT JOIN PhongBan pb on pb.MaPhongBan = Nv.MaPhongBan
                WHERE tk.TenDangNhap = @TenDangNhap";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public string LayMaNhanVienLonNhat()
        {
            string sql = "SELECT MAX(MaNV) FROM NhanVien";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var result = cmd.ExecuteScalar();
                return result == DBNull.Value ? null : result.ToString();
            }
        }

        //Kiẻmtra
        public bool KiemTraTonTai(string cot, string giaTri)
        {
            string[] allowedColumns = { "MaNV", "SDT", "CCCD", "Email" };
            if (!allowedColumns.Contains(cot))
                throw new ArgumentException("Cột không hợp lệ.");

            string sql = $"SELECT COUNT(1) FROM NhanVien WHERE {cot} = @GiaTri";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@GiaTri", SqlDbType.NVarChar, 50).Value = giaTri;

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }

        }


        public DataRow KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string sql = "SELECT *" +
                " FROM NhanVien nv" +
                " INNER JOIN TaiKhoan tk on tk.MaNV = nv.MaNV" +
                " WHERE tk.TenDangNhap = @tenDangNhap AND tk.MatKhau = @matKhau";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@tenDangNhap", SqlDbType.NVarChar, 50).Value = tenDangNhap;
                cmd.Parameters.Add("@matKhau", SqlDbType.NVarChar, 50).Value = matKhau;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];
                    else
                        return null;
                }
            }
        }

        //-----THÊM, SỬA, XÓA-----
        public void Them(
            string ma, string ten, bool gioiTinh, DateTime ngaySinh, string sdt, string cccd,
            string diaChi, string email, string trangThai, string maPhong, string maTrinhDo,
            string chucVu, string soBH, decimal mucDong, string stk)
        {
            string sql = @"
                INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, SDT, CCCD, DiaChi, Email, TrangThai,
                                      MaPhongBan, MaTrinhDo, ChucVu, SoBaoHiemXaHoi, MucDong, SoTaiKhoan)
                VALUES (@Ma, @Ten, @GT, @NgaySinh, @SDT, @CCCD, @DiaChi, @Email, @TrangThai, 
                        @Phong, @TrinhDo, @ChucVu, @SoBH, @MucDong, @STK)";
            //try
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@Ma", SqlDbType.VarChar, 10).Value = ma.Trim();
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 100).Value = ten;
                cmd.Parameters.Add("@GT", SqlDbType.Bit).Value = gioiTinh;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = ngaySinh;
                cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 15).Value = sdt;
                cmd.Parameters.Add("@CCCD", SqlDbType.VarChar, 12).Value = cccd;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 200).Value = diaChi;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 50).Value = trangThai;
                cmd.Parameters.Add("@Phong", SqlDbType.VarChar, 10).Value = maPhong;
                cmd.Parameters.Add("@TrinhDo", SqlDbType.VarChar, 10).Value = maTrinhDo;
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 50).Value = chucVu;
                cmd.Parameters.Add("@SoBH", SqlDbType.VarChar, 20).Value = soBH;

                var paramMucDong = cmd.Parameters.Add("@MucDong", SqlDbType.Decimal);
                paramMucDong.Precision = 18;
                paramMucDong.Scale = 2;
                paramMucDong.Value = mucDong;

                cmd.Parameters.Add("@STK", SqlDbType.VarChar, 20).Value = stk;

                con.Open();
                cmd.ExecuteNonQuery();
            }
                //}
                //catch (Exception ex)
                //{
                //    throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
                //}
                //finally
                //{
                //    conn.Close();
                //}
            }

        public void Sua(
            string ma, string ten, bool gioiTinh, DateTime ngaySinh, string sdt, string cccd,
            string diaChi, string email, string trangThai, string maPhong, string maTrinhDo,

            string chucVu, string soBH, decimal mucDong, string stk)

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
                    cmd.Parameters.Add("@Ma", SqlDbType.VarChar, 10).Value = ma.Trim();
                    cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 100).Value = ten;
                    cmd.Parameters.Add("@GT", SqlDbType.Bit).Value = gioiTinh;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = ngaySinh;
                    cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 15).Value = sdt;
                    cmd.Parameters.Add("@CCCD", SqlDbType.VarChar, 12).Value = cccd;
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 200).Value = diaChi;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                    cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 50).Value = trangThai;
                    cmd.Parameters.Add("@Phong", SqlDbType.VarChar, 10).Value = maPhong;
                    cmd.Parameters.Add("@TrinhDo", SqlDbType.VarChar, 10).Value = maTrinhDo;
                    cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 50).Value = chucVu;
                    cmd.Parameters.Add("@SoBH", SqlDbType.VarChar, 20).Value = soBH;
                    cmd.Parameters.Add("@MucDong", SqlDbType.Decimal).Value = mucDong;
                    cmd.Parameters["@MucDong"].Precision = 18;
                    cmd.Parameters["@MucDong"].Scale = 2;

                    cmd.Parameters.Add("@STK", SqlDbType.VarChar, 20).Value = stk;

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

        public void Xoa(string ma)
        {

            try
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNV = @MaNV", conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = ma;
                    cmd.ExecuteNonQuery();
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

        // -----Tim kiếm-----
        public DataTable TimKiem(string maNV, string hoTen)
        {
            string sql = "SELECT * FROM NhanVien WHERE 1=1";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(maNV))
                {
                    sql += " AND MaNV LIKE '%' + @MaNV + '%'";
                    cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = maNV.Trim();
                }

                if (!string.IsNullOrWhiteSpace(hoTen))
                {
                    sql += " AND HoTen LIKE N'%' + @HoTen + '%'";
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = hoTen.Trim();
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


        //-----LỌC-----
        public DataTable LocTheoTrinhDo(string tenTrinhDo)
        {
            const string sql = @"
                SELECT nv.* 
                FROM NhanVien nv
                INNER JOIN TrinhDo td ON nv.MaTrinhDo = td.MaTrinhDo
                WHERE td.TenTrinhDo = @TenTrinhDo";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@TenTrinhDo", SqlDbType.NVarChar, 100).Value = tenTrinhDo;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable LocTheoGioiTinh(string gioiTinh)
        {
            int gt = gioiTinh == "Nam" ? 1 : 0;

            string sql = "SELECT * FROM NhanVien WHERE GioiTinh = @gioiTinh";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = gt;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable LayDanhSachChucVu()
        {
            string sql = "SELECT DISTINCT ChucVu FROM NhanVien WHERE ChucVu IS NOT NULL AND LTRIM(RTRIM(ChucVu)) <> ''";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LocTheoChucVu(string chucVu)
        {
            string sql = "SELECT * FROM NhanVien WHERE ChucVu LIKE '%' + @chucVu + '%'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 50).Value = chucVu;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable LayNhanVienTheoPhongBan(string maPhong)
        {
            const string sql = "SELECT * FROM NhanVien WHERE MaPhongBan = @MaPhongBan";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaPhongBan", SqlDbType.VarChar, 10).Value = maPhong;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable LocTheoTrangThai(string trangThai)
        {
            string sql = "SELECT * FROM NhanVien WHERE TrangThai = @trangThai";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 50).Value = trangThai;

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
