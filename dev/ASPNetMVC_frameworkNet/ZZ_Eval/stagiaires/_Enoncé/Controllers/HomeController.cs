using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZ_Eval.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Remise de votre réponse.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ali MAKRI";

            return View();
        }
        public ActionResult Question(int id)
        {
            ViewBag.Message = "Question.";
            ViewBag.NoQuestion = id;
            return View();
        }
    }
}