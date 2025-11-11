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

        // Thêm kỷ luật cho nhân viên
        public void Them(string maKhenThuong, string maNV, DateTime ngayKhenThuong, decimal tienKhenThuong)
        {
            dal.ThemKLNV(maKhenThuong, maNV, ngayKhenThuong, tienKhenThuong);
        }

        // Sửa chi tiết kỷ luật của nhân viên
        public void CapNhat(string maKhenThuong, string maNV, DateTime ngayMoi, decimal tienMoi)
        {
            dal.SuaChiTiet(maKhenThuong, maNV, ngayMoi, tienMoi);
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
