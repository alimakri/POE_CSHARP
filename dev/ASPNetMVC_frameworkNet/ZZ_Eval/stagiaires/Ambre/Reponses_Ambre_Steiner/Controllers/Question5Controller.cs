using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZ_Eval.Repositories;
using static ZZ_Eval.Repositories.Repository5;

namespace ZZ_Eval.Controllers
{
    public class Question5Controller : Controller
    {
        private List<Plante> PlanteDB = new List<Plante>
        {
            new Plante{Id=1, Nom="Accacia faux robinetier"},
            new Plante{Id=2, Nom="Ficcus"},
            new Plante{Id=3, Nom="Baobab"}
        };
        private Repository5 Repo = new Repository5();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fill()
        {
            ViewBag.Message = Repo.Fill() ? 
                "La base de données est remplie." : 
                "La base de données est déjà remplie.";
            return View();
        }
        public ActionResult Display()
        {
            return View(Repo.Get());
        }
    }
}