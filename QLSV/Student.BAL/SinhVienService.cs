using Student.BAL.Interface;
using Student.DAL.Interface;
using Student.Domain.Request.SinhVien;
using Student.Domain.Response.SinhVien;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.BAL
{
    public class SinhVienService : ISinhVienService
    {
        private readonly ISinhVienRepository sinhVienRepository;

        public SinhVienService(ISinhVienRepository _sinhVienRepository)
        {
            sinhVienRepository = _sinhVienRepository;
        }

        public LaySVTheoIdRes LaySVTheoId(LaySVTheoIdReq laySVTheoIdReq)
        {
            return sinhVienRepository.LaySVTheoId(laySVTheoIdReq);
        }

        public LuuSinhVienRes LuuSinhVien(LuuSinhVienReq luuSinhVienReq)
        {
            return sinhVienRepository.LuuSinhVien(luuSinhVienReq);
        }
        public XoaSinhVienRes XoaSinhVien(XoaSinhVienReq xoaSinhVienReq)
        {
            return sinhVienRepository.XoaSinhVien(xoaSinhVienReq);
        }
    }
}
