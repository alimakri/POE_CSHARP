using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Ninject;
using ZZ_Eval.Controllers;

namespace ZZ_Eval.Controllers
{
    public class MonControllerFactory : IControllerFactory
    {
        private IKernel kernel;

        public MonControllerFactory()
        {
            kernel = new StandardKernel();
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Question2")
            {
                ArrayList data = new ArrayList();

                data.Add("Blanche Neige");
                data.Add(" et les 7 nains");
                data.Add(true);

                return new Question2Controller(data);
            }

            throw new ArgumentException("Nom non valide");
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}




