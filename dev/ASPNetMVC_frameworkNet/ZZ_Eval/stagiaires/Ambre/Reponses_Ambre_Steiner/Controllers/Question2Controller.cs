using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ZZ_Eval.Controllers
{
    public class MonControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            ArrayList liste = new ArrayList();
            return new Question2Controller(liste);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            throw new NotImplementedException();
        }

        public void ReleaseController(IController controller)
        {
            throw new NotImplementedException();
        }
    }

    public class Question2Controller : Controller
    {
        private ArrayList MesData;
        public Question2Controller(ArrayList arrayList)
        {
            MesData = arrayList;
        }
        public ActionResult Index()
        {
            return View(MesData);
        }
    }
}