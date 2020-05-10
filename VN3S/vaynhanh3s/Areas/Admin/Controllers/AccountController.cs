using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vaynhanh3s.Domain.Request.Account;
using vaynhanh3s.Util;

namespace vaynhanh3s.Areas.QuanTri.Controllers
{
    public class AccountController : Controller
    {
        // GET: QuanTri/Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(DangNhapRequest request)
        {
            try
            {
                if (request.Username == vaynhanh3sConfig.Username && request.Password == vaynhanh3sConfig.Password)

                {
                    FormsAuthentication.SetAuthCookie(vaynhanh3sConfig.Username, true);
                    return Redirect("/Admin/Home");

                }
                else
                {
                    TempData["Error"] = ThanhVien.DangNhapLoi;
                }

                return RedirectToAction("Index", "Account");
            }
            catch (Exception ex)
            {
                TempData["Error"] = GeneralMessage.SomeThingWentWrong;
                return RedirectToAction("Index", "Account");
            }
        }


        [Authorize]
        public ActionResult Logout()
        {
            Session.Abandon();
            var httpCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (httpCookie != null)
                httpCookie.Expires = DateTime.Now.AddDays(-1);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }
    }
}