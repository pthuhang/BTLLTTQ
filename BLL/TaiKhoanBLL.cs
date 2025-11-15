using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();
        public string TaoMaTK(string maNV)
        {
            return dal.TaoMaTaiKhoan(maNV);
        }
        //
        public DataRow DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            DataRow row = dal.KiemTraDangNhap(tenDangNhap, matKhau);
            return row;
        }
        //
        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachTaiKhoan();
        }
        public DataTable LayTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            return dal.LayTaiKhoanTheoTenDangNhap(tenDangNhap);
        }
        //
        public bool KiemTraNhanVien(string maNV)
        {
            return dal.KiemTraNhanVienTonTai(maNV);
        }
        public bool KiemTraTonTai(string maNV)
        {
            return dal.KiemTraTonTaiTaiKhoan(maNV);
        }
        public bool KiemTraTenDangNhap(string tenDangNhap, string maNguoiDungHienTai = null)
        {
            return dal.KiemTraTonTaiTenDangNhap(tenDangNhap, maNguoiDungHienTai);
        }
        //
        public void Them(string maND, string tenDN, string matKhau, string maNV, string vaiTro)
        {
            dal.Them(maND, tenDN, matKhau, maNV, vaiTro);
        }

        public void CapNhat(string maND, string tenDN, string matKhau, string maNV, string vaiTro)
        {
            dal.Sua(maND, tenDN, matKhau, maNV, vaiTro);
        }

        public void Xoa(string maND)
        {
            dal.Xoa(maND);
        }
        public bool UpdateOne(string maNguoiDung, string maNhanVien, string tenDangNhap, string matKhau, string vaiTro)
        {
            return dal.UpdateOne(maNguoiDung, maNhanVien, tenDangNhap, matKhau, vaiTro);
        }
        public bool CapNhatTaiKhoan(string tenDangNhap, string matKhau, string vaiTro)
        {
            return dal.CapNhatTaiKhoan(tenDangNhap, matKhau, vaiTro);
        }
    
    }
}
