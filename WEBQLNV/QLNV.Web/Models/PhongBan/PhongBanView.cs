using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLNV.Web.Models.PhongBan
{
    public class PhongBanView
    {
        public int ID { get; set; }
        [Display(Name ="Mã Phòng ban")]
        public string MaPhongBan { get; set; }
        [Display(Name = "Tên Phòng ban")]
        public string TenPhongBan { get; set; }
        [Display(Name = "Tổng số Nhân viên")]
        public int TongSoNhanVien { get; set; }
    }
}
