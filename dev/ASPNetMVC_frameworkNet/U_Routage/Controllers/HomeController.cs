using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace U_Routage.Controllers
{
    public class HomeController : Controller
    {
        // http://localhost:62953/home/index
        public ActionResult Index()
        {
            return View();
        }
        // http://localhost:62953/home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // http://localhost:62953/home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // http://localhost:62953/home/test1/alain
        public ActionResult Test1(string personne)
        {
            ViewBag.Message = personne;

            return View();
        }
        // http://localhost:62953/home/simpsons/bart
        // http://localhost:62953/home/simpsons/marge
        // http://localhost:62953/home/simpsons/homer
        public ActionResult Simpsons(string prenom)
        {
            ViewBag.Message = prenom;

            return View();
        }
        // http://localhost:62953/home/index2/3
        public ActionResult Index2(int personne)
        {
            ViewBag.Message = personne;

            return View();
        }
        // http://localhost:62953/home/index2/abc
        public ActionResult Index2(string personne)
        {
            ViewBag.Message = personne;

            return View();
        }
    }
}