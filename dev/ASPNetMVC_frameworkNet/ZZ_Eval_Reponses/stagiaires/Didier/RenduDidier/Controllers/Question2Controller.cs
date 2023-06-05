using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZ_Eval.Controllers
{
    public class Question2Controller : Controller
    {
        // Faire un ControleurFactory 
        private ArrayList MesData;

        // constructeur : niveau du controleurFactory
        public Question2Controller(ArrayList data) // pour le question 2 controleur faudra lui transmettre une arraylist 
        {
            // CONSTRUCTEUR : IL RECOIT UN PARAMETETRE : il instancie le controleur 
            MesData = data;
            // SI ON DEFINI LE CONSTRUCTEUR ON PERDS LE CONSTRUCTEUR PAR DEFAULT 
            // par défaut il sait faire mais là il ne sait plus
        }

        public ActionResult Index()
        {
            // model binder niveau des actions
            return View(MesData);
        }
    }
} // on ne peut pas appeler une méthode dans une classe qui est static sans l'avoir instancier. ON NE PEUT PAS APPELER UNE CLASSE SANS L'AVOIR INSTANCIER !!!!!!!