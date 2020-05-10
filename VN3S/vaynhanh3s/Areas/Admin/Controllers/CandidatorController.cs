using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using vaynhanh3s.Areas.QuanTri.Controllers;
using vaynhanh3s.vnmon;
using vaynhanh3s.Domain.Request.Candidator;
using vaynhanh3s.Domain.Response.Banner;
using vaynhanh3s.Domain.Response.Candidator;
using vaynhanh3s.Domain.TTEnum;

namespace vaynhanh3s.Areas.QuanTri.Controllers
{
    public class CandidatorController : BaseController
    {
        // GET: Admin/Candidator
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
                var result = (await _service.GetCandidators(new GetCandidators()
                {
                    DaXuatRaExcel = false
                })).Payload;

                var dtResult = new List<Candidator>();

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
    }
}