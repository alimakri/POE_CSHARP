using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C_AspnetMvcDemo.Controllers
{
    public class DemoController : Controller
    {
        // http://localhost:62492/demo
        public ActionResult Index()
        {
            return View();
        }
    }
}