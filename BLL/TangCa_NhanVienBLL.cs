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
        public DataTable LayTCNhanVienTheoMa(string maNV)
        {
            return tcnv.LayTangCaTheoNV(maNV);
        }
        public DataTable LayTangCa(int thang, int nam, string maNV )
        {
            return tcnv.LayTangCaTheoThangNam(thang, nam, maNV);
        }
        public void Them(string maNV, int soGioTangCa, DateTime ngayTangCa)
        {
            tcnv.Them(maNV, soGioTangCa, ngayTangCa);
        }

        public bool KiemTraTonTai(DateTime ngayTangCa, string maNV)
        {
            return tcnv.KiemTraTonTai(ngayTangCa, maNV);
        }

        public void Sua(string maNV, DateTime ngayTC, int soGioMoi)
        {
            tcnv.Sua(maNV, ngayTC, soGioMoi);
        }

        public void Xoa(DateTime ngayTangCa, string maNV)
        {
            tcnv.XoaVaCapNhatTangCa(ngayTangCa, maNV);
        }
    }
}
