using QUANLYNHANSU.DAL;
using QUANLYNHANSU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BLL
{
    public class BangLuongBLL
    {
        private BangLuongDAL dal = new BangLuongDAL();

        public DataTable LayDanhSachBangLuong()
        {
            return dal.LayDanhSach();
        }
        public DataTable LayBangLuongNhanVien(string mnv)
        {
            return dal.LayDanhSachTheoMa(mnv);
        }
        public decimal TinhLuongThucLinh(string maNV, int thang, int nam)
        {
            DataRow hd = dal.LayThongTinHD(maNV);
            if (hd == null)
                throw new Exception("Không tìm thấy hợp đồng cho nhân viên này.");

            // ✅ Kiểm tra giá trị NULL trước khi ép kiểu
            decimal luongCoBan = hd["LuongCoBan"] == DBNull.Value ? 0 : Convert.ToDecimal(hd["LuongCoBan"]);
            decimal heSoLuong = hd["HeSoLuong"] == DBNull.Value ? 1 : Convert.ToDecimal(hd["HeSoLuong"]);

            decimal tongTangCa = dal.TinhSoGioTangCa(maNV, thang, nam);
            decimal tongCong = dal.TinhSoNgayCong(maNV, thang, nam);

            decimal tongPhuCap = dal.TinhTongPhuCap(maNV);
            decimal mucBaoHiem = dal.LayMucDongBH(maNV);

            decimal tongThuong = dal.TinhTongThuong(maNV, thang, nam);
            decimal tongPhat = dal.TinhTongPhat(maNV, thang, nam);

            decimal tienTangCa = (tongTangCa / 8) * 250000;

            decimal luongThucLinh = (luongCoBan * heSoLuong + tongPhuCap + tongThuong - tongPhat + tienTangCa) - mucBaoHiem;
            return luongThucLinh;
        }

        public bool TaoBangLuong(string maNV, int thang, int nam)
        {
            if (dal.KiemTraBangLuong(maNV, thang, nam))
                return false;

            decimal tongPhuCap = dal.TinhTongPhuCap(maNV);
            decimal tongThuong = dal.TinhTongThuong(maNV, thang, nam);
            decimal tongPhat = dal.TinhTongPhat(maNV, thang, nam);
            decimal soGioTangCa = dal.TinhSoGioTangCa(maNV, thang, nam);
            decimal soNgayCong = dal.TinhSoNgayCong(maNV, thang, nam);

            DataRow hd = dal.LayThongTinHD(maNV);
            if (hd == null)
                throw new Exception("Không tìm thấy hợp đồng cho nhân viên này.");

            decimal luongCoBan = Convert.ToDecimal(hd["LuongCoBan"]);
            float heSoLuong = Convert.ToSingle(hd["HeSoLuong"]);

            decimal mucBaoHiem = dal.LayMucDongBH(maNV);

            decimal luongThucLinh = TinhLuongThucLinh(maNV, thang, nam);

            string maBangLuong = TaoMaBangLuongMoi(maNV, thang, nam);

            dal.Them(maBangLuong, maNV, thang, nam,
                     soNgayCong, soGioTangCa,
                     tongPhuCap, tongThuong, tongPhat,
                     luongCoBan, heSoLuong, luongThucLinh);

            return true;
        }
        private string TaoMaBangLuongMoi(string maNV, int thang, int nam)
        {
            string maNVSuffix = maNV.Length >= 2 ? maNV.Substring(maNV.Length - 2) : maNV.PadLeft(2, '0');
            string maBangLuong = $"BL{maNVSuffix}{thang:D2}{nam % 100:D2}";
            return maBangLuong;
        }


    }
}
