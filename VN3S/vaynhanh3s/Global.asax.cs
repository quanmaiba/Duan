using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using vaynhanh3s.DI;

namespace vaynhanh3s
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DIResolver.ConfigureDI();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataTables.AspNet.Mvc5.Configuration.RegisterDataTables();
        }
    }
}
