using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using vaynhanh3s.Contract.Service;
using vaynhanh3s.DI;
using vaynhanh3s.Domain.TTEnum;

namespace vaynhanh3s.Areas.QuanTri.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public Ivaynhanh3sService _service { get; set; }
        protected static long ThanhVienId = 0;
        protected static string TenThanhVien = string.Empty;

        public BaseController()
        {
            _service = DIResolver.Resolve<Ivaynhanh3sService>();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}