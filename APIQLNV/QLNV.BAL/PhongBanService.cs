using QLNV.BAL.Interface;
using QLNV.DAL.Interface;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System;
using System.Collections.Generic;

namespace QLNV.BAL
{
    public class PhongBanService : IPhongBanService
    {
        private IPhongBanRepository _phongBanRepository;
        public PhongBanService (IPhongBanRepository phongBanRepository)
        {
            _phongBanRepository = phongBanRepository;
        }
        public IList<PhongBan> DanhSachPhongBan()
        {
            return _phongBanRepository.DanhSachPhongBan();
        }

        public PhongBan LayPhongBanID(int Id)
        {
            return _phongBanRepository.LayPhongBanID(Id);
        }

        public int SuaPhongBan(SuaPhongBan request)
        {
            return _phongBanRepository.SuaPhongBan(request);
        }

        public int TaoPhongBan(TaoPhongBan request)
        {
            return _phongBanRepository.TaoPhongBan(request);
        }

        public bool XoaPhongBan(int Id)
        {
            return _phongBanRepository.XoaPhongBan(Id);
        }
    }
}
