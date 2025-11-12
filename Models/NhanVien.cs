using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.Models
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string TrangThai { get; set; }
        public string MaPhongBan { get; set; }
        public string MaTrinhDo { get; set; }
        public string ChucVu { get; set; }
        public decimal LuongCoBan { get; set; }
        public string SoBaoHiemXaHoi { get; set; }
        public decimal MucDong { get; set; }
        public string SoTaiKhoan { get; set; }
    }
}
