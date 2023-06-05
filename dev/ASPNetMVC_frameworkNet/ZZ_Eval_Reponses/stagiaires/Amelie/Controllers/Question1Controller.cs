using System.Collections.Generic;
using System.Web.Mvc;
using ZZ_Eval.Models;
using ZZ_Eval.Repositories;
using ZZ_Eval.ViewModels;
using static ZZ_Eval.ViewModels.Agre;

namespace ZZ_Eval.Controllers
{
    public class Question1Controller : Controller
    {
        private Repository1 Repo = new Repository1();
        public ActionResult Index()
        {
            var personnes = Repo.GetLesPersonnes();
            var voitures = Repo.GetLesVoitures();

            var donne = new Agre { Item1 = personnes, Item2=voitures };

            return View(donne);
        }

        public ActionResult Index11()
        {
            var personnes = Repo.GetLesPersonnes();
            var voitures = Repo.GetLesVoitures();

            var donne = new Agre { Item1 = personnes, Item2 = voitures };

            return View(donne);
        }
    }
    //public class Agre
    //{
    //    public List<Personne> Item1;
    //    public List<Voiture> Item2;
    //}
    //j'ai mis cette classe dans viewmodel ! ça marchait aussi içi avec l'agregagtion par contre j'ai une erreur avec le viewmodel même si sur mon pc ça marche
}