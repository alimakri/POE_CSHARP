using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ZZ_Eval.Controllers
{
    public class Question9Controller : Controller
    {
        public ActionResult Index()
        {
            if (!Roles.RoleExists("Cle")) Roles.CreateRole("Cle"); 
            if (!Roles.IsUserInRole("maitrixdescles@matrix.com", "Cle")) Roles.AddUserToRole("maitrixdescles@matrix.com", "Cle");

            if (!Roles.RoleExists("Coffre")) Roles.CreateRole("Coffre"); 
            if (!Roles.IsUserInRole("neo@matras.com", "Coffre")) Roles.AddUserToRole("neo@matras.com", "Coffre");
            return View();
        }
        [Authorize(Roles = "Cle")]
        public ActionResult Cle()
        {
            return View();
        }
        [Authorize(Roles = "Coffre")]
        public ActionResult Coffre()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Coffre")]
        public ActionResult Coffre(string cle)
        {
            if (cle == "PI314") return RedirectToAction("Pilule");
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Coffre")]
        public ActionResult Pilule(string cle)
        {
            return View();
        }
    }
}