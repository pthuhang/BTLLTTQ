using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class PhongBanDAL : DBConnection
    {
        public DataTable LayDanhSachPhongBan()
        {
            string sql = "SELECT * FROM PhongBan";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LayNhanVienTheoMaPhongBan(string maPB)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT nv.MaNV, nv.HoTen, nv.MaPhong, pb.TenPhongBan
                FROM NhanVien nv
                INNER JOIN PhongBan pb ON nv.MaPhong = pb.MaPhongBan
                WHERE pb.MaPhongBan = @MaPB";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaPB", SqlDbType.VarChar, 10).Value = maPB;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }
        public async Task<DataTable> LayNhanVienTheoMaPhongBanAsync(string maPB)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT nv.MaNV, nv.HoTen, nv.MaPhong, pb.TenPhongBan
                FROM NhanVien nv
                INNER JOIN PhongBan pb ON nv.MaPhong = pb.MaPhongBan
                WHERE pb.MaPhongBan = @MaPB";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaPB", SqlDbType.VarChar, 10).Value = maPB;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    await Task.Run(() => da.Fill(dt));
                }
            }
            return dt;
        }
        //-----
        public bool KiemTraTonTaiMa(string maPB)
        {
            string sql = "SELECT COUNT(*) FROM PhongBan WHERE MaPhongBan = @MaPB";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaPB", SqlDbType.VarChar, 10).Value = maPB;
                if (conn.State != ConnectionState.Open) conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        public bool KiemTraTonTaiTen(string tenPB, string maPBHienTai = null)
        {
            string sql = "SELECT COUNT(*) FROM PhongBan WHERE TenPhongBan = @TenPB";
            if (!string.IsNullOrEmpty(maPBHienTai))
                sql += " AND MaPhongBan <> @MaPB";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@TenPB", SqlDbType.NVarChar, 50).Value = tenPB;
                if (!string.IsNullOrEmpty(maPBHienTai))
                    cmd.Parameters.Add("@MaPB", SqlDbType.VarChar, 10).Value = maPBHienTai;

                if (conn.State != ConnectionState.Open) conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }


        //-----THÊM, SỬA, XÓA-----
        public void Them(string maPB, string tenPB, string truongPhong)
        {
            string sql = "INSERT INTO PhongBan VALUES (@MaPB, @TenPB, @TruongPhong)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaPB", SqlDbType.VarChar, 10).Value = maPB;
                cmd.Parameters.Add("@TenPB", SqlDbType.NVarChar, 50).Value = tenPB;
                cmd.Parameters.Add("@TruongPhong", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(truongPhong) ? DBNull.Value : (object)truongPhong;

                if (conn.State != ConnectionState.Open) conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Sua(string maPB, string tenPB, string truongPhong)
        {
            string sql = "UPDATE PhongBan SET TenPhongBan=@TenPB, MaTruongPhong=@TruongPhong WHERE MaPhongBan=@MaPB";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaPB", SqlDbType.VarChar, 10).Value = maPB;
                cmd.Parameters.Add("@TenPB", SqlDbType.NVarChar, 50).Value = tenPB;
                cmd.Parameters.Add("@TruongPhong", SqlDbType.VarChar, 10).Value =
                    string.IsNullOrEmpty(truongPhong) ? DBNull.Value : (object)truongPhong;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(string maPB)
        {
            string sql = "DELETE FROM PhongBan WHERE MaPhongBan=@MaPB";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaPB", SqlDbType.VarChar, 10).Value = maPB;

                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }
    }
}
