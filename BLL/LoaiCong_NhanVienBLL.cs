using QUANLYNHANSU.DAL;
using QUANLYNHANSU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.BLL
{
    public class LoaiCong_NhanVienBLL
    {
        private LoaiCong_NhanVienDAL lcnv = new LoaiCong_NhanVienDAL();

        public DataTable LayDanhSach ()
        {
            return lcnv.LayDanhSach();
        }

        public void Them (string maLoaiCong, string maNV, DateTime ngayLam, TimeSpan gioVao, TimeSpan gioRa)
        {
            lcnv.Them(maLoaiCong, maNV, ngayLam, gioVao, gioRa);
        }

        public bool KiemTraTonTai(string maLoaiCong, string maNV)
        {
            return lcnv.KiemTraTonTai(maLoaiCong, maNV);
        }

        public void Sua (string maLoaiCong, string maNV, DateTime ngayLam, TimeSpan gioVao, TimeSpan gioRa)
        {
            lcnv.Sua(maLoaiCong, maNV, ngayLam, gioVao, gioRa);
        }

        public void Xoa (string maLoaiCong, string maNV)
        {
            lcnv.XoaVaCapNhatLoaiCong(maLoaiCong, maNV);
        }
        public DataTable LocLoaiCongNV(string maNV, string ngay, string thang, string nam)
        {
            return lcnv.LocLoaiCongNV(maNV, ngay, thang, nam);
        }

    }
}
