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
        [HttpPost]
        public ActionResult Index(DuckFamily family)
        {
            return View(family);
        }
    }
    public class DuckFamily
    {
        public string Donald { get; set; }
        public string Riri { get; set; }
        public string Fifi { get; set; }
        public string Loulou { get; set; }
    }
    [HttpPost]
    public ActionResult Index(DuckFamily family)
    {
        ViewBag.Message = $"Réception du formulaire, les neveux de Donald sont {family.Riri}, {family.Fifi} et {family.Loulou}.";
        return View(family);
    }
}