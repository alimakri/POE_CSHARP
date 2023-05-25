using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y_Session.Models;

namespace Y_Session.Controllers
{
    public class HomeController : Controller
    {
        private List<PanierElement> Panier = null;
        public HomeController()
        {
            if (Session != null && Session["Panier"] != null)
                Panier = (List<PanierElement>)Session["Panier"];
            if (Panier == null) Panier = new List<PanierElement>();
            Panier.Add(new PanierElement { Id = 1, Produit = "Souris", Prix = 15 });
            Panier.Add(new PanierElement { Id = 2, Produit = "Clavier", Prix = 22 });
            Session["Panier"] = Panier;

        }
        public ActionResult Index()
        {
            return View(Panier);
        }
    }
}