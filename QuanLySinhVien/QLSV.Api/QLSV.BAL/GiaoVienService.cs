using QLSV.BAL_Interface;
using QLSV.DAL_Interface;
using QLSV.Domain.Request.GiaoVien;
using QLSV.Domain.Response.GiaoVien;
using System.Collections.Generic;

namespace QLSV.BAL
{
    public class GiaoVienService : IGiaoVienService
    {
        private readonly IGiaoVienRepository giaoVienRepository;

        public GiaoVienService(IGiaoVienRepository _giaoVienRepository)
        {
            giaoVienRepository = _giaoVienRepository;
        }

        public IList<GiaoVienItem> LayDanhSachGiaoVien()
        {
            return giaoVienRepository.LayDanhSachGiaoVien();
        }

        public GiaoVienItem LayGiaoVien(int giaoVienId)
        {
            return giaoVienRepository.LayGiaoVien(giaoVienId);
        }

        public LuuGiaoVienRes LuuGiaoVien(LuuGiaoVienReq luuGiaoVienReq)
        {
            return giaoVienRepository.LuuGiaoVien(luuGiaoVienReq);
        }

        public int XoaGiaoVien(int giaoVienId)
        {
            return giaoVienRepository.XoaGiaoVien(giaoVienId);
        }
    }
}
