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

        public bool DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return false;

            DataRow row = dal.KiemTraDangNhap(tenDangNhap, matKhau);
            return row != null;
        }
        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachTaiKhoan();
        }

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
    }
}
