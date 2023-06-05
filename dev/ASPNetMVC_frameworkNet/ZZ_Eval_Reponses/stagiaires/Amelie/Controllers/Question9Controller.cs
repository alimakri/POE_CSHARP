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
            if (!Roles.RoleExists("Neo")) // creation d'un role s'il n'existe pas
                Roles.CreateRole("Neo ");
            if (!Roles.IsUserInRole("neo@matrix2.com", "Neo")) //un role existe pour cet email?
                Roles.AddUserToRole("neo@matrix2.com", "Neo"); //on donne ce role à cet email


            if (!Roles.RoleExists("maitredescles")) // creation d'un role s'il n'existe pas
                Roles.CreateRole("maitredescles");
            if (!Roles.IsUserInRole("maitredescles2@matrix.com", "maitredescles")) //un role existe pour cet email?
                Roles.AddUserToRole("maitredescles2@matrix.com", "maitredescles"); //on donne ce role à cet email

            return View();
        }

        [Authorize(Roles = "maitredescles")]
        public ActionResult Cle()
        {
            return View();
        }

        [Authorize(Roles = "Neo")]
        public ActionResult Coffre()
        {
            return View();
        }
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