using QUANLYNHANSU.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class LoaiCong_NhanVienDAL : DBConnection
    {

        private LoaiCongDAL lc = new LoaiCongDAL();
        public DataTable LayDanhSach()
        {
            string sql = "SELECT lcnv.MaloaiCong, lcnv.MaNV, lc.TenLoaiCong, lcnv.NgayLam, lcnv.GioVao, lcnv.GioRa, lcnv.HeSoCong  FROM LoaiCong_NhanVien lcnv JOIN LoaiCong lc ON lcnv.MaLoaiCong = lc.MaLoaiCong";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void Them(string maLoaiCong, string maNV, DateTime ngayLam, TimeSpan gioVao, TimeSpan gioRa, decimal heSoCong)
        {
            string sql = "INSERT INTO LoaiCong_NhanVien VALUES (@MaLoaiCong, @MaNV, @NgayLam, @GioVao, @GioRa, @HeSoCong)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaLoaiCong", maLoaiCong);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@NgayLam", ngayLam);
            cmd.Parameters.AddWithValue("@GioVao", gioVao);
            cmd.Parameters.AddWithValue("@GioRa", gioRa);
            cmd.Parameters.AddWithValue("@HeSoCong", heSoCong);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool KiemTraTonTai(string maLoaiCong, string maNV)
        {
            string sql = "SELECT COUNT(*) FROM LoaiCong_NhanVien WHERE MaLoaiCong = @MaLoaiCong AND MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaLoaiCong", maLoaiCong);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            return count > 0;
        }
        public void XoaVaCapNhatLoaiCong(string maLoaiCong, string maNV)
        {
            conn.Open();
            string sqlDelete = "DELETE FROM LoaiCong_NhanVien WHERE MaLoaiCong = @MaLoaiCong AND MaNV = @MaNV";
            using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
            {
                cmd.Parameters.AddWithValue("@MaLoaiCong", maLoaiCong);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.ExecuteNonQuery();
            }

            string sqlCheck = "SELECT COUNT(*) FROM LoaiCong_NhanVien WHERE MaLoaiCong = @MaLoaiCong";
            using (SqlCommand cmd = new SqlCommand(sqlCheck, conn))
            {
                cmd.Parameters.AddWithValue("@MaLoaiCong", maLoaiCong);
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    lc.Xoa(maLoaiCong);
                }
            }
            conn.Close();

        }

        public void Xoa(string maLoaiCong, string maNV)
        {

            string sql = "DELETE FROM LoaiCong_NhanVien WHERE MaLoaiCong = @MaLoaiCong AND MaNV = @MaNV";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaLoaiCong", maLoaiCong);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 🟢 Sửa thông tin công (chỉ sửa dữ liệu phụ, không sửa khóa chính)
        public void Sua(string maLoaiCong, string maNV, DateTime ngayLam, TimeSpan gioVao, TimeSpan gioRa, decimal heSoCong)
        {
            string sql = "UPDATE LoaiCong_NhanVien " +
                         "SET NgayLam = @NgayLam, GioVao = @GioVao, GioRa = @GioRa, HeSoCong = @HeSoCong " +
                         "WHERE MaLoaiCong = @MaLoaiCong AND MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@NgayLam", ngayLam);
            cmd.Parameters.AddWithValue("@GioVao", gioVao);
            cmd.Parameters.AddWithValue("@GioRa", gioRa);
            cmd.Parameters.AddWithValue("@HeSoCong", heSoCong);
            cmd.Parameters.AddWithValue("@MaLoaiCong", maLoaiCong);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable LocLoaiCongNV(string maNV, string ngay, string thang, string nam)
        {
            string sql = "SELECT * FROM LoaiCong_NhanVien WHERE 1=1";

            if (!string.IsNullOrEmpty(maNV))
                sql += " AND MaNV LIKE @MaNV";
            if (!string.IsNullOrEmpty(ngay))
                sql += " AND DAY(NgayLam) = @Ngay";
            if (!string.IsNullOrEmpty(thang))
                sql += " AND MONTH(NgayLam) = @Thang";
            if (!string.IsNullOrEmpty(nam))
                sql += " AND YEAR(NgayLam) = @Nam";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (!string.IsNullOrEmpty(maNV))
                    cmd.Parameters.AddWithValue("@MaNV", "%" + maNV + "%");
                if (!string.IsNullOrEmpty(ngay))
                    cmd.Parameters.AddWithValue("@Ngay", ngay);
                if (!string.IsNullOrEmpty(thang))
                    cmd.Parameters.AddWithValue("@Thang", thang);
                if (!string.IsNullOrEmpty(nam))
                    cmd.Parameters.AddWithValue("@Nam", nam);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
