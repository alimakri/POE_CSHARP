using E_LeControleur_ModelBinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LeControleur_ModelBinder.Controllers
{
    public class PersonneController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(Personne p)
        {
            return View(p);
        }
        //public ActionResult Save()
        //{
        //    var id = int.Parse(Request.Form["id"]);
        //    var nom = Request.Form["nom"];
        //    var dateNaissance = DateTime.ParseExact(Request.Form["DateNaissance"], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        //    var p = new Personne { Id = id, Nom = nom, DateNaissance = dateNaissance };

        //    return View(p);
        //}
    }
}