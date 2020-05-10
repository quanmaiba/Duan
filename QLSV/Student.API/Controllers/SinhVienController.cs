using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student.BAL.Interface;
using Student.Domain.Request.SinhVien;
using Student.Domain.Response.SinhVien;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienService sinhVienService;

        public SinhVienController(ISinhVienService _sinhVienService)
        {
            sinhVienService = _sinhVienService;
        }
        [HttpPost]
        [Route("LuuSinhVien")]
        public LuuSinhVienRes LuuSinhVien(LuuSinhVienReq request)
        {
            return sinhVienService.LuuSinhVien(request);
        }

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        [HttpDelete]
        [Route("XoaSinhVien")]
        public XoaSinhVienRes XoaSinhVien(XoaSinhVienReq request)
        {
            return sinhVienService.XoaSinhVien(request);
        }

        [HttpGet]
        [Route("LaySVTheoId")]
        public LaySVTheoIdRes LaySVTheoId(LaySVTheoIdReq request)
        {
            return sinhVienService.LaySVTheoId(request);
        }
    }
}
