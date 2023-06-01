using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZZ_Eval.Controllers;

namespace ZB_Eval.Injection
{
	public class MaControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == typeof(Question2Controller))
			{
				ArrayList data = new ArrayList() {"Blanche", "Neige", "et les 7 nains", true };
				return new Question2Controller(data);
			}
			else
			{
				return base.GetControllerInstance(requestContext, controllerType);
			}
		}
	}
}