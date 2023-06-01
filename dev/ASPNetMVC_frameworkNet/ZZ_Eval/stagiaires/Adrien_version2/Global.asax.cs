using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZB_Eval.Binders;
using ZB_Eval.Controllers;
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
            ModelBinders.Binders.Add(typeof(DuckFamily), new DuckFamilyBinder());
            //ControllerBuilder.Current.SetControllerFactory(new MonControllerFactory());

            //mise en commentaire pour que le reste fonctionne, je n'ai pas eu le temps de finir, j'aurais rajouté éventuellement un filtre 
        }
    }
}
