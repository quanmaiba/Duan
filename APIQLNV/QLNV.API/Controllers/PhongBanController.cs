using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLNV.BAL;
using QLNV.BAL.Interface;
using QLNV.Domain.Request;
using QLNV.Domain.Response;

namespace QLNV.API.Controllers
{
    [ApiController]
    public class PhongBanController : ControllerBase
    {

        private readonly IPhongBanService _phongBanService;
        public PhongBanController(IPhongBanService phongBanService)
        {
            _phongBanService = phongBanService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/phongban/danhsachphongban")]
        public IEnumerable<PhongBan> DanhSachPhongBan()
        {
            return _phongBanService.DanhSachPhongBan();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/phongban/layphongban/{id}")]
        public PhongBan LayPhongBanID(int id)
        {
            return _phongBanService.LayPhongBanID(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/phongban/taophongban")]
        public int TaoPhongBan([FromBody] TaoPhongBan request)
        {
            return _phongBanService.TaoPhongBan(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/phongban/suaphongban")]
        public int SuaPhongBan([FromBody] SuaPhongBan request)
        {
            return _phongBanService.SuaPhongBan(request);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/phongban/xoaphongban/{id}")]
        public bool XoaPhongBan(int id)
        {
            return _phongBanService.XoaPhongBan(id);
        }
    }
}
