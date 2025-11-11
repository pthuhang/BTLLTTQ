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
    public class KhenThuongDAL : DBConnection
    {
        public DataTable LayDanhSachKhenThuong()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhenThuong", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool Them(string maKhenThuong, string noiDung, decimal tienKhenThuong)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO KhenThuong(MaKhenThuong, NoiDung, TienKhenThuong) VALUES(@MaKhenThuong, @NoiDung, @TienKhenThuong)", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhenThuong", maKhenThuong);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                    cmd.Parameters.AddWithValue("@TienKhenThuong", tienKhenThuong);

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


        public bool Sua(string maKhenThuong, string noiDung, decimal soTien)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE KhenThuong SET NoiDung=@NoiDung, TienKhenThuong=@TienKhenThuong WHERE MaKhenThuong=@MaKhenThuong", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhenThuong", maKhenThuong);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                    cmd.Parameters.AddWithValue("@TienKhenThuong", soTien);

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

        public bool Xoa(string maKhenThuong)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM KhenThuong WHERE MaKhenThuong=@MaKhenThuong", conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhenThuong", maKhenThuong);
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
        public bool TonTaiMaKhenThuong(string maKhenThuong)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KhenThuong WHERE MaKhenThuong = @MaKhenThuong", conn))
            {
                cmd.Parameters.AddWithValue("@MaKhenThuong", maKhenThuong);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

    }
}
