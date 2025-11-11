using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachNhanVien();
        }

        public DataTable LayNhanVienTheoMa(string maNV)
        {
            return dal.LayNhanVienTheoMa(maNV);
        }

        public void Them(string maNV, string hoTen, bool gioiTinh, DateTime ngaySinh,
                         string sdt, string cccd, string diaChi, string email, string trangThai,
                         string maPhongBan, string maTrinhDo, string chucVu,
                         decimal luongCoBan, string soBHXH, decimal mucDong, string soTaiKhoan)
        {
            dal.Them(maNV, hoTen, gioiTinh, ngaySinh, sdt, cccd, diaChi, email, trangThai,
                     maPhongBan, maTrinhDo, chucVu, luongCoBan, soBHXH, mucDong, soTaiKhoan);
        }

        public void CapNhat(string maNV, string hoTen, bool gioiTinh, DateTime ngaySinh,
                            string sdt, string cccd, string diaChi, string email, string trangThai,
                            string maPhongBan, string maTrinhDo, string chucVu,
                            decimal luongCoBan, string soBHXH, decimal mucDong, string soTaiKhoan)
        {
            dal.Sua(maNV, hoTen, gioiTinh, ngaySinh, sdt, cccd, diaChi, email, trangThai,
                    maPhongBan, maTrinhDo, chucVu, luongCoBan, soBHXH, mucDong, soTaiKhoan);
        }
        public void Xoa(string maNV)
        {
            dal.Xoa(maNV);
        }
        public DataTable TimKiem(string maNVTimKiem, string hoTenTimKiem)
        {
            return dal.TimKiem(maNVTimKiem, hoTenTimKiem);
        }
        public DataTable LayNhanVienNam()
        {
            return dal.LayNhanVienNam();
        }
        public DataTable LocTheoTrinhDo(string tenTrinhDo)
        {
            return dal.LocTheoTrinhDo(tenTrinhDo);
        }
        public DataTable SapXepTheoLuongGiam()
        {
            return dal.SapXepTheoLuongGiam();
        }
        public DataTable LayNhanVienTheoPhongBan(string maPhongBan)
        {
            return dal.LayNhanVienTheoPhongBan(maPhongBan);
        }
    }
}
