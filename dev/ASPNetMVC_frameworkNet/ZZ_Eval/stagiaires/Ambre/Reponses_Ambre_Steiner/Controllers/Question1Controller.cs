using System.Web.Mvc;
using ZZ_Eval.Models;
using ZZ_Eval.Repositories;
using ZZ_Eval.ViewModels;

namespace ZZ_Eval.Controllers
{
    public class Question1Controller : Controller
    {
        private Repository1 Repo = new Repository1();
        public Question1ViewModel viewmod= new Question1ViewModel();
        public ActionResult Index()
        {
            var personnes = Repo.GetLesPersonnes();
            var voitures = Repo.GetLesVoitures();

            for (int i = 0; i < personnes.Count; i++)
            {
                viewmod.Personnes.Add(personnes[i]);
            }
            for (int i = 0; i < voitures.Count; i++)
            {
                viewmod.Voitures.Add(voitures[i]);
            }

            string personneString =viewmod.Personnes.ToString();
            string voitureString = viewmod.Voitures.ToString();

            return View(viewmod);
        }
    }
}