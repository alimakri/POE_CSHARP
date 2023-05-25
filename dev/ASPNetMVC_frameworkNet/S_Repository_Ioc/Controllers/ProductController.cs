using S_Repository_Ioc.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S_Repository_Ioc.Controllers
{
    public class ProductController : Controller
    {
        private IRepository Repo = null;
        public ProductController()
        {
            if (Q_Repository.Properties.Settings.Default.RepoConfig == 1)
                Repo = new FakeRepository();
            else
                Repo = new Repository();
        }
        public ActionResult Index()
        {
            return View(Repo.GetAllCat());
        }
    }
}