namespace vaynhanh3s.Util
{
    public class GeneralMessage
    {

        public const string SomeThingWentWrong = "Đã có lỗi xảy ra, xin hãy thử lại sau.";
        public const string NoPermission = "Bạn không có quyền thực hiện chức năng này.";
    }

    public class Thuoc
    {

        public const string ThemLoi = "Không thêm được thuốc.";
        public const string SuaLoi = "Không cập nhật được thông tin của thuốc.";
        public const string ThemThanhCong = "Thuốc đã được thêm mới.";
        public const string SuaThanhCong = "Thông tin thuốc đã được cập nhât.";
    }

    public class DanhMuc
    {
        public const string ThemLoi = "Không thêm được danh mục.";
        public const string XoaLoi = "Không xóa được danh mục.";
        public const string ThemThanhCong = "Danh mục đã được thêm mới.";
        public const string XoaThanhCong = "Danh mục đã được xóa.";
        public const string SuaThanhCong = "Danh mục đã được cập nhật.";
        public const string SuaLoi = "Không cập nhật danh mục.";
    }

    public class DanhMucThuoc
    {
        public const string ThemLoi = "Không thêm được thuốc vào danh mục.";
        public const string XoaLoi = "Không xóa được thuốc khỏi danh mục.";
        public const string ThemThanhCong = "Thuốc đã được thêm vào danh mục.";
        public const string XoaThanhCong = "Thuốc đã được xóa ra khỏi danh mục.";
    }
    public class ThanhVien
    {
        public const string XoaThanhCong = "Đã xóa thành viên thành công.";
        public const string XoaThatBai = "Không xóa được thành viên.";
        public const string ThemLoi = "Không tạo được thành viên.";
        public const string ThemThanhCong = "Thành viên đã được tạo thành công.";
        public const string CapNhatThanhCong = "Đã cập nhật thông tin thành công.";
        public const string QuenMatKhauLoi = "Không tạo được mật khẩu mới.";
        public const string QuenMatKhauThanhCong = "Mật khẩu đã được tạo mới, vui lòng kiểm tra hộp thư của bạn.";
        public const string DoiMatKhauLoi = "Không cập nhật được mật khẩu mới.";
        public const string DoiMatKhauThanhCong = "Mật khẩu đã cập nhật thành công.";
        public const string DoiMatKhauSaiMatKhau = "Mật khẩu cũ không đúng.";
        public const string DangNhapLoi = "Email hoặc mật khẩu không đúng.";
    }

    public class EmailMessage
    {
        public const string KhongGoiEmail = "Không thể gởi mail.";
        public const string EmailTonTai = "Email đã tồn tại.";
        public const string EmailChuaTonTai = "Email không tồn tại.";
    }

    public class BlogMessage
    {
        public const string ThemLoi = "Không thêm được bản tức.";
        public const string XoaLoi = "Không xóa được bản tin.";
        public const string ThemThanhCong = "Bản tin đã được thêm mới.";
        public const string XoaThanhCong = "Bản tin đã được xóa.";
        public const string SuaThanhCong = "Bản tin đã được cập nhật.";
        public const string SuaLoi = "Không cập nhật được bản tin.";
    }

    public class DonHang
    {
        public const string DonHangKhongTonTai = "Đơn hàng không tồn tại, vui lòng liên hệ với quản trị viên.";
        public class TrangThaiDonHang
        {
            public const string CapNhatThanhCong = "Đơn hàng đã được cập nhật trạng thái thành công.";
            public const string CapNhatLoi = "Đã xảy ra lỗi khi cập nhật trạng thái đơn hàng.";
            public const string TaoLoi = "Đã xảy ra lỗi khi tạo trạng thái đơn hàng.";
        }
        public class TaoDonHang
        {
            public const string TaoThanhCong = "Đơn hàng đã được tạo trạng thái thành công.";
            public const string TaoLoi = "Đã xảy ra lỗi khi tạo đơn hàng.";
        }
        public class CapNhatDonHang
        {
            public const string HoanTatDonHang = "Đơn hàng đã hoàn tất.";
            public const string CapNhatDonHangLoi = "Đã xảy ra lỗi khi cập nhật đơn hàng.";
            public const string HuyDonHang = "Đơn hàng đã được hủy thành công.";
            public const string CapNhatThanhCong = "Đơn hàng đã được cập nhật thành công.";
            public const string XoaDonHang = "Đơn hàng đã được xóa thành công.";
        }
        public class TaoNguoiNhanHang
        {
            public const string TaoLoi = "Đã xảy ra lỗi khi tạo thông tin người nhận hàng.";
        }
        public class CapNhatNguoiNhanHang
        {
            public const string CapLoi = "Đã xảy ra lỗi khi cập nhật thông tin người nhận hàng.";
        }
        public class TaoDonHangChiTiet
        {
            public const string TaoLoi = "Đã xảy ra lỗi khi tạo chi tiết đơn hàng.";
        }
        public class XoaDonHangChiTiet
        {
            public const string XoaLoi = "Đã xảy ra lỗi khi xóa chi tiết đơn hàng.";
        }
        public class HuyDonHang
        {
            public const string HuyLoi = "Đã xảy ra lỗi khi hủy đơn hàng.";
            public const string KhongCoQuyenHuyLoi = "Bạn không thể hủy đơn hàng này được. Vui lòng liên hệ với quản trị viên.";
            public const string HuyThanhCong = "Đơn hàng đã được hủy thành công.";
        }

        public class Banner
        {
            public const string ActiveSuccess = "Đã kích hoạt banner thành công.";
            public const string DeActiveSuccess = "Đã hủy banner";
            public const string AddSuccess = "Đã tạo mới banner thành công";
            public const string UpdateSuccess = "Đã cập nhật banner thành công";
        }

        public class DoiTac
        {
            public const string ActiveSuccess = "Đã kích hoạt đối tác thành công.";
            public const string DeActiveSuccess = "Đã hủy đối tác";
            public const string AddSuccess = "Đã tạo mới đối tác thành công";
            public const string UpdateSuccess = "Đã cập nhật Đối tác thành công";
        }

    }
}
