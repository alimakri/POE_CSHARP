using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ZZ_Eval.Controllers;

namespace ZZ_Eval.Injection
{
    public class QuestionControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {

            if (controllerName.ToUpper() == "QUESTION2")
            {
                var al = new ArrayList();
                al.Add("Blanche neige");
                al.Add(" et ");
                al.Add("les sept nains");
                al.Add(true);
                return new Question2Controller(al);
            }
            else return (IController)Activator.CreateInstance(Type.GetType(Capitalize(controllerName)));
        }

        private string Capitalize(string controllerName)
        {
            return
                "ZZ_Eval.Controllers." +
                controllerName.Substring(0, 1).ToUpper() +
                controllerName.Substring(1).ToLower() +
                "Controller";
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