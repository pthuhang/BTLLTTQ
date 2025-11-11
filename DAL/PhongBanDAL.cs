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
        public DataTable LayNhanVienTheoMaPhongBan(string ma)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT nv.MaNV, nv.HoTen, nv.MaPhong, pb.TenPhongBan
                FROM NhanVien nv
                INNER JOIN PhongBan pb ON nv.MaPhong = pb.MaPhongBan
                WHERE pb.MaPhongBan = @Ma";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        public void Them(string ma, string ten, string truongPhong)
        {
            string sql = "INSERT INTO PhongBan VALUES (@Ma, @Ten, @Truong)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters.AddWithValue("@Ten", ten);
            cmd.Parameters.AddWithValue("@Truong", string.IsNullOrEmpty(truongPhong) ? DBNull.Value : (object)truongPhong);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Sua(string ma, string ten, string truongPhong)
        {
            string sql = "UPDATE PhongBan SET TenPhongBan=@Ten, MaTruongPhong=@Truong WHERE MaPhongBan=@Ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters.AddWithValue("@Ten", ten);
            cmd.Parameters.AddWithValue("@Truong", string.IsNullOrEmpty(truongPhong) ? DBNull.Value : (object)truongPhong);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Xoa(string ma)
        {
            string sql = "DELETE FROM PhongBan WHERE MaPhongBan=@Ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
