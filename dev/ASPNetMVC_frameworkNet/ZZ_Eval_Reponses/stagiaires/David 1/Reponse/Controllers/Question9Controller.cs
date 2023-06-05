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
			if (!Roles.RoleExists("Maître des Clés")) Roles.CreateRole("Maître des Clés");
			if (!Roles.IsUserInRole("maitredescles@matrix.com", "Maître des Clés")) Roles.AddUserToRole("maitredescles@matrix.com", "Maître des Clés");
			if (!Roles.RoleExists("TheOne")) Roles.CreateRole("TheOne");
			if (!Roles.IsUserInRole("neo@matrix.com", "TheOne")) Roles.AddUserToRole("neo@matrix.com", "TheOne");
			return View();
        }
		[Authorize(Roles = "Maître des Clés")]
		public ActionResult Cle()
        {

            return View();
        }
		[Authorize(Roles = "TheOne")]
		public ActionResult Coffre()
        {
			return View();
        }
		[Authorize(Roles = "TheOne")]
		[HttpPost]
        public ActionResult Coffre(string cle)
        {
            if (cle == "PI314") return RedirectToAction("Pilule");
            return RedirectToAction("Index");
        }
		[Authorize(Roles = "TheOne")]
		public ActionResult Pilule(string cle)
        {
            return View();
        }
    }
}