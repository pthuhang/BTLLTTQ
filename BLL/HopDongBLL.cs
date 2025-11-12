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

        public DataTable LayHopDong(string tenDangNhap)
        {
            return dal.LayHopDongTheoTenDangNhap(tenDangNhap);
        }
        public void Them(string maHD, string thoiHan, DateTime ngayBD, DateTime ngayKT,string noiDung, string lanKi, float heSoLuong, decimal luongCB, string maNV)
        {
            dal.Them(maHD, thoiHan, ngayBD, ngayKT, noiDung, lanKi, heSoLuong, luongCB, maNV);
        }

        public void CapNhat(string maHD, string thoiHan, DateTime ngayBD, DateTime ngayKT, string noiDung, string lanKi, float heSoLuong, decimal luongCB, string maNV)
        {
            dal.Sua(maHD, thoiHan, ngayBD, ngayKT, noiDung, lanKi, heSoLuong, luongCB, maNV);

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
