using Student.Domain.Request.SinhVien;
using Student.Domain.Response.SinhVien;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.DAL.Interface
{
    public interface ISinhVienRepository
    {
        LuuSinhVienRes LuuSinhVien(LuuSinhVienReq luuSinhVienReq);
        XoaSinhVienRes XoaSinhVien(XoaSinhVienReq xoaSinhVienReq);
        LaySVTheoIdRes LaySVTheoId(LaySVTheoIdReq laySVTheoIdReq);
    }
}
