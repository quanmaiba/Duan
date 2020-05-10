using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaynhanh3s.Domain.Response.DieuKienVay
{
    public class DieuKienVay
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public bool DangHoatDong { get; set; }
        public bool DaXoa { get; set; }
        public string TrangThai => DangHoatDong ? "Đang hoạt động" : "Ngưng hoạt động";
    }
}
