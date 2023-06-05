using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZ_Eval.Controllers
{
    public class Question7Controller : Controller
    {
        // GET: Question7
        public ActionResult Index(string id) // dans l'iD on reçoit soit ramanudan soit enstein
        {
            ViewBag.Nom = id;
            return View();
        }
    }
}