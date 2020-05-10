using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLNV.Web.Models.PhongBan
{
    public class SuaPhongBan
    {
        public int ID { get; set; }
        [Display(Name = "Mã Phòng ban")]
        [Required(ErrorMessage = "Bạn phải nhập mã Phòng ban")]
        [StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "Mã phòng ban phải có 5 ký tự")]
        [ReadOnly(true)]
        public string MaPhongBan { get; set; }
        [Display(Name = "Tên Phòng ban")]
        [Required(ErrorMessage = "Bạn phải nhập tên Phòng ban")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Tên phòng ban phải từ 1 đến 50 ký tự")]
        public string TenPhongBan { get; set; }
    }
}
