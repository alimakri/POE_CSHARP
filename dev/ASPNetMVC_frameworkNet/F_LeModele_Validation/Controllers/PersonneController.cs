using E_LeControleur_ModelBinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F_LeModele_Validation.Controllers
{
    public class PersonneController : Controller
    {
       private List<Personne> Personnes=new List<Personne> 
       {
           new Personne{ Id=1, Nom="Alexandre", DateNaissance = new DateTime(1990,1,1), Immatriculation="AB123AB", Inscrit=true },
           new Personne{ Id=1, Nom="Bernard", DateNaissance = new DateTime(1980,1,1), Immatriculation="CD123CD", Inscrit=false },
           new Personne{ Id=1, Nom="Catherine", DateNaissance = new DateTime(1970,1,1), Immatriculation="EF123EF", Inscrit=true },
       };
        // GET: Personne
        public ActionResult Index()
        {
            return View(Personnes);
        }

        // GET: Personne/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personne/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personne/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personne/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
