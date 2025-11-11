using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class TangCaDAL : DBConnection
    {
        public DataTable LayDanhSachTangCa()
        {
            string sql = "SELECT * FROM TangCa";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Them(string maTangCa, DateTime ngayTangCa)
        {
            string sql = "INSERT INTO TangCa VALUES (@MaTangCa, @NgayTangCa)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaTangCa", maTangCa);
            cmd.Parameters.AddWithValue("@NgayTangCa", ngayTangCa);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Xoa(string maTangCa)
        {
            string sql = "DELETE FROM TangCa WHERE MaTangCa = @MaTangCa";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaTangCa", maTangCa);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool KiemTraTonTai(string maTangCa)
        {
            string sql = "SELECT COUNT(*) FROM TangCa WHERE MaTangCa = @Ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Ma", maTangCa);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            return count > 0;
        }

        public void Sua(string maTangCa, DateTime ngayMoi)
        {
            string sql = "UPDATE TangCa SET NgayTangCa = @NgayMoi WHERE MaTangCa = @MaTangCa";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@NgayMoi", ngayMoi);
            cmd.Parameters.AddWithValue("@MaTangCa", maTangCa);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
