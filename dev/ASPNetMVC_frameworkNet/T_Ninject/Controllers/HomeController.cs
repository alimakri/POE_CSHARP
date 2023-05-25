using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T_Ninject.Data;

namespace T_Ninject.Controllers
{
    public class HomeController : Controller
    {
        IRepository Repo = null;
        public HomeController(IRepository repo)
        {
            Repo = repo;
            //Repo = new Repository();
        }
        public ActionResult Index()
        {
            ViewBag.Message = Repo.Get();
            return View();
        }
    }
}