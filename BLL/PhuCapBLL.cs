using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class PhuCapBLL
    {
        private PhuCapDAL dal = new PhuCapDAL();

        public DataTable LayDanhSachPC()
        {
            return dal.LayDanhSachPhuCap();
        }

        public void Them(string maPC, string tenPC, decimal tienPC)
        {
            dal.Them(maPC, tenPC, tienPC);
        }

        public void Sua(string maPC, string tenPC, decimal tienPC)
        {
            dal.Sua(maPC, tenPC, tienPC);
        }

        public void Xoa(string maPC)
        {
            dal.Xoa(maPC);
        }
    }
}
