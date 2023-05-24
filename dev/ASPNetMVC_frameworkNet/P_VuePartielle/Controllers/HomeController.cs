using P_VuePartielle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P_VuePartielle.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new Avion {Id=1, Name="Airbus A302", Commentaire="Made in France"  });
        }
        public ActionResult Index2()
        {
            return View();
        }
        public PartialViewResult Commun1()
        {
            return PartialView();
        }
        public PartialViewResult Commun2()
        {
            return PartialView();
        }
    }
}