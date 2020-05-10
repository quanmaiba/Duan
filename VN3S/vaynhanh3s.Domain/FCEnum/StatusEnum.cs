using System.ComponentModel;

namespace vaynhanh3s.Domain.TTEnum
{
    public enum TrangThaiDonHang : int
    {
        [Description("Mới")]
        Moi = 1,
        [Description("Đã liên hệ")]
        DaLienHe = 2,
        [Description("Đang vận chuyển")]
        DangVanChuyen = 3,
        [Description("Hủy")]
        Huy = 4
    }

    public enum Quyen : int
    {
        QuanTri = 1,
        KhachHang = 2,
        BienTap = 3,
        Xem = 4
    }
}
