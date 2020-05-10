using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Domain.Response
{
    public class PhongBan
    {
        public int ID { get; set; }
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public int TongSoNhanVien { get; set; }
    }
}
