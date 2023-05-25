using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace W_Cache.Controllers
{
    public class HomeController : Controller
    {
        private Repository Repo = new Repository();
        [OutputCache(Duration = 10, VaryByParam ="ville", VaryByCustom ="Browser")]
        public ActionResult Index(string ville)
        {
            Response.Cache.SetCacheability(HttpCacheability.Public);

            ViewBag.Message = DateTime.Now.ToLongTimeString();
            ViewBag.Ville = ville;
            return View();
        }
        public ActionResult Index2()
        {
            var data = (string[])Repo.GetCache();
            
            return View(data);
        }

    }
}