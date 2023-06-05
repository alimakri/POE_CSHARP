using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ZZ_Eval.Controllers;

namespace ZB_Eval.Controllers
{
    public class MonControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToUpper() == "QUESTION2")
            {
                var data = new ArrayList();
                return new Question2Controller(data);
            }
            return null;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {

        }
    }
}