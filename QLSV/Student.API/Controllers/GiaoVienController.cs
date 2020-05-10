using Microsoft.AspNetCore.Mvc;
using QLSV.BAL_Interface;
using QLSV.Domain.Request.GiaoVien;
using QLSV.Domain.Response.GiaoVien;
using System.Collections.Generic;

namespace QLSV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoVienController : ControllerBase
    {
        private readonly IGiaoVienService giaoVienService;

        public GiaoVienController(IGiaoVienService _giaoVienService)
        {
            giaoVienService = _giaoVienService;
        }

        [HttpGet]
        [Route("LayDanhSachGiaoVien")]
        public IList<GiaoVienItem> LayDanhSachGiaoVien()
        {
            return giaoVienService.LayDanhSachGiaoVien();
        }

        [HttpPost]
        [Route("LuuGiaoVien")]
        public LuuGiaoVienRes LuuLop([FromBody] LuuGiaoVienReq request)
        {
            return giaoVienService.LuuGiaoVien(request);
        }
    }
}