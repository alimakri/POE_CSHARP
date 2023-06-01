using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZB_Eval.Controllers;

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
            //////////////////////////////

            ControllerBuilder.Current.SetControllerFactory(new ControleurFactoryController());
            // AJAX POUR OBTENIR LES FONCTIONNALITES NECESSAISSAIRE AU CONTROLEUR
        }
    }
}
