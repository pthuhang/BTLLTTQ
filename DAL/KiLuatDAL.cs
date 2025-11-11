using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.DAL
{
    public class KiLuatDAL : DBConnection
    {
        public DataTable LayDanhSachKiLuat()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KiLuat", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool Them(string maKiLuat, string noiDung, decimal tienPhat)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO KiLuat(MaKiLuat, NoiDung, TienPhat) VALUES(@MaKiLuat, @NoiDung, @TienPhat)", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKiLuat", maKiLuat);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                    cmd.Parameters.AddWithValue("@TienPhat", tienPhat);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message);
                return false;
            }
        }


        public bool  Sua(string ma, string noiDung, decimal soTien)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE KiLuat SET NoiDung=@NoiDung, TienPhat=@TienPhat WHERE MaKiLuat=@MaKiLuat", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKiLuat", ma);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                    cmd.Parameters.AddWithValue("@TienPhat", soTien);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                return false;

            }
        }

        public bool Xoa(string ma)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM KiLuat WHERE MaKiLuat=@MaKiLuat", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKiLuat", ma);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Lỗi xóa: " + ex.Message);
                return false;
            }
        }
        public bool TonTaiMaKiLuat(string maKiLuat)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KiLuat WHERE MaKiLuat = @MaKiLuat", conn))
            {
                cmd.Parameters.AddWithValue("@MaKiLuat", maKiLuat);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

    }
}
