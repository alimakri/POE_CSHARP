using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace X_Roles.Controllers
{
    [Authorize]
    public class PrivateController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if(!Roles.RoleExists("Admin")) Roles.CreateRole("Admin");
            if (!Roles.IsUserInRole("ali@makrisoft.net", "Admin")) Roles.AddUserToRole("ali@makrisoft.net", "Admin");
            return View();
        }
        public ActionResult Page1()
        {
            return View();
        }
        [Authorize(Roles="Admin")]
        public ActionResult Page2()
        {
            return View();
        }
    }
}