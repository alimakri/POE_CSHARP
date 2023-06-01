using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace ZZ_Eval
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services de l'API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiMath",
                routeTemplate: "api/{controller}/{mathematicien}",
                defaults: new { controller = "ApiMath", mathematicien = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ApiFoot",
                routeTemplate: "api/{controller}/{equipe}",
                
                defaults: new { controller = "ApiFoot", equipe = UrlParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
