using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class LoaiCongBLL
    {
        private LoaiCongDAL dal = new LoaiCongDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachLoaiCong();
        }

        public void Them(string maLC, string tenLC, decimal heSo)
        {
            dal.Them(maLC, tenLC, heSo);
        }

        public bool KiemTraTonTai(string maLC)
        {
            return dal.KiemTraTonTai(maLC);
        }

        public void CapNhat(string maLC, string tenLC, decimal heSo)
        {
            dal.Sua(maLC, tenLC, heSo);
        }

        public void Xoa(string maLC)
        {
            dal.Xoa(maLC);
        }
    }
}
