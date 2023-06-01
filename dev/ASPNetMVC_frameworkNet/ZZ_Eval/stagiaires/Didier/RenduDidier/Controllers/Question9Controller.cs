using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ZZ_Eval.Controllers
{
    [Authorize]
    public class Question9Controller : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!Roles.RoleExists("maitredescles")) Roles.CreateRole("maitredescles");
            if (!Roles.RoleExists("neo")) Roles.CreateRole("neo");

            if (!Roles.IsUserInRole("maitredescles@matrix.com", "maitredescles")) Roles.AddUserToRole("maitredescles@matrix.com.net", "maitredescles");           
            if (!Roles.IsUserInRole("neo@matrix.com", "neo")) Roles.AddUserToRole("maitredescles@matrix.com.net", "neo");
            return View();
            

        }
        [Authorize(Roles = "maitredescles")]
        public ActionResult Cle()
        {
            return View();
        }
        [Authorize(Roles = "neo@matrix.com")]
        public ActionResult Coffre()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "neo@matrix.com")]
        public ActionResult Coffre(string cle)
        {
            if (cle == "PI314") return RedirectToAction("Pilule");
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "neo@matrix.com")]
        public ActionResult Pilule(string cle)
        {
            return View();
        }
    }
}