using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZ_Eval.Controllers
{
    public class Question8Controller : Controller
    {
        // GET: Question8
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int pomme, int poire, int scoubidou, string submit)
        {
            if (submit == "Reset") 
                ViewBag.Total = 0;
            else
                ViewBag.Total = pomme * 1M + poire * 0.1M + scoubidou * 0.01M;
            return View();
        }
    }
}