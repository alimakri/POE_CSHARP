using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace F_WebApi_Route
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services de l'API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            // api/livre/ref
            // api/livre/ref/1
            config.Routes.MapHttpRoute(
                name: "reference",
                routeTemplate: "api/{controller}/ref/{reference}",
                constraints: new {  reference = "[0-9]+"}
            );
            // exemple : api/livre/c/12
            config.Routes.MapHttpRoute(
                name: "cat",
                routeTemplate: "api/{controller}/c/{cat}"
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
