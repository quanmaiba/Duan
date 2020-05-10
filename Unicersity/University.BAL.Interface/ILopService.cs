using System;
using System.Collections.Generic;
using University.Domain.Request.Lop;
using University.Domain.Response.Lop;

namespace University.BAL.Interface
{
    public interface ILopService
    {
        LuuLopRes LuuLop(LuuLopReq luuLopReq);
        IList<LopItem> LayDanhSachLop();
    }
}
