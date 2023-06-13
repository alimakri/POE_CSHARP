using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Z2_Metier;

namespace Z8_Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var ds1 = Personnes.Get(SourceEnum.Real);

            return View(ds1);
        }
    }
}