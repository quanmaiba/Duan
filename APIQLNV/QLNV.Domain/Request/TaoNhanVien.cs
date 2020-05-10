using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Domain.Request
{
    public class TaoNhanVien
    {
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public int PhongBanId { get; set; }
    }
}
