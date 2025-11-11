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
        private TangCaDAL tangCaDAL = new TangCaDAL(); 

        public DataTable LayDanhSach()
        {
            string sql = "SELECT tcnv.MaTangCa, tcnv.MaNV, tc.NgayTangCa, tcnv.SoGioTangCa FROM TangCa_NhanVien tcnv JOIN TangCa tc ON tcnv.MaTangCa = tc.MaTangCa";
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Them(string maTangCa, string maNV, int soGioTangCa)
        {
            string sql = "INSERT INTO TangCa_NhanVien (MaTangCa, MaNV, SoGioTangCa) VALUES (@MaTangCa, @MaNV, @SoGioTangCa)";
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@MaTangCa", SqlDbType.NVarChar).Value = maTangCa;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    cmd.Parameters.Add("@SoGioTangCa", SqlDbType.Int).Value = soGioTangCa;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool KiemTraTonTai(string maTangCa, string maNV)
        {
            string sql = "SELECT COUNT(*) FROM TangCa_NhanVien WHERE MaTangCa = @MaTangCa AND MaNV = @MaNV";
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@MaTangCa", SqlDbType.NVarChar).Value = maTangCa;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void Sua(string maTangCa, string maNV, int soGioMoi)
        {
            string sql = "UPDATE TangCa_NhanVien SET SoGioTangCa = @SoGioMoi WHERE MaTangCa = @MaTangCa AND MaNV = @MaNV";
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@SoGioMoi", SqlDbType.Int).Value = soGioMoi;
                    cmd.Parameters.Add("@MaTangCa", SqlDbType.NVarChar).Value = maTangCa;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void XoaVaCapNhatTangCa(string maTangCa, string maNV)
        {
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                connection.Open();

                // Delete from TangCa_NhanVien
                string sqlDelete = "DELETE FROM TangCa_NhanVien WHERE MaTangCa = @MaTangCa AND MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(sqlDelete, connection))
                {
                    cmd.Parameters.Add("@MaTangCa", SqlDbType.NVarChar).Value = maTangCa;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    cmd.ExecuteNonQuery();
                }

                // Check if MaTangCa is still referenced
                string sqlCheck = "SELECT COUNT(*) FROM TangCa_NhanVien WHERE MaTangCa = @MaTangCa";
                using (SqlCommand cmd = new SqlCommand(sqlCheck, connection))
                {
                    cmd.Parameters.Add("@MaTangCa", SqlDbType.NVarChar).Value = maTangCa;
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        tangCaDAL.Xoa(maTangCa);
                    }
                }
            }
        }
    }
}
