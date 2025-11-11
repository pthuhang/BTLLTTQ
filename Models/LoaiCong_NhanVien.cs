using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.Models
{
    public class LoaiCong_NhanVien
    {
        public string MaLoaiCong { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayLam { get; set; }
        public TimeSpan GioVao { get; set; }
        public TimeSpan GioRa { get; set; }
        public decimal HeSoCong { get; set; }
    }
}
