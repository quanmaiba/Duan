using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLNV.Web.Models.NhanVien
{
    public class SuaNhanVien
    {
        public int MaNV { get; set; }
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Bạn phải nhập họ của nhân viên")]
        public string Ho { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bạn phải nhập tên nhân viên")]
        public string Ten { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Số điện thoại")]
        [StringLength(maximumLength: 15, MinimumLength = 10, ErrorMessage = "Số điện thoại từ 10 đến 15 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string DienThoai { get; set; }
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Phòng ban")]
        public int PhongBanId { get; set; }
    }
}
