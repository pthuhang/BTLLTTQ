using QUANLYNHANSU.DAL;
using System;
using System.Data;

namespace QUANLYNHANSU.BLL
{
    public class HopDongBLL
    {
        private HopDongDAL dal = new HopDongDAL();

        public DataTable LayDanhSach() => dal.LayDanhSachHopDong();

        public bool TonTaiNV(string maNV)
        {
            return dal.KiemTraMaNVTonTai(maNV);
        }

        public void Them(string maHD, string thoiHan, DateTime ngayBD, DateTime ngayKT, decimal luongcb, float heSoLuong, string maNV)
        {
            dal.Them(maHD, thoiHan, ngayBD, ngayKT, luongcb, heSoLuong, maNV);
        }

        public void CapNhat(string maHD, string thoiHan, DateTime ngayBD, DateTime ngayKT, decimal luongcb, float heSoLuong, string maNV)
        {
            dal.Sua(maHD, thoiHan, ngayBD, ngayKT, luongcb, heSoLuong, maNV);
        }

        public void Xoa(string maHD) => dal.Xoa(maHD);
        public DataTable TimKiemHopDong(string maHopDong, string maNV)
        {
            return dal.TimKiemHopDong(maHopDong, maNV);
        }
        public DataTable LayHopDongSapHetHan(int soNgay)
        {
            return dal.LayHopDongSapHetHan(soNgay);
        }

    }
}
