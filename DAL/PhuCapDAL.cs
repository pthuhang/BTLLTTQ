using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class PhuCapDAL : DBConnection
    {
        public DataTable LayDanhSachPhuCap()
        {
            string sql = "SELECT * FROM PhuCap";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Them(string maPC, string tenPC, decimal tienPC)
        {
            string sql = "INSERT INTO PhuCap (MaPhuCap, TenPhuCap, TienPhuCap) VALUES (@MaPC, @TenPC, @TienPC)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPC", maPC);
                cmd.Parameters.AddWithValue("@TenPC", tenPC);
                cmd.Parameters.AddWithValue("@TienPC", tienPC);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
        }

        public void Sua(string maPC, string tenPC, decimal tienPC)
        {
            string sql = "UPDATE PhuCap SET TenPhuCap=@TenPC, TienPhuCap=@TienPC WHERE MaPhuCap=@Ma";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPC", maPC);
                cmd.Parameters.AddWithValue("@TenPC", tenPC);
                cmd.Parameters.AddWithValue("@TienPC", tienPC);
                conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
            }
        }

        public void Xoa(string maPC)
        {
            string sql = "DELETE FROM PhuCap WHERE MaPhuCap=@Ma";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPC", maPC);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
