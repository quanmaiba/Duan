using System;
using System.ComponentModel.DataAnnotations;

namespace QLSV.WEB.Models.GiaoVien
{
    public class LuuGiaoVien
    {
        public int GiaoVienId { get; set; }
        public string HoTenGV { get; set; }
        public bool GioiTinh { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Img { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
    }
}
