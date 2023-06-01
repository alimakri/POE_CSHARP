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
        public Question10Controller()
        {
            LesVues.Add("Vue 1");
            LesVues.Add("Vue 2");

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vue1()
        {
            return View(LesVues);
        }
        public ActionResult Vue2()
        {
            return View(LesVues);
        }
        public PartialViewResult PhotoVuePartielle()
        {
            return PartialView();
        }
    }
}