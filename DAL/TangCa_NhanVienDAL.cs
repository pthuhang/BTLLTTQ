using QUANLYNHANSU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class TangCa_NhanVienDAL : DBConnection
    {

        public DataTable LayDanhSach()
        {
            string sql = "SELECT * FROM TangCa_NhanVien";
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable LayTangCaTheoNV(string maNV)
        {
            string sql = "SELECT * FROM TangCa_NhanVien WHERE MaNV = @MaNV";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaNV", maNV);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LayTangCaTheoThangNam(int thang, int nam, string maNV)
        {
            string sql = "SELECT MaNV, SoGioTangCa, NgayTangCa " +
                         "FROM TangCa_NhanVien " +
                         "WHERE MONTH(NgayTangCa) = @Thang AND YEAR(NgayTangCa) = @Nam";

            if (!string.IsNullOrEmpty(maNV))
                sql += " AND MaNV = @MaNV";

            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    if (!string.IsNullOrEmpty(maNV))
                        cmd.Parameters.AddWithValue("@MaNV", maNV);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void Them(string maNV, int soGioTangCa, DateTime ngayTangCa)
        {
            string sql = "INSERT INTO TangCa_NhanVien (MaNV, NgayTangCa, SoGioTangCa) VALUES (@MaNV, @NgayTangCa, @SoGioTangCa)";
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    cmd.Parameters.Add("@NgayTangCa", SqlDbType.DateTime).Value = ngayTangCa;
                    cmd.Parameters.Add("@SoGioTangCa", SqlDbType.Int).Value = soGioTangCa;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool KiemTraTonTai(DateTime ngayTC, string maNV)
        {
            string sql = "SELECT COUNT(*) FROM TangCa_NhanVien WHERE MaNV = @MaNV AND CAST(NgayTangCa AS DATE) = CAST(@NgayTC AS DATE)";
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@NgayTC", SqlDbType.DateTime).Value = ngayTC.Date;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void Sua(string maNV, DateTime ngayTC, int soGioMoi)
        {
            string sql = "UPDATE TangCa_NhanVien SET SoGioTangCa = @SoGioMoi WHERE NgayTangCa = @NgayTC AND MaNV = @MaNV";
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@SoGioMoi", SqlDbType.Int).Value = soGioMoi;
                    cmd.Parameters.Add("@NgayTC", SqlDbType.DateTime).Value = ngayTC;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void XoaVaCapNhatTangCa(DateTime ngayTC, string maNV)
        {
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                connection.Open();

                string sqlDelete = "DELETE FROM TangCa_NhanVien WHERE NgayTangCa = @NgayTC AND MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(sqlDelete, connection))
                {
                    cmd.Parameters.Add("@NgayTC", SqlDbType.DateTime).Value = ngayTC;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
