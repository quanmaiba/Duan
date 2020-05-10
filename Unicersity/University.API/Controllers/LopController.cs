using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University.BAL.Interface;
using University.Domain.Request.Lop;
using University.Domain.Response.Lop;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopController : ControllerBase
    {
        private readonly ILopService lopService;

        public LopController(ILopService _lopService)
        {
            lopService = _lopService;
        }

        /// <summary>
        /// Allow create/modify class
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LuuLop")]
        public LuuLopRes LuuLop([FromBody] LuuLopReq request)
        {
            return lopService.LuuLop(request);
        }

        [HttpGet]
        [Route("LayDanhSachLop")]
        public IList<LopItem> LayDanhSachLop()
        {
            return lopService.LayDanhSachLop();
        }

    }
}
