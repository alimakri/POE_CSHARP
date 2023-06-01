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
            if (!Roles.RoleExists("maître des clés")) Roles.CreateRole("maître des clés");
            if (!Roles.IsUserInRole("maitredescles@matrix.com", "maître des clés")) Roles.AddUserToRole("maitredescles@matrix.com", "maître des clés");
            if (!Roles.IsUserInRole("maitredesclesbis@matrix.com", "maître des clés")) Roles.AddUserToRole("maitredesclesbis@matrix.com", "maître des clés");
            if (!Roles.RoleExists("Neo")) Roles.CreateRole("Neo");
            if (!Roles.IsUserInRole("neo@matrix.com", "Neo")) Roles.AddUserToRole("neo@matrix.com", "Neo");
            if (!Roles.IsUserInRole("neobis@matrix.com", "Neo")) Roles.AddUserToRole("neobis@matrix.com", "Neo");
            return View();
        }
        [Authorize(Roles = "maître des clés")]
        public ActionResult Cle()
        {
            return View();
        }
        [Authorize(Roles = "Neo")] //[Authorize(Users = "neo@matrix.com")]
        public ActionResult Coffre()
        {
            return View();
        }
        [Authorize(Roles = "Neo")]
        [HttpPost]
        public ActionResult Coffre(string cle)
        {
            if (cle == "PI314") return RedirectToAction("Pilule");
            return RedirectToAction("Index");
        }
        public ActionResult Pilule(string cle)
        {
            return View();
        }
    }
}