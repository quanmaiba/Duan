using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLNV.Web.Models.NhanVien
{
    public class TaoNhanVien
    {
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Bạn phải nhập họ của nhân viên")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Họ của nhân viên phải có từ 1 đến 20 ký tự")]
        public string Ho { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bạn phải nhập tên của nhân viên")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Tên của nhân viên phải có từ 1 đến 20 ký tự")]
        public string Ten { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ của nhân viên")]
        [StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage = "Địa chỉ không quá 250 ký tự")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại của nhân viên")]
        [StringLength(maximumLength: 20, MinimumLength = 10, ErrorMessage = "Số điện thoại phải từ 10 đến 15 ký tự")]
        [Phone(ErrorMessage = "Số điện không đúng định dạng")]
        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Phòng ban")]
        public int PhongBanId { get; set; }
    }
}
