using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class TrinhDoDAL : DBConnection
    {
        public DataTable LayDanhSachTrinhDo()
        {
            string sql = "SELECT * FROM TrinhDo";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Them(string ma, string ten)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TrinhDo VALUES (@Ma, @Ten)", conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters.AddWithValue("@Ten", ten);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }

        public void Sua(string ma, string ten)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TrinhDo SET TenTrinhDo=@Ten WHERE MaTrinhDo=@Ma", conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            cmd.Parameters.AddWithValue("@Ten", ten);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }

        public void Xoa(string ma)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TrinhDo WHERE MaTrinhDo=@Ma", conn);
            cmd.Parameters.AddWithValue("@Ma", ma);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }
    }
}
