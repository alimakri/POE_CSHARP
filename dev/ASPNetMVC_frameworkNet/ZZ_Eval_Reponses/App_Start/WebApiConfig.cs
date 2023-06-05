using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
