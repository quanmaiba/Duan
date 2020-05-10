using QLSV.Domain.Request.GiaoVien;
using QLSV.Domain.Response.GiaoVien;
using System.Collections.Generic;

namespace QLSV.DAL_Interface
{
    public interface IGiaoVienRepository
    {
        LuuGiaoVienRes LuuGiaoVien(LuuGiaoVienReq luuGiaoVienReq);
        IList<GiaoVienItem> LayDanhSachGiaoVien();
        GiaoVienItem LayGiaoVien(int giaoVienId);
        int XoaGiaoVien(int giaoVienId);

    }
}
