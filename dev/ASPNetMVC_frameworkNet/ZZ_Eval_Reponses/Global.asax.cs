using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZB_Eval.Binders;
using ZB_Eval.Injection;
using ZZ_Eval.Models;

namespace ZZ_Eval
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			ControllerBuilder.Current.SetControllerFactory(new MaControllerFactory());
			ModelBinders.Binders.Add(typeof(DuckFamily), new DuckFamilyBinder());
		}
    }
}
