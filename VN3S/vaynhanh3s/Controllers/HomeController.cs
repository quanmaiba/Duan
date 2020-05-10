using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using vaynhanh3s.Domain.Request.Candidator;
using vaynhanh3s.Domain.Request.Customer;

namespace vaynhanh3s.Controllers
{
    public class HomeController : _BaseController
    {
        public async Task<ActionResult> Index()
        {
            var dieuKienVays = await _service.GetDieuKienVay(new Domain.Request.DieuKienVay.GetDieuKienVay { });
            ViewBag.Banners = (await _service.BannerGets(new Domain.Request.Banner.GetsRequest { })).Payload.ToList();
            return View(dieuKienVays.Payload.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> DangKyVay(CustomerRegister request)
        {
            var result = await _service.CustomerRegister(request);
            return Json(new { code = result.Payload.Success ? 1 : 0, msg = result.Payload.Message });
        }

        [HttpPost]
        public async Task<ActionResult> DangKyUngTuyen(CandidatorRegister request)
        {
            var result = await _service.CandidatorRegister(request);
            return Json(new { code = result.Payload.Success ? 1 : 0, msg = result.Payload.Message });
        }

    }
}