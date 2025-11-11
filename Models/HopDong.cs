using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.Models
{
    public class HopDong
    {
        public string MaHopDong { get; set; }
        public string ThoiHan { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string NoiDung { get; set; }
        public int LanKi { get; set; }
        public float HeSoLuong { get; set; }
        public string MaNV { get; set; }
    }
}
