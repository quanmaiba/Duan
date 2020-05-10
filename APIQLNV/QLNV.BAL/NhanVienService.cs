using QLNV.BAL.Interface;
using QLNV.DAL.Interface;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System;
using System.Collections.Generic;

namespace QLNV.BAL
{
    public class NhanVienService : INhanVienService
    {
        private INhanVienRepository _nhanVienRepository;
        public NhanVienService(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }

        public IList<NhanVien> DanhSachNhanVienThepPhongBan(int phongBanId)
        {
            return _nhanVienRepository.DanhSachNhanVienThepPhongBan(phongBanId);
        }

        public NhanVien LayNhanVienTheoID(int maNV)
        {
            return _nhanVienRepository.LayNhanVienTheoID(maNV);
        }

        public int SuaNhanVien(SuaNhanVien request)
        {
            return _nhanVienRepository.SuaNhanVien(request);
        }

        public int TaoNhanVien(TaoNhanVien request)
        {
            return _nhanVienRepository.TaoNhanVien(request);
        }

        public bool XoaNhanVien(int maNV)
        {
            return _nhanVienRepository.XoaNhanVien(maNV);
        }
    }
}
