using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZ_Eval.Controllers
{
    public class Question10Controller : Controller
    {
        // GET: Question10
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vue1()
        {
            return PartialView();
        }
        public ActionResult Vue2()
        {
            return PartialView();
        }
    }
}