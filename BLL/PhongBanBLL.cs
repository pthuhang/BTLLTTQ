using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class PhongBanBLL
    {
        private PhongBanDAL dal = new PhongBanDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachPhongBan();
        }
        public DataTable LayNhanVienTheoMa(string ma)
        {
            return dal.LayNhanVienTheoMaPhongBan(ma);
        }
        //
        public bool KiemTraTonTaiMa(string maPB)
        {
            return dal.KiemTraTonTaiMa(maPB);
        }
        public bool KiemTraTonTaiTen(string maPB, string tenPB)
        {
            return dal.KiemTraTonTaiTen(maPB, tenPB);
        }
        //
        public void Them(string maPB, string tenPB, string tenTP)
        {
            dal.Them(maPB, tenPB, tenTP);
        }
        public void CapNhat(string maPB, string tenPB, string tenTP)
        {
            dal.Sua(maPB, tenPB, tenTP);
        }
        public void Xoa(string maPB)
        {
            dal.Xoa(maPB);
        }
    }
}
