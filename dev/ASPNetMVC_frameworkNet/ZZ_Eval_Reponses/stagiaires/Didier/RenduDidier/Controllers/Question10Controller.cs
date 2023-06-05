using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZ_Eval.Controllers
{
    public class Question10Controller : Controller
    {
        private ArrayList LesVues = new ArrayList();
        // GET: Question10
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vue1()
        {
            var al = new ArrayList();
            return View();
        }
        public ActionResult Vue2()
        {
            return View();
        }
        public PartialViewResult Commun()
        {
            return PartialView();
        }
    }
}