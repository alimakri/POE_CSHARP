using C_Todo_V1.Data;
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
        //private List<Todo> Todoes = new List<Todo>
        //    {
        //        new Todo{Id=1, Libelle="Acheter du pain", Fait=false},
        //        new Todo{Id=2, Libelle="Réviser HTML5", Fait=true},
        //        new Todo{Id=3, Libelle="Prendre 4 jours de Week-end", Fait=false},
        //    };
        private Repository Repo = new Repository();
        public ActionResult Index()
        {
            return View(Repo.Get());
        }
        public ActionResult Edit(int id)
        {
            var todo = Repo.Get(id);
            if (todo == null) return RedirectToAction("Index");
            return View(todo);
        }

        [HttpPost]
        public ActionResult Edit(Todo todo)
        {
            var todoTrouve = Repo.Get(todo.Id);
            if (todoTrouve != null)
            {
                todoTrouve.Libelle = todo.Libelle;
                todoTrouve.Fait = todo.Fait;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Repo.Remove(id);
            return RedirectToAction("Index");
        }
        public ActionResult Add()
        {
            var todo = Repo.Add();
            return View(todo);
        }
    }
}