using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using vaynhanh3s.Domain.Request.DieuKienVay;
using vaynhanh3s.Domain.Response.Banner;
using vaynhanh3s.Domain.Response.DieuKienVay;
using vaynhanh3s.Domain.TTEnum;
using vaynhanh3s.vnmon;

namespace vaynhanh3s.Areas.QuanTri.Controllers
{
    public class LoansController : BaseController
    {
        [CustomAuthorize(Quyen.QuanTri, Quyen.Xem)]
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize(Quyen.QuanTri, Quyen.Xem)]
        [HttpPost]
        public async Task<ActionResult> Gets(IDataTablesRequest request)
        {
            try
            {
                var result = (await _service.GetDieuKienVay(new GetDieuKienVay()
                {
                    DieuKienVayId = 0
                })).Payload;

                var dtResult = new List<DieuKienVay>();

                var columns = request.Columns.Cast<IColumn>().ToArray();
                var searchValue = request.Search.Value;

                dtResult = result.ToList();

                if (result != null && result.Any())
                {
                    var response = DataTablesResponse.Create(request, result.Count(), dtResult.Count, dtResult.Skip(request.Length * request.Start / request.Length).Take(request.Length));
                    return new DataTablesJsonResult(response, JsonRequestBehavior.AllowGet);
                }

                return new DataTablesJsonResult(DataTablesResponse.Create(request, 0, 0, new List<GetsResult>()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex });
            }
        }

        [CustomAuthorize(Quyen.QuanTri, Quyen.Xem)]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _service.GetDieuKienVay(new GetDieuKienVay()
                {
                    DieuKienVayId = id
                });
                if (result != null && result.Success && result.Payload != null)
                    return new JsonResult() { Data = new { code = 1, data = result.Payload.FirstOrDefault() }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };

                return Json(new { code = 0, msg = Util.GeneralMessage.SomeThingWentWrong }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [CustomAuthorize(Quyen.QuanTri)]
        public async Task<ActionResult> AddUpdate(ThemDieuKienVayRequest request)
        {
            try
            {
                var model = new DieuKienVaySaveRequest()
                {
                    DieuKienVayId = request.Id,
                    Ten = request.Ten
                };
                var result = await _service.DieuKienVaySave(model);
                if (result != null && result.Success && result.Payload != null)
                    return Json(new { code = result.Payload.Result == 1, msg = result.Payload.Message });

                return Json(new { code = 0, msg = result.Payload.Message });
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex });
            }
        }
        [HttpPost]
        [CustomAuthorize(Quyen.QuanTri)]
        public async Task<ActionResult> Active(KichHoatDieuKienVayRequest request)
        {
            try
            {
                var result = await _service.KichHoatDieuKienVay(request);

                if (result != null && result.Success && result.Payload != null)
                    return Json(new { code = result.Payload.Success ? 1 : 0, msg = result.Payload.Message });

                return Json(new { code = 0, msg = Util.GeneralMessage.SomeThingWentWrong });
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex });
            }
        }
    }
}