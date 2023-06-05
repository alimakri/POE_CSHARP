using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZ_Eval.Models;

namespace ZZ_Eval.Controllers
{
    public class Question6Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] // = ON RECOIT UN FORMULAIRE !! On reçoit des données de formulaire
        public ActionResult Index(DuckFamily family)
        {
            return View(family);

            // model binder : on transforme des données qu'on reçoit en un objet.


            // on a besoin du model binder car il sait pas faire la liste de neveux !
        }
    }
}