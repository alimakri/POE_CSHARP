using System.Collections.Generic;
using System.Web.Mvc;
using ZZ_Eval.Models;
using ZZ_Eval.Repositories;
using ZZ_Eval.ViewModels;


namespace ZZ_Eval.Controllers
{

    // MVC car on a un controleur !! on mélange MVC et mvvm
    public class Question1Controller : Controller
    {
        private Repository1 Repo = new Repository1();
      
        public ActionResult Index()
        {
            // controleur qui faut appel aux deux modèles 
            var personnes = Repo.GetLesPersonnes(); // il va chercher des modèles 
            var voitures = Repo.GetLesVoitures();

            return View(new Question1ViewModel // on se sert d'un viewModel pour assembler des modèles (personne et voiture)
            {
                Titre = "Passagers des voitures",
                Personnes = personnes,
                Voitures = voitures
            });
        }
            // question 1 vue modèle devait avoir les 3 propriétés de la vue 
    }
}