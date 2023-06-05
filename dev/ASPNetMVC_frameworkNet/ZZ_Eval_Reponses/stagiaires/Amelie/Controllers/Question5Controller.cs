using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZB_Eval.Models;
using ZZ_Eval.Repositories;

namespace ZZ_Eval.Controllers
{
    public class Question5Controller : Controller
    {

        public List<Plante> MesPlantes = new List<Plante>
            {
                new Plante{Id=1, Nom="accacia"},
                 new Plante{Id=2, Nom="ficcus"},
                  new Plante{Id=3, Nom="baobab"},

            };


        private Repository5 Repo = new Repository5();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fill()
        {
            Repo.Fill(MesPlantes);
            return View();
        }
        public ActionResult Display()
        {
            List<Plante> MesPlantes = Repo.Get();
            return View(MesPlantes);
        }
    }
}