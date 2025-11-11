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
        public void Them(string ma, string ten, decimal soTien)
        {
            string sql = "INSERT INTO PhuCap VALUES(@Ma, @Ten, @SoTien)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters.AddWithValue("@Ten", ten);
            cmd.Parameters.AddWithValue("@SoTien", soTien);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }

        public void Sua(string ma, string ten, decimal soTien)
        {
            string sql = "UPDATE PhuCap SET TenPhuCap=@Ten, SoTien=@SoTien WHERE MaPhuCap=@Ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters.AddWithValue("@Ten", ten);
            cmd.Parameters.AddWithValue("@SoTien", soTien);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }

        public void Xoa(string ma)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PhuCap WHERE MaPhuCap=@Ma", conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }
    }
}
