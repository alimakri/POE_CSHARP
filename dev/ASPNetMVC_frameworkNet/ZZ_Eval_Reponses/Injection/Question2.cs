using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ZZ_Eval.Controllers;
using ZZ_Eval.ViewModels;

namespace ZZ_Eval.Injection
{
    public class Question2 : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToUpper() == "HOME") return new HomeController();
            if (controllerName.ToUpper() == "QUESTION1") return new Question1Controller();
            if (controllerName.ToUpper() == "QUESTION2")
            {
                ArrayList data = new ArrayList
                {
                    "Blanche",
                    "Neige",
                    "et les 7 nains.",
                    true
                };
                return new Question2Controller(data);
            }
            if (controllerName.ToUpper() == "QUESTION3") return new Question3Controller();
            if (controllerName.ToUpper() == "QUESTION4") return new Question4Controller();
            if (controllerName.ToUpper() == "QUESTION5") return new Question5Controller();
            if (controllerName.ToUpper() == "QUESTION6") return new Question6Controller();
            if (controllerName.ToUpper() == "QUESTION7") return new Question7Controller();
            if (controllerName.ToUpper() == "QUESTION8") return new Question8Controller();
            if (controllerName.ToUpper() == "QUESTION9") return new Question9Controller();
            if (controllerName.ToUpper() == "QUESTION10") return new Question10Controller();
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