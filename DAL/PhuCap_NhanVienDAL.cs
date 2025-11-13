using QUANLYNHANSU.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class PhuCap_NhanVienDAL : DBConnection
    {
        public DataTable LayDanhSachPhuCapNhanVien()
        {
            string sql = @"
                        SELECT 
                            nv.MaNV, 
                            nv.HoTen, 
                            pc.MaPhuCap, 
                            pc.TenPhuCap
                        FROM PhuCap_NhanVien pcnv
                        INNER JOIN NhanVien nv ON pcnv.MaNV = nv.MaNV
                        INNER JOIN PhuCap pc ON pcnv.MaPhuCap = pc.MaPhuCap";
            
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LayNhanVienTheoMa(string mnv)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(mnv))
                return dt;
            string sql = @"
                        SELECT
                            pcnv.MaNV, 
                            nv.HoTen, 
                            pcnv.MaPhuCap, 
                            pc.TenPhuCap, pc.TienPhuCap
                        FROM PhuCap_NhanVien pcnv
                        INNER JOIN NhanVien nv ON pcnv.MaNV = nv.MaNV
                        INNER JOIN PhuCap pc ON pcnv.MaPhuCap = pc.MaPhuCap
                        WHERE pcnv.MaNV = @mnv";
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //da.SelectCommand.Parameters.AddWithValue("@MaNV", mnv);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //return dt;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@mnv", mnv);

            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public string LayTenNV(string mnv)
        {
            string sql = "SELECT HoTen FROM NhanVien WHERE MaNV = @mnv";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@mnv", mnv);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            object result = cmd.ExecuteScalar();
            conn.Close();

            return result != null ? result.ToString() : string.Empty;
        }
        public void Them(string maPhuCap, string maNV)
        {
            string sql = "INSERT INTO PhuCap_NhanVien (MaPhuCap, MaNV) VALUES(@MaPhuCap, @MaNV)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhuCap", maPhuCap);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        public void Xoa(string maPhuCap, string maNV)
        {
            string sql = "DELETE FROM PhuCap_NhanVien WHERE MaPhuCap=@MaPhuCap AND MaNV=@MaNV";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhuCap", maPhuCap);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }

            }
        }
    }
}
