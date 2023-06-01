using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_LeControlleur__ModeleBuilder.Builder;
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
        public ActionResult Index(DuckFamily family)
        {
            return View(family);
        }
    }
}



