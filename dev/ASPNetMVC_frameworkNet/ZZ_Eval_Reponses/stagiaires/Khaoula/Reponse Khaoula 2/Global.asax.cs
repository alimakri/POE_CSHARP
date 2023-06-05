using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using E_LeControlleur__ModeleBuilder.Builder;

using Ninject.Web.WebApi;
using ZZ_Eval.Controllers;

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



            //  MyControllerFactory 
             //ControllerBuilder.Current.SetControllerFactory(new MonControllerFactory());
            


            ModelBinders.Binders.Add(typeof(DuckFamily), new DuckFamilyModelBinder());


        }
    }
}
