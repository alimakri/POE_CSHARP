using C_Todo_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C_Todo_V1.Controllers
{
    public class TodoController : Controller
    {
        private List<Todo> Todoes = new List<Todo>
            {
                new Todo{Id=1, Libelle="Acheter du pain", Fait=false},
                new Todo{Id=2, Libelle="Réviser HTML5", Fait=true},
                new Todo{Id=3, Libelle="Prendre 4 jours de Week-end", Fait=false},
            };
        public ActionResult Index()
        {
            return View(Todoes);
        }
        public ActionResult Edit(int id)
        {
            var todo = Todoes.FirstOrDefault(x => x.Id == id);
            if (todo == null) return RedirectToAction("Index");
            return View(todo);
        }
        public ActionResult Delete(int id)
        {
            var todo = Todoes.FirstOrDefault(x => x.Id == id);
            if (todo != null) Todoes.Remove(todo);
            return RedirectToAction("Index");
        }
    }
}