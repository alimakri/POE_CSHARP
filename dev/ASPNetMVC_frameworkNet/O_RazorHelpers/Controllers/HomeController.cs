using O_RazorHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace O_RazorHelpers.Controllers
{
    public class HomeController : Controller
    {
        private List<SousMarin> SousMarins = new List<SousMarin>
        {
            new SousMarin{ Id=1, Type= SousMarinEnum.SNA, Nom="Casabianca", AQuai=true },
            new SousMarin{ Id=2, Type= SousMarinEnum.SNLE, Nom="Le Téméraire" },
            new SousMarin{ Id=3, Type= SousMarinEnum.SNA, Nom="Le Perle" },
        };
        public ActionResult Index()
        {
            return View(SousMarins);
        }
        public ActionResult Edit(int id)
        {
            var s = SousMarins.FirstOrDefault(x => x.Id == id);
            if (s == null) return RedirectToAction("Index");
            return View(s);
        }
    }
}