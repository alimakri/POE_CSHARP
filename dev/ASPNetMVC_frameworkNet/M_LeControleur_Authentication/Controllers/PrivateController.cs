using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace M_LeControleur_Authentication.Controllers
{
    [Authorize]
    public class PrivateController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Index2()
        {
            var i = 0;
            var j = 12 / i;
            return View();
        }
        public ActionResult CodeSecret()
        {
            return View();
        }
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            
        }
    }
}