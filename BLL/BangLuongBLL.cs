using QUANLYNHANSU.DAL;
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

        public decimal TinhLuongThucLinh(string maNV)
        {
            DataRow hd = dal.LayThongTinHD(maNV);
            if (hd == null)
                throw new Exception("Không tìm thấy hợp đồng cho nhân viên này.");

            // ✅ Kiểm tra giá trị NULL trước khi ép kiểu
            decimal luongCoBan = hd["LuongCoBan"] == DBNull.Value ? 0 : Convert.ToDecimal(hd["LuongCoBan"]);
            decimal heSoLuong = hd["HeSoLuong"] == DBNull.Value ? 1 : Convert.ToDecimal(hd["HeSoLuong"]);

            decimal tongPhuCap = dal.TinhTongPhuCap(maNV);
            decimal tongThuong = dal.TinhTongThuong(maNV);
            decimal tongPhat = dal.TinhTongPhat(maNV);
            decimal mucBaoHiem = dal.LayMucDongBH(maNV);

            decimal luongThucLinh = (luongCoBan * heSoLuong + tongPhuCap + tongThuong - tongPhat) - mucBaoHiem;
            return luongThucLinh;
        }

        public bool TaoBangLuong(string maNV, int thang, int nam)
        {
            // Nếu bảng lương đã tồn tại thì không tạo lại
            if (dal.KiemTraBangLuong(maNV, thang, nam))
                return false;

            // 1️⃣ Lấy dữ liệu cần thiết
            decimal tongPhuCap = dal.TinhTongPhuCap(maNV);
            decimal tongThuong = dal.TinhTongThuong(maNV);
            decimal tongPhat = dal.TinhTongPhat(maNV);

            // 2️⃣ Lấy thông tin hợp đồng
            DataRow hd = dal.LayThongTinHD(maNV);
            if (hd == null)
                throw new Exception("Không tìm thấy hợp đồng cho nhân viên này.");

            decimal luongCoBan = Convert.ToDecimal(hd["LuongCoBan"]);
            float heSoLuong = Convert.ToSingle(hd["HeSoLuong"]);

            // 3️⃣ Lấy mức đóng bảo hiểm
            decimal mucBaoHiem = dal.LayMucDongBH(maNV);

            // 4️⃣ Tính lương thực lĩnh
            decimal luongThucLinh = (luongCoBan * (decimal)heSoLuong + tongPhuCap + tongThuong - tongPhat) - mucBaoHiem;

            // 5️⃣ Sinh mã bảng lương tự động
            string maBangLuong = dal.TaoMaBangLuongMoi();

            // 6️⃣ Lưu xuống CSDL
            dal.Them(maBangLuong, maNV, thang, nam,
                     0, 0, // SoNgayCong, SoGioTangCa — có thể cập nhật sau
                     tongPhuCap, tongThuong, tongPhat,
                     luongCoBan, heSoLuong, luongThucLinh);

            return true;
        }


        //public void Them(string maBL, string maNV, decimal luongCB, decimal tongPC, decimal tongKT, decimal tongKL, decimal thucLinh, DateTime thang)
        //{
        //    dal.Them(maBL, maNV, luongCB, tongPC, tongKL, tongKT, thucLinh, thang);
        //}

        //public void CapNhat(string maBL, string maNV, decimal luongCB, decimal tongPC, decimal tongKT, decimal tongKL, decimal thucLinh, DateTime thang)
        //{
        //    dal.Sua(maBL, maNV, luongCB, tongPC, tongKL, tongKT, thucLinh, thang);
        //}

        //public void Xoa(string maBL)
        //{
        //    dal.Xoa(maBL);
        //}
    }
}
