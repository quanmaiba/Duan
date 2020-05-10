using System;

namespace QLSV.Domain.Request.GiaoVien
{
    public class LuuGiaoVienReq
    {
        public int GiaoVienId { get; set; }
        public string HoTenGV { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime DOB { get; set; }
        public string Img { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
    }
}
