using System.Threading.Tasks;
using System.Web.Mvc;
using vaynhanh3s.Contract.Service;
using vaynhanh3s.DI;
using vaynhanh3s.Domain.Request.Banner;
using vaynhanh3s.Util;

namespace vaynhanh3s.Controllers
{
    public class _BaseController : Controller
    {
        public Ivaynhanh3sService _service { get; set; }
        protected static long ThanhVienId = 0;
        protected static string TenThanhVien = string.Empty;

        public _BaseController()
        {
            _service = DIResolver.Resolve<Ivaynhanh3sService>();

        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}