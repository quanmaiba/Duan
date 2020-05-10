using QLNV.Domain;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System;
using System.Collections.Generic;

namespace QLNV.DAL.Interface
{
    public interface IPhongBanRepository
    {
        IList<PhongBan> DanhSachPhongBan();
        PhongBan LayPhongBanID(int Id);
        int TaoPhongBan(TaoPhongBan request);
        int SuaPhongBan(SuaPhongBan request);
        bool XoaPhongBan(int Id);
    }
}
