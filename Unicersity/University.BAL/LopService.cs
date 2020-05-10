using System;
using System.Collections.Generic;
using University.BAL.Interface;
using University.DAL.Interface;
using University.Domain.Request.Lop;
using University.Domain.Response.Lop;

namespace University.BAL
{
    public class LopService : ILopService
    {
        private readonly ILopRepository lopRepository;

        public LopService(ILopRepository _lopRepository)
        {
            lopRepository = _lopRepository;
        }

        public IList<LopItem> LayDanhSachLop()
        {
            return lopRepository.LayDanhSachLop();
        }

        public LuuLopRes LuuLop(LuuLopReq luuLopReq)
        {
            return lopRepository.LuuLop(luuLopReq);
        }
    }
}
