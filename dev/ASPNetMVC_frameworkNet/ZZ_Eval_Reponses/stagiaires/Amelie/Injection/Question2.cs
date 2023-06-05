using Grpc.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ZZ_Eval.Controllers;

namespace ZB_Eval.Injection
{
    public class MonControllerFactory : IControllerFactory
    {
        public ArrayList MesData { get; private set; }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToUpper() == "QUESTION2") return new Question2Controller(MesData);
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