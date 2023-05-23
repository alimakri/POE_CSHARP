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
            Achats = new List<Achat> {
            new Achat{Id=1, Libelle="Matelas", Prix=128.49M },
            new Achat{Id=2, Libelle="Samsung T7 external HD", Prix=89.50M },
            new Achat{Id=3, Libelle="Tensionmetre Onrom", Prix=189.50M }
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
            return View(a);
        }
    }
}