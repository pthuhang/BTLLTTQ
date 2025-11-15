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
        public DataTable LayNhanVienTheoTenDangNhap(string tenDangNhap)
        {
            return dal.LayNhanVienTheoTenDangNhap(tenDangNhap);
        }
        //Tạo  mã nhân vien mới
        public string SinhMaNhanVienMoi()
        {
            string maxMa = dal.LayMaNhanVienLonNhat();  // "NV0123"

            if (maxMa == null)
                return "NV0001";

            int number = int.Parse(maxMa.Substring(2));
            number++;

            return "NV" + number.ToString("D4"); 
        }

        public bool KiemTraTonTai(string cot, string giaTri)
        {
            return dal.KiemTraTonTai(cot, giaTri);
        }
        public DataRow KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            return dal.KiemTraDangNhap(tenDangNhap, matKhau);
        }
        public void Them(string maNV, string hoTen, bool gioiTinh, DateTime ngaySinh,
                         string sdt, string cccd, string diaChi, string email, string trangThai,
                         string maPhongBan, string maTrinhDo, string chucVu,
                         string soBHXH, decimal mucDong, string soTaiKhoan)
        {
            dal.Them(maNV, hoTen, gioiTinh, ngaySinh, sdt, cccd, diaChi, email, trangThai,
                     maPhongBan, maTrinhDo, chucVu, soBHXH, mucDong, soTaiKhoan);
        }

        public void CapNhat(string maNV, string hoTen, bool gioiTinh, DateTime ngaySinh,
                            string sdt, string cccd, string diaChi, string email, string trangThai,
                            string maPhongBan, string maTrinhDo, string chucVu,
                            string soBHXH, decimal mucDong, string soTaiKhoan)
        {
            dal.Sua(maNV, hoTen, gioiTinh, ngaySinh, sdt, cccd, diaChi, email, trangThai,
                    maPhongBan, maTrinhDo, chucVu, soBHXH, mucDong, soTaiKhoan);
        }
        public void Xoa(string maNV)
        {
            dal.Xoa(maNV);
        }
        public DataTable TimKiem(string maNVTimKiem, string hoTenTimKiem)
        {
            return dal.TimKiem(maNVTimKiem, hoTenTimKiem);
        }
        
        //lấy item cho combobox
        
        public DataTable LayDanhSachChucVu()
        {
            return dal.LayDanhSachChucVu();
        }
        //Lọc
        public DataTable LocTheoTrinhDo(string tenTrinhDo)
        {
            return dal.LocTheoTrinhDo(tenTrinhDo);
        }
        public DataTable LocTheoGioiTinh(string gioiTinh)
        {
            return dal.LocTheoGioiTinh(gioiTinh);
        }
        public DataTable LocTheoChucVu(string chucVu)
        {
            return dal.LocTheoChucVu(chucVu);
        }
        public DataTable LayNhanVienTheoPhongBan(string maPhongBan)
        {
            return dal.LayNhanVienTheoPhongBan(maPhongBan);
        }
        public DataTable LocTheoTrangThai(string trangThai)
        {
            return dal.LocTheoTrangThai(trangThai);
        }

    }
}
