using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAL
{
    public class BangLuongDAL : DBConnection
    {
        public DataTable LayDanhSach()
        {
            string sql = "SELECT * FROM BangLuong";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Them(string maBL, string maNV, decimal luongCB, decimal tongPC, decimal tongKT, decimal tongKL, decimal thucLinh, DateTime thang)
        {
            string sql = @"INSERT INTO BangLuong VALUES(@MaBL, @MaNV, @LuongCB, @TongPC, @TongKT, @TongKL, @ThucLinh, @Thang)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaBL", maBL);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@LuongCB", luongCB);
            cmd.Parameters.AddWithValue("@TongPC", tongPC);
            cmd.Parameters.AddWithValue("@TongKT", tongKT);
            cmd.Parameters.AddWithValue("@TongKL", tongKL);
            cmd.Parameters.AddWithValue("@ThucLinh", thucLinh);
            cmd.Parameters.AddWithValue("@Thang", thang);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }

        public void Sua(string maBL, string maNV, decimal luongCB, decimal tongPC, decimal tongKT, decimal tongKL, decimal thucLinh, DateTime thang)
        {
            string sql = @"UPDATE BangLuong SET MaNV=@MaNV, LuongCB=@LuongCB, TongPhuCap=@TongPC,
                           TongKhenThuong=@TongKT, TongKyLuat=@TongKL, ThucLinh=@ThucLinh, ThangLuong=@Thang
                           WHERE MaBangLuong=@MaBL";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaBL", maBL);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@LuongCB", luongCB);
            cmd.Parameters.AddWithValue("@TongPC", tongPC);
            cmd.Parameters.AddWithValue("@TongKT", tongKT);
            cmd.Parameters.AddWithValue("@TongKL", tongKL);
            cmd.Parameters.AddWithValue("@ThucLinh", thucLinh);
            cmd.Parameters.AddWithValue("@Thang", thang);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }

        public void Xoa(string maBL)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM BangLuong WHERE MaBangLuong=@MaBL", conn);
            cmd.Parameters.AddWithValue("@MaBL", maBL);
            conn.Open(); cmd.ExecuteNonQuery(); conn.Close();
        }
    }
}
