using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using vaynhanh3s.Contract.Service;
using vaynhanh3s.DI;
using vaynhanh3s.Domain.TTEnum;

namespace vaynhanh3s.vnmon
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        private readonly Quyen[] _roles;

        public CustomAuthorize(params Quyen[] roles)
        {
            _roles = roles;
        }

        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            //var currentIdentity = System.Threading.Thread.CurrentPrincipal.Identity;
            //if (!currentIdentity.IsAuthenticated)
            //{
            //    actionContext.Result = new RedirectResult("~/QuanTri");
            //}
            //else
            //{

            //    if (_roles != null && _roles.Any())
            //    {
            //        var service = DIResolver.Resolve<Ivaynhanh3sService>();
            //        var email = HttpContext.Current.User.Identity.Name;
            //        var thanhVien = Task.Run(async () => await service.LayThanhVienId(new Domain.Request.ThanhVien.SpLayThanhVienId { Email = email, ThanhVienId = 0 })).Result;

            //        if (thanhVien == null || thanhVien.Payload == null)
            //        {
            //            actionContext.Result = new RedirectResult("~/QuanTri");
            //        }
            //        else
            //        {
            //            var quyenId = thanhVien.Payload.QuyenId;
            //            Quyen[] DBRights = new Quyen[] { };
            //            try
            //            {
            //                var role = (Quyen)quyenId;
            //                DBRights = DBRights.Concat(new Quyen[] { role }).ToArray();
            //            }
            //            catch { }

            //            if (!_roles.Any(DBRights.Contains))
            //            {
            //                actionContext.Result = new RedirectResult("~/QuanTri");
            //            }
            //        }
            //    }
            //}
        }
    }
}
