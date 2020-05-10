using QLNV.Domain;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System;
using System.Collections.Generic;

namespace QLNV.DAL.Interface
{
    public interface INhanVienRepository
    {
        IList<NhanVien> DanhSachNhanVienThepPhongBan(int phongBanId);
        NhanVien LayNhanVienTheoID(int maNV);
        int TaoNhanVien(TaoNhanVien request);
        int SuaNhanVien(SuaNhanVien request);
        bool XoaNhanVien(int maNV);
    }
}
