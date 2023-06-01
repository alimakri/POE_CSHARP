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
            if (!Roles.RoleExists("RoleCle")) Roles.CreateRole("RoleCle");
            if (!Roles.RoleExists("RoleCoffre")) Roles.CreateRole("RoleCoffre");
            if (!Roles.IsUserInRole("maitredescles@matrix.com", "RoleCle")) Roles.AddUserToRole("maitredescles@matrix.com", "RoleCle");
            if (!Roles.IsUserInRole("neo@matrix.com", "RoleCoffre")) Roles.AddUserToRole("neo@matrix.com", "RoleCoffre");
            return View();
        }
        [Authorize(Roles ="RoleCle")]
        public ActionResult Cle()
        {
            return View();
        }
        [Authorize(Roles = "RoleCoffre")]
        public ActionResult Coffre()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "RoleCoffre")]
        public ActionResult Coffre(string cle)
        {
            if (cle == "PI314") return RedirectToAction("Pilule");
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "RoleCoffre")]
        public ActionResult Pilule(string cle)
        {
            return View();
        }
    }
}