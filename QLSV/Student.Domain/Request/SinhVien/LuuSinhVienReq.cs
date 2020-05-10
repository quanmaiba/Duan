using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Domain.Request.SinhVien
{
    public class LuuSinhVienReq
    {
        public int SinhVienId { get; set; }
        public string TenSV { get; set; }
        public string QueQuan { get; set; }
        public int GioiTinh { get; set; }
        public int LopId { get; set; }
    }
}
