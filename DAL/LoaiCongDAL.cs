using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class LoaiCongDAL : DBConnection
    {
        public DataTable LayDanhSachLoaiCong()
        {
            string sql = "SELECT * FROM LoaiCong";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Them(string ma, string ten, decimal heSo)
        {
            string sql = "INSERT INTO LoaiCong VALUES(@Ma, @Ten, @HeSo)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters.AddWithValue("@Ten", ten);
            cmd.Parameters.AddWithValue("@HeSo", heSo);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }

        public bool KiemTraTonTai(string maLoaiCong)
        {
            string sql = "SELECT COUNT(*) FROM LoaiCong WHERE MaLoaiCong = @Ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", maLoaiCong);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            return count > 0;
        }

        public void Sua(string ma, string ten, decimal heSo)
        {
            string sql = "UPDATE LoaiCong SET TenLoaiCong=@Ten, HeSo=@HeSo WHERE MaLoaiCong=@Ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters.AddWithValue("@Ten", ten);
            cmd.Parameters.AddWithValue("@HeSo", heSo);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }

        public void Xoa(string ma)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM LoaiCong WHERE MaLoaiCong=@Ma", conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }
    }
}
