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
        public decimal TinhTongPhuCap(string maNV)
        {
            string sql = "SELECT ISNULL(SUM(p.TienPhuCap), 0) " +
                "FROM PhuCap_NhanVien pn " +
                "INNER JOIN PhuCap p ON pn.MaPhuCap = p.MaPhuCap " +
                "WHERE pn.MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();
            return Convert.ToDecimal(result);
        }
        public decimal TinhTongThuong(string maNV)
        {
            string sql = "SELECT ISNULL(SUM(k.TienKhenThuong), 0) " +
                "FROM Khen_NhanVien kn " +
                "INNER JOIN KhenThuong k ON kn.MaKhenThuong = k.MaKhenThuong " +
                "WHERE kn.MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();
            return Convert.ToDecimal(result);
        }
        public decimal TinhTongPhat(string maNV)
        {
            string sql = "SELECT ISNULL(SUM(TienPhat), 0) " +
                "FROM KiLuat_NhanVien pn " +
                "INNER JOIN KiLuat p ON p.MaKiLuat = pn.MaKiLuat " +
                "WHERE pn.MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();
            return Convert.ToDecimal(result);
        }
        public float TinhSoGioTangCa(string maNV)
        {
            string sql = @"
                SELECT ISNULL(SUM(SoGioTangCa), 0)
                FROM TangCa_NhanVien
                WHERE MaNV = @MaNV
            ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return Convert.ToSingle(result);
        }

        public float TinhSoNgayCong(string maNV)
        {
            string sql = @"
                SELECT ISNULL(SUM(HeSoCong), 0)
                FROM LoaiCong_NhanVien
                WHERE MaNV = @MaNV
            ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return Convert.ToSingle(result);
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
                 float soNgayCong, float soGioTangCa,
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
        public string TaoMaBangLuongMoi()
        {
            string sql = "SELECT TOP 1 MaBangLuong FROM BangLuong ORDER BY MaBangLuong DESC";
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            if (result != null && result != DBNull.Value)
            {
                string maCu = result.ToString(); // Ví dụ: BL005
                string soPhan = maCu.Substring(2); // => "005"
                int soMoi = int.Parse(soPhan) + 1;
                return "BL" + soMoi.ToString("D3"); // D3 => định dạng 3 chữ số, ví dụ BL006
            }
            else
            {
                return "BL001";
            }
        }


        //public void Them(string maBL, string maNV, decimal luongCB, decimal tongPC, decimal tongKT, decimal tongKL, decimal thucLinh, DateTime thang)
        //{
        //    string sql = @"INSERT INTO BangLuong VALUES(@MaBL, @MaNV, @LuongCB, @TongPC, @TongKT, @TongKL, @ThucLinh, @Thang)";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("@MaBL", maBL);
        //    cmd.Parameters.AddWithValue("@MaNV", maNV);
        //    cmd.Parameters.AddWithValue("@LuongCB", luongCB);
        //    cmd.Parameters.AddWithValue("@TongPC", tongPC);
        //    cmd.Parameters.AddWithValue("@TongKT", tongKT);
        //    cmd.Parameters.AddWithValue("@TongKL", tongKL);
        //    cmd.Parameters.AddWithValue("@ThucLinh", thucLinh);
        //    cmd.Parameters.AddWithValue("@Thang", thang);
        //    conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        //}

        //public void Sua(string maBL, string maNV, decimal luongCB, decimal tongPC, decimal tongKT, decimal tongKL, decimal thucLinh, DateTime thang)
        //{
        //    string sql = @"UPDATE BangLuong SET MaNV=@MaNV, LuongCB=@LuongCB, TongPhuCap=@TongPC,
        //                   TongKhenThuong=@TongKT, TongKyLuat=@TongKL, ThucLinh=@ThucLinh, ThangLuong=@Thang
        //                   WHERE MaBangLuong=@MaBL";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("@MaBL", maBL);
        //    cmd.Parameters.AddWithValue("@MaNV", maNV);
        //    cmd.Parameters.AddWithValue("@LuongCB", luongCB);
        //    cmd.Parameters.AddWithValue("@TongPC", tongPC);
        //    cmd.Parameters.AddWithValue("@TongKT", tongKT);
        //    cmd.Parameters.AddWithValue("@TongKL", tongKL);
        //    cmd.Parameters.AddWithValue("@ThucLinh", thucLinh);
        //    cmd.Parameters.AddWithValue("@Thang", thang);
        //    conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        //}

        //public void Xoa(string maBL)
        //{
        //    SqlCommand cmd = new SqlCommand("DELETE FROM BangLuong WHERE MaBangLuong=@MaBL", conn);
        //    cmd.Parameters.AddWithValue("@MaBL", maBL);
        //    conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        //}
    }
}
