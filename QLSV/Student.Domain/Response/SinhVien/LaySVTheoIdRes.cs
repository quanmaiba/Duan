using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Domain.Response.SinhVien
{
    public class LaySVTheoIdRes : BaseResponse
    {
        public int SinhVienId { get; set; }
        public string TenSV { get; set; }
        public string QueQuan { get; set; }
        public int GioiTinh { get; set; }
        public int LopId { get; set; }
    }
}
