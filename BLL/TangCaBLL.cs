using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class TangCaBLL
    {
        private TangCaDAL dal = new TangCaDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachTangCa();
        }

        public void Them(string maTC, DateTime ngayTC)
        {
            dal.Them(maTC, ngayTC);
        }

        public void CapNhat(string maTC, DateTime ngayTC)
        {
            dal.Sua(maTC, ngayTC);
        }

        public bool KiemTraTonTai(string maTangCa)
        {
            return dal.KiemTraTonTai(maTangCa);
        }

        public void Xoa(string maTC)
        {
            dal.Xoa(maTC);
        }
    }
}
