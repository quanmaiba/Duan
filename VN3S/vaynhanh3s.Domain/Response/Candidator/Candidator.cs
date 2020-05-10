using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaynhanh3s.Domain.Response.Candidator
{
    public class Candidator
    {
        public long Id { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCMND { get; set; }
        public int TinhThanhId { get; set; }
        public string TinhThanh { get; set; }
        public int ViTriId { get; set; }
        public string ViTri { get; set; }
        public string NgayDangKy { get; set; }
        public bool DaXuatRaExcel { get; set; }
    }
}
