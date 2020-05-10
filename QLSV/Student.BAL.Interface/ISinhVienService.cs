using Student.Domain.Request.SinhVien;
using Student.Domain.Response.SinhVien;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.BAL.Interface
{
    public interface ISinhVienService
    {
        LuuSinhVienRes LuuSinhVien(LuuSinhVienReq luuSinhVienReq);
        XoaSinhVienRes XoaSinhVien(XoaSinhVienReq xoaSinhVienReq);
        LaySVTheoIdRes LaySVTheoId(LaySVTheoIdReq laySVTheoIdReq);

    }
}
