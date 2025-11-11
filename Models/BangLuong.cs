using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.Models
{
    public class BangLuong
    {
        public string MaBangLuong { get; set; }
        public string MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public float SoNgayCong { get; set; }
        public float SoGioTangCa { get; set; }
        public decimal TongPhuCap { get; set; }
        public decimal TongThuong { get; set; }
        public decimal TongPhat { get; set; }
        public decimal LuongCoBan { get; set; }
        public float HeSoLuong { get; set; }
        public decimal LuongThucLinh { get; set; }
    }
}
