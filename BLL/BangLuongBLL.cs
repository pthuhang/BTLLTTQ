using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class BangLuongBLL
    {
        private BangLuongDAL dal = new BangLuongDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSach();
        }

        public void Them(string maBL, string maNV, decimal luongCB, decimal tongPC, decimal tongKT, decimal tongKL, decimal thucLinh, DateTime thang)
        {
            dal.Them(maBL, maNV, luongCB, tongPC, tongKL, tongKT, thucLinh, thang);
        }

        public void CapNhat(string maBL, string maNV, decimal luongCB, decimal tongPC, decimal tongKT, decimal tongKL, decimal thucLinh, DateTime thang)
        {
            dal.Sua(maBL, maNV, luongCB, tongPC, tongKL, tongKT, thucLinh, thang);
        }

        public void Xoa(string maBL)
        {
            dal.Xoa(maBL);
        }
    }
}
