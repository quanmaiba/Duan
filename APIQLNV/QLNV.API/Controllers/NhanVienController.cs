using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNV.BAL.Interface;
using QLNV.Domain.Request;
using QLNV.Domain.Response;

namespace QLNV.API.Controllers
{
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;
        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/nhanvien/danhsachnhanvientheophongban/{id}")]
        public IEnumerable<NhanVien> DanhSachNhanVienTheoPhongBan(int id)
        {
            return _nhanVienService.DanhSachNhanVienThepPhongBan(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/nhanvien/laynhanvien/{id}")]
        public NhanVien LayNhanVien(int id)
        {
            return _nhanVienService.LayNhanVienTheoID(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/nhanvien/taonhanvien")]
        public int TaoNhanVien([FromBody] TaoNhanVien request)
        {
            return _nhanVienService.TaoNhanVien(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/nhanvien/suanhanvien")]
        public int SuaNhanVien([FromBody] SuaNhanVien request)
        {
            return _nhanVienService.SuaNhanVien(request);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/nhanvien/xoanhanvien/{id}")]
        public bool XoaNhanVien(int id)
        {
            return _nhanVienService.XoaNhanVien(id);
        }
    }
}