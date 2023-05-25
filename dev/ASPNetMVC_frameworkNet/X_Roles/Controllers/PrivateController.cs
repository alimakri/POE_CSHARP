using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X_Roles.Controllers
{
    [Authorize]
    public class PrivateController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Page1()
        {
            return View();
        }
        public ActionResult Page2()
        {
            return View();
        }
    }
}