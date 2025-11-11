using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class TangCa_NhanVienBLL
    {
        private TangCa_NhanVienDAL tcnv = new TangCa_NhanVienDAL();

        public DataTable LayDanhSach()
        {
            return tcnv.LayDanhSach();
        }

        public void Them(string maTangCa, string maNV, int soGioTangCa)
        {
            tcnv.Them(maTangCa, maNV, soGioTangCa);
        }

        public bool KiemTraTonTai(string maTangCa, string maNV)
        {
            return tcnv.KiemTraTonTai(maTangCa, maNV);
        }

        public void Sua(string maTangCa, string maNV, int soGioMoi)
        {
            tcnv.Sua(maTangCa, maNV, soGioMoi);
        }

        public void Xoa(string maTangCa, string maNV)
        {
            tcnv.XoaVaCapNhatTangCa(maTangCa, maNV);
        }
    }
}
