using System.Web.Mvc;
using ZZ_Eval.Repositories;
using ZZ_Eval.ViewModels;

namespace ZZ_Eval.Controllers
{
    public class Question1Controller : Controller
    {
        private Repository1 Repo = new Repository1();
        public ActionResult Index()
        {
            var personnes = Repo.GetLesPersonnes();
            var voitures = Repo.GetLesVoitures();
            var viewModel = new Question1ViewModel
            {
                Titre = "Passagers des voitures",
                Personnes = personnes,
                Voitures = voitures
            };
            return View(viewModel);
        }
    }
}