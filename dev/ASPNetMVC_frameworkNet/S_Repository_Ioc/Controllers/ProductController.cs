using S_Repository_Ioc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S_Repository_Ioc.Controllers
{
    public class ProductController : Controller
    {
        private IRepository Repo = new Repository();
        public ActionResult Index()
        {
            return View(Repo.GetAllCat());
        }
    }
}