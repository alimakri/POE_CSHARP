using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Y_Session.Models;

namespace Y_Session.Controllers
{
    public class HomeController : Controller
    {
        private List<PanierElement> Panier = null;
        private HttpSessionState MaSession;
        public HomeController()
        {
            MaSession = System.Web.HttpContext.Current.Session;
        }
        public ActionResult Index()
        {
            ViewBag.SessionId = MaSession.SessionID;
            return View();
        }
        [HttpPost]
        public ActionResult Index(PanierElement commande)
        {
            ViewBag.SessionId = MaSession.SessionID;

            // Récupération du panier dans Session
            Panier = (List<PanierElement>)Session["Panier"];
            // Ajoût de la commande
            Panier.Add(commande);
            // Enregistrement du panier dans Session
            Session["Panier"] = Panier;
            return View(Panier);
        }
    }
}