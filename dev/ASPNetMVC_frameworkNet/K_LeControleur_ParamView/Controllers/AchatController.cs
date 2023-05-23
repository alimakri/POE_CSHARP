using K_LeControleur_ParamView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K_LeControleur_ParamView.Controllers
{
    public class AchatController : Controller
    {
        private List<Achat> Achats = null;
        public AchatController()
        {
            Achats = new List<Achat>
            {
            new Achat{Id=1, Libelle="Matelas", Prix=128.49M, Categorie= CategorieEnum.Literie },
            new Achat{Id=2, Libelle="Samsung T7 external HD", Prix=89.50M, Categorie= CategorieEnum.DisqueDurExterne },
            new Achat{Id=3, Libelle="Tensionmetre Onrom", Prix=189.50M , Categorie= CategorieEnum.Medical}
            };

        }
        public ActionResult Index()
        {
            string nom = "Ali MAKRI";
            return View(new AchatsNom { Achats = Achats, Nom = nom });
        }
        public ActionResult Details(int id)
        {
            var a = Achats.FirstOrDefault(x => x.Id == id);
            if (a == null) return RedirectToAction("Index");
            // Ancêtre du ViewBag
            // ViewData["Categorie"] = "Disque dur externe";
            switch (a.Categorie)
            {
                case CategorieEnum.DisqueDurExterne: ViewBag.Categorie = "Disque dur externe"; break;
                case CategorieEnum.Literie: ViewBag.Categorie = "Literie"; break;
                case CategorieEnum.Medical: ViewBag.Categorie = "Appareil médical"; break;
                default: ViewBag.Categorie = "Inconnue"; break;
            }

            return View(a);
        }
    }
}