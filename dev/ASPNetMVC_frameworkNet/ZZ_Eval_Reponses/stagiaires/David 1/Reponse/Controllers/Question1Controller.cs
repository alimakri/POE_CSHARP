using System.Collections.Generic;
using System;
using System.Web.Mvc;
using ZZ_Eval.Repositories;
using ZZ_Eval.ViewModels;
using Microsoft.Ajax.Utilities;

namespace ZZ_Eval.Controllers
{
	public class Question1Controller : Controller
	{
		Question1ViewModel reponse;

		private Repository1 Repo = new Repository1();
		public ActionResult Index()
		{
			var personnes = Repo.GetLesPersonnes();
			var voitures = Repo.GetLesVoitures();
			reponse = new Question1ViewModel { Titre = "Passager des voitures", Personnes = personnes, Voitures = voitures };
			return View(reponse);
		}
	}
}