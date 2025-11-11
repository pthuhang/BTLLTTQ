using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class PhuCap_NhanVienDAL : DBConnection
    {
        public DataTable LayDanhSach()
        {
            string sql = "SELECT * FROM PhuCap_NhanVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Them(string maPhuCap, string maNV, decimal tienPhuCap)
        {
            string sql = "INSERT INTO PhuCap_NhanVien VALUES(@MaPhuCap, @MaNV, @TienPhuCap)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaPhuCap", maPhuCap);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@TienPhuCap", tienPhuCap);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }
        public void Sua(string maPhuCap, string maNV, decimal tienMoi)
        {
            string sql = "UPDATE PhuCap_NhanVien SET TienPhuCap = @TienMoi WHERE MaPhuCap = @MaPhuCap AND MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TienMoi", tienMoi);
            cmd.Parameters.AddWithValue("@MaPhuCap", maPhuCap);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Xoa(string maPhuCap, string maNV)
        {
            string sql = "DELETE FROM PhuCap_NhanVien WHERE MaPhuCap=@MaPhuCap AND MaNV=@MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaPhuCap", maPhuCap);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }
    }
}
