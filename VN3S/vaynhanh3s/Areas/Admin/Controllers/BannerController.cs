using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using vaynhanh3s.vnmon;
using vaynhanh3s.Domain.Response.Banner;
using vaynhanh3s.Domain.TTEnum;

namespace vaynhanh3s.Areas.QuanTri.Controllers
{
    public class BannerController : BaseController
    {

        [CustomAuthorize(Quyen.QuanTri, Quyen.Xem)]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [CustomAuthorize(Quyen.QuanTri, Quyen.Xem)]
        [HttpPost]
        public async Task<ActionResult> Gets(IDataTablesRequest request)
        {
            try
            {
                var result = (await _service.BannerGets(new Domain.Request.Banner.GetsRequest { })).Payload;
                var dtResult = new List<Domain.Response.Banner.GetsResult>();

                var columns = request.Columns.Cast<IColumn>().ToArray();
                var searchValue = request.Search.Value;

                if (!string.IsNullOrWhiteSpace(searchValue))
                    dtResult = result.Where(c => c.Description.Contains(searchValue)).ToList();
                else
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
                var result = await _service.BannerGet(new Domain.Request.Banner.GetRequest { Id = id });
                if (result != null && result.Success && result.Payload != null)
                    return new JsonResult() { Data = new { code = 1, data = result.Payload }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };

                return Json(new { code = 0, msg = Util.GeneralMessage.SomeThingWentWrong }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [CustomAuthorize(Quyen.QuanTri)]
        public async Task<ActionResult> AddUpdate(Domain.Request.Banner.AddUpdateRequest request)
        {
            try
            {
                request.IsActive = true;
                var result = await _service.BannerAddUpdate(request);
                if (result != null && result.Success && result.Payload != null)
                    return Json(new { code = result.Payload.Result == 1, msg = result.Payload.Message });

                return Json(new { code = 0, msg = Util.GeneralMessage.SomeThingWentWrong });
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex });
            }
        }

        [HttpPost]
        [CustomAuthorize(Quyen.QuanTri)]
        public async Task<ActionResult> Active(Domain.Request.Banner.AddUpdateRequest request)
        {
            try
            {
                var banner = (await _service.BannerGet(new Domain.Request.Banner.GetRequest { Id = request.Id })).Payload;
                banner.IsActive = request.IsActive;

                var result = await _service.BannerAddUpdate(new Domain.Request.Banner.AddUpdateRequest
                {
                    Id = banner.Id,
                    Description = banner.Description,
                    IsActive = banner.IsActive,
                    Url = banner.Url
                });

                if (result != null && result.Success && result.Payload != null)
                    return Json(new { code = result.Payload.Result == 1, msg = result.Payload.Message });

                return Json(new { code = 0, msg = Util.GeneralMessage.SomeThingWentWrong });
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex });
            }
        }
    }
}