using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZ_Eval.Controllers
{
    public class Question9Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cle()
        {
            return View();
        }
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