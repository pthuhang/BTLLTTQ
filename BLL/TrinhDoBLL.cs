using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class TrinhDoBLL
    {
        private TrinhDoDAL dal = new TrinhDoDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachTrinhDo();
        }

        public void Them(string maTD, string tenTD)
        {
            dal.Them(maTD, tenTD);
        }

        public void CapNhat(string maTD, string tenTD)
        {
            dal.Sua(maTD, tenTD);
        }

        public void Xoa(string maTD)
        {
            dal.Xoa(maTD);
        }
    }
}
