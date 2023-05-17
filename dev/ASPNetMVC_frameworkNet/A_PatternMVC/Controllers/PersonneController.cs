using PatternMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatternMVC.Controllers
{
    public class PersonneController : Controller
    {
        public string Index()
        {
            return "<html><head><title>Ma première page</title></head><body><h2 style='color:blue'>Une page Web provenant du contrôleur Personne avec l'action index</h2></body></html>";
        }
        public ActionResult Index2()
        {
            // Etape 2
            var p = Personne.GetOne();

            // Etape 4
            var page = View(p);

            // Etape 6
            return page;
        }
        public ActionResult Index3()
        {
            return View(new Personne { Id = 2, Nom = "Lemarchand", Ville = "Rennes" });
        }
        public ActionResult Index4()
        {
            return View(new Personne { Id = 2, Nom = "Larue", Ville = "Limoges" });
        }
        public ActionResult Index5()
        {
            return View(new Personne { Id = 2, Nom = "Freeman", Ville = "New York" });
        }
        public ActionResult Index6()
        {
            return View(new List<Personne>
            {
                new Personne { Id = 1, Nom = "Riri", Ville = "Singapour" },
                new Personne { Id = 2, Nom = "Fifi", Ville = "Hanai" },
                new Personne { Id = 3, Nom = "Loulou", Ville = "Constantine" },
            });
        }
    }
}