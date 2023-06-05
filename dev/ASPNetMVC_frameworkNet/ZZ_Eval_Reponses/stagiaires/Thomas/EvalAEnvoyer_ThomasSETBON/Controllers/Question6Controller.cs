using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZ_Eval.Models;

namespace ZZ_Eval.Controllers
{
    public class Question6Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {

            var principal = Request.Form["personnagePrincipal"];

            var neuveu1 = collection["neveu1"];
            var neuveu2 = collection["neveu2"];
            var neuveu3 = collection["neveu3"];

            var family = new DuckFamily { Principal = principal, Neveus = new List<string> { neuveu1, neuveu2, neuveu3 } };

            return View(family);
        }
    }
}