using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class KiLuatBLL
    {
        private KiLuatDAL dal = new KiLuatDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachKiLuat();
        }

        public void Them(string maKiLuat, string noiDung, decimal soTien)
        {
            dal.Them(maKiLuat,  noiDung, soTien);
        }

        public void CapNhat(string ma, string noiDung, decimal soTien)
        {
            dal.Sua(ma,  noiDung, soTien);
        }

        public void Xoa(string maKL)
        {
            dal.Xoa(maKL);
        }
        public bool KiemTraTrungMa(string maKiLuat)
        {
            return dal.TonTaiMaKiLuat(maKiLuat);
        }

    }
}
