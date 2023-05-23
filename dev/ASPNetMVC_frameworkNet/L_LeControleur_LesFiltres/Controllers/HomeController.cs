using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L_LeControleur_LesFiltres.Controllers
{
    public class HomeController : Controller
    {
        private string Message = "";
        public ActionResult Index()
        {
            ViewBag.Message += "Index<br/>";
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Message += "OnActionExecuting<br/>";
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.Message += "OnActionExecuted<br/>";
            base.OnActionExecuted(filterContext);
        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewBag.Message += "OnResultExecuting<br/>";
        }
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            ViewBag.Message += "OnResultExecuted<br/>";
        }
    }
}