using QUANLYNHANSU.DAL;
using System;
using System.Data;

namespace QUANLYNHANSU.BLL
{
    public class Khen_NhanVienBLL
    {
        private KhenThuong_NhanVienDAL dal = new KhenThuong_NhanVienDAL();

        // Lấy danh sách KhenThuong của nhân viên
        public DataTable LayDanhSach()
        {
            return dal.LayDanhSach();
        }
        public DataTable GetKhenThuongByMaNV_ThangNam(string maNV, int thang, int nam)
        {
            return dal.GetKhenThuongByMaNV_ThangNam(maNV, thang, nam);
        }

        // Thêm kỷ luật cho nhân viên
        public void Them(string maKhenThuong, string maNV, DateTime ngayKhenThuong)
        {
            dal.ThemKLNV(maKhenThuong, maNV, ngayKhenThuong);
        }

        // Sửa chi tiết kỷ luật của nhân viên
        public void CapNhat(string maKhenThuong, string maNV, DateTime ngayMoi)
        {
            dal.SuaChiTiet(maKhenThuong, maNV, ngayMoi);
        }

        // Xóa kỷ luật của nhân viên
        public void Xoa(string maKhenThuong, string maNV)
        {
            dal.Xoa(maKhenThuong, maNV);
        }
        public bool KiemTraTrung(string maKhenThuong, string maNV)
        {
            return dal.TonTaiKhenNhanVien(maKhenThuong, maNV);
        }

    }
}
