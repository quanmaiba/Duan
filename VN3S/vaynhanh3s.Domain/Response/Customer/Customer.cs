namespace vaynhanh3s.Domain.Response.Customer
{
    public class Customer
    {
        public long Id { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCMND { get; set; }
        public int TinhThanhId { get; set; }
        public string TinhThanh { get; set; }
        public int DieuKienVayId { get; set; }
        public string DieuKienVay { get; set; }
        public string NgayDangKy { get; set; }
        public bool DaXuatRaExcel { get; set; }
    }
}
