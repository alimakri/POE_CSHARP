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
            
                ViewBag.Total = pomme * 1M + poire * 0.1M + scoubidou * 0.01M; // viewbag total = renvois au formulaire
            //le viewbag total est instancier a chaque fois car dansle controleur qui fait la même chose
            return View();
            // Utiliser localstorage coter client .... Comment l'écrire ?!
        }
    }
}
// IL FAUT METTRE UNE VALEUR INITALE A LOCALSTORAGE (int)