using QUANLYNHANSU.DAL;
using QUANLYNHANSU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class PhuCap_NhanVienBLL
    {
        private PhuCap_NhanVienDAL dal = new PhuCap_NhanVienDAL();
        
        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachPhuCapNhanVien();
        }
        public DataTable LayNhanVien(string mnv)
        {
            return dal.LayNhanVienTheoMa(mnv);
        }
        public string LayHoTenNV(string mnv)
        {
            return dal.LayTenNV(mnv);
        }
        public void Them(string maPhuCap, string maNV)
        {
            dal.Them(maPhuCap, maNV);
        }


        public void Xoa(string maPhuCap, string maNV)
        {
            dal.Xoa(maPhuCap, maNV);
        }
    }
}
