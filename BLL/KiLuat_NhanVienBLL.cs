using QUANLYNHANSU.DAL;
using System;
using System.Data;

namespace QUANLYNHANSU.BLL
{
    public class KiLuat_NhanVienBLL
    {
        private KiLuat_NhanVienDAL dal = new KiLuat_NhanVienDAL();

        // Lấy danh sách kỷ luật của nhân viên
        public DataTable LayDanhSach()
        {
            return dal.LayDanhSach();
        }

        // Thêm kỷ luật cho nhân viên
        public void Them(string maKL, string maNV, DateTime ngayKL, decimal tienPhat)
        {
            dal.ThemKLNV(maKL, maNV, ngayKL, tienPhat);
        }

        // Sửa chi tiết kỷ luật của nhân viên
        public void CapNhat(string maKL, string maNV, DateTime ngayMoi, decimal tienMoi)
        {
            dal.SuaChiTiet(maKL, maNV, ngayMoi, tienMoi);
        }

        // Xóa kỷ luật của nhân viên
        public void Xoa(string maKL, string maNV)
        {
            dal.Xoa(maKL, maNV);
        }
        public bool KiemTraTrung(string maKL, string maNV)
        {
            return dal.TonTaiKiLuatNhanVien(maKL, maNV);
        }

    }
}
