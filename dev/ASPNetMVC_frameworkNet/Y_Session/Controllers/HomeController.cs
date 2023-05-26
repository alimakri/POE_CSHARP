using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.SessionState;
using Y_Session.Models;

namespace Y_Session.Controllers
{
    public class HomeController : Controller
    {
        private List<PanierElement> Panier = null;
        //private HttpSessionState MaSession;
        public HomeController()
        {
            //MaSession = System.Web.HttpContext.Current.Session;
        }
        public ActionResult Index()
        {
            ViewBag.SessionId = Session.SessionID;
            return View(new List<PanierElement>());
        }
        [HttpPost]
        public ActionResult Index(PanierElement commande)
        {
            ViewBag.SessionId = Session.SessionID;

            // Récupération du panier dans Session
            Panier = (List<PanierElement>)Session["Panier"];
            if (Panier == null) Panier = new List<PanierElement>();

            // Ajoût de la commande
            Panier.Add(commande);
            // Conservation du panier dans Session
            Session["Panier"] = Panier;
            return View(Panier);
        }
        public ActionResult Admin()
        {
            List<string> liste=null;
            if (HttpRuntime.Cache["ListeProduit"] == null)
            {
                liste = new List<string>
                {
                    "Savon","Shampoing","Dentifrice"
                };
                HttpRuntime.Cache.Add(
                    "ListeProduit",
                    liste,
                    null,
                    DateTime.Now.AddMinutes(10),
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.High,
                    null);
            }
            liste = (List<string>) HttpRuntime.Cache["ListeProduit"];
            return View(liste);  
        }
    }
}