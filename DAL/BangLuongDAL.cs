using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class BangLuongDAL : DBConnection
    {
        public DataTable LayDanhSach()
        {
            string sql = "SELECT * FROM BangLuong";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LayDanhSachTheoMa(string mnv)
        {
            string sql = "SELECT * FROM BangLuong WHERE MaNV = @MaNV";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNV", mnv);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LayBangLuonggTheoThangNam(int thang, int nam, string maNV)
        {
            string sql = "SELECT *  " +
                         " FROM BangLuong " +
                         " WHERE Thang=@thang and Nam=@nam";

            if (!string.IsNullOrEmpty(maNV))
                sql += " AND MaNV = @MaNV";

            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    if (!string.IsNullOrEmpty(maNV))
                        cmd.Parameters.AddWithValue("@MaNV", maNV);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataRow LayThongTinHD(string maNV)
        {
            string sql = "SELECT HeSoLuong, LuongCoBan FROM HopDong WHERE MaNV = @MaNV";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNV", maNV);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        public decimal LayMucDongBH(string maNV)
        {
            string sql = "SELECT MucDong FROM NhanVien WHERE MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }
        // 🔹 Tổng phụ cấp theo tháng
        public decimal TinhTongPhuCap(string maNV)
        {
            string sql = @"
                    SELECT ISNULL(SUM(p.TienPhuCap), 0)
                    FROM PhuCap_NhanVien pn
                    INNER JOIN PhuCap p ON pn.MaPhuCap = p.MaPhuCap
                    WHERE pn.MaNV = @MaNV";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return Convert.ToDecimal(result);
        }

        // 🔹 Tổng thưởng theo tháng
        public decimal TinhTongThuong(string maNV, int thang, int nam)
        {
            string sql = @"
                    SELECT ISNULL(SUM(k.TienKhenThuong), 0)
                    FROM Khen_NhanVien kn
                    INNER JOIN KhenThuong k ON kn.MaKhenThuong = k.MaKhenThuong
                    WHERE kn.MaNV = @MaNV
                      AND MONTH(kn.NgayKhenThuong) = @Thang
                      AND YEAR(kn.NgayKhenThuong) = @Nam";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return Convert.ToDecimal(result);
        }

        // 🔹 Tổng phạt theo tháng
        public decimal TinhTongPhat(string maNV, int thang, int nam)
        {
            string sql = @"
                    SELECT ISNULL(SUM(p.TienPhat), 0)
                    FROM KiLuat_NhanVien kn
                    INNER JOIN KiLuat p ON p.MaKiLuat = kn.MaKiLuat
                    WHERE kn.MaNV = @MaNV
                      AND MONTH(kn.NgayKiLuat) = @Thang
                      AND YEAR(kn.NgayKiLuat) = @Nam";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return Convert.ToDecimal(result);
        }

        // 🔹 Tổng số giờ tăng ca theo tháng
        public decimal TinhSoGioTangCa(string maNV, int thang, int nam)
        {
            string sql = @"
                SELECT ISNULL(SUM(SoGioTangCa), 0)
                FROM TangCa_NhanVien
                WHERE MaNV = @MaNV
                  AND MONTH(NgayTangCa) = @Thang
                  AND YEAR(NgayTangCa) = @Nam";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return Convert.ToDecimal(result);
        }

        // 🔹 Tổng số ngày công theo tháng
        public decimal TinhSoNgayCong(string maNV, int thang, int nam)
        {
            string sql = @"
                    SELECT ISNULL(SUM(lc.HeSo), 0)
                    FROM LoaiCong_NhanVien lcnv
                    JOIN LoaiCong lc on lcnv.MaLoaiCong = lc.MaLoaiCong
                    WHERE lcnv.MaNV = @MaNV
                      AND MONTH(lcnv.NgayLam) = @Thang
                      AND YEAR(lcnv.NgayLam) = @Nam";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return Convert.ToDecimal(result);
        }


        public bool KiemTraBangLuong(string maNV, int thang, int nam)
        {
            string sql = "SELECT COUNT(*) FROM BangLuong WHERE MaNV = @MaNV AND Thang = @Thang AND Nam = @Nam";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            return count > 0;
        }
        public void Them(string maBangLuong, string maNV, int thang, int nam,
                 decimal soNgayCong, decimal soGioTangCa,
                 decimal tongPhuCap, decimal tongThuong, decimal tongPhat,
                 decimal luongCoBan, float heSoLuong, decimal luongThucLinh)
        {
            string sql = @"INSERT INTO BangLuong 
                   (MaBangLuong, MaNV, Thang, Nam, SoNgayCong, SoGioTangCa, 
                    TongPhuCap, TongThuong, TongPhat, LuongCoBan, HeSoLuong, LuongThucLinh)
                   VALUES (@MaBangLuong, @MaNV, @Thang, @Nam, @SoNgayCong, @SoGioTangCa,
                           @TongPhuCap, @TongThuong, @TongPhat, @LuongCoBan, @HeSoLuong, @LuongThucLinh)";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaBangLuong", maBangLuong);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@Thang", thang);
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.Parameters.AddWithValue("@SoNgayCong", soNgayCong);
                cmd.Parameters.AddWithValue("@SoGioTangCa", soGioTangCa);
                cmd.Parameters.AddWithValue("@TongPhuCap", tongPhuCap);
                cmd.Parameters.AddWithValue("@TongThuong", tongThuong);
                cmd.Parameters.AddWithValue("@TongPhat", tongPhat);
                cmd.Parameters.AddWithValue("@LuongCoBan", luongCoBan);
                cmd.Parameters.AddWithValue("@HeSoLuong", heSoLuong);
                cmd.Parameters.AddWithValue("@LuongThucLinh", luongThucLinh);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
