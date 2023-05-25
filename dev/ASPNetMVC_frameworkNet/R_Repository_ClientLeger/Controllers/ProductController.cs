using Q_Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q_Repository.Controllers
{
    public class ProductController : Controller
    {
        private Repository Repo = new Repository();
        public ActionResult Index()
        {
            return View(Repo.GetAllCat());
        }
    }
}