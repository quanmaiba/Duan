using QLSV.Domain.Request.GiaoVien;
using QLSV.Domain.Response.GiaoVien;
using System.Collections.Generic;

namespace QLSV.BAL_Interface
{
    public interface IGiaoVienService
    {
        LuuGiaoVienRes LuuGiaoVien(LuuGiaoVienReq luuGiaoVienReq);
        IList<GiaoVienItem> LayDanhSachGiaoVien();
        GiaoVienItem LayGiaoVien(int giaoVienId);
        int XoaGiaoVien(int giaoVienId);
    }
}
