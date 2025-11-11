using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class KhenThuongBLL
    {
        private KhenThuongDAL dal = new KhenThuongDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayDanhSachKhenThuong();
        }

        public void Them(string maKhenThuong, string noiDung, decimal soTien)
        {
            dal.Them(maKhenThuong, noiDung, soTien);
        }

        public void CapNhat(string maKhenThuong, string noiDung, decimal soTien)
        {
            dal.Sua(maKhenThuong, noiDung, soTien);
        }

        public void Xoa(string maKhenThuong)
        {
            dal.Xoa(maKhenThuong);
        }
        public bool KiemTraTrungMa(string maKhenThuong)
        {
            return dal.TonTaiMaKhenThuong(maKhenThuong);
        }

    }
}
