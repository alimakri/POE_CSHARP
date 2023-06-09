﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace U_Routage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "route3",
                url: "{controller}/simpsons/{prenom}",
                defaults: new { controller = "Home", action = "Simpsons" }
            );
            routes.MapRoute(
                name: "route2",
                url: "{controller}/{action}/{personne}",
                defaults: new { controller = "Home", action = "Index" }
                , constraints: new { personne = "[0-9]+" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
