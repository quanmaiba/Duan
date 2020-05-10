using System;
using System.Collections.Generic;
using System.Text;
using University.Domain.Request.Lop;
using University.Domain.Response.Lop;

namespace University.DAL.Interface
{
    public interface ILopRepository
    {
        LuuLopRes LuuLop(LuuLopReq luuLopReq);
        IList<LopItem> LayDanhSachLop();
    }
}
