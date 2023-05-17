using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace B_LeControleur.Controllers
{
    public class DemoController : Controller
    {
        public string Index1()
        {
            return "Hello";
        }
        // ContentResult
        public ActionResult Index2()
        {
            var content = new ContentResult();
            content.ContentType = "text/plain";
            content.ContentEncoding = Encoding.UTF8;
            content.Content = "ça marche ! ";
            return content;
        }
        // EmptyResult
        public ActionResult Index3()
        {
            var content = new EmptyResult();
            return content;
        }
        // FileResult
        public ActionResult Index4(string id)
        {
            if (id == null) id = "";
            Response.AddHeader("Content-Disposition", $"inline;filename=index{id}.txt");
            var data = System.IO.File.ReadAllBytes(@"d:\data.txt");
            var content = new FileContentResult(data, "application/txt");
            return content;
        }
        // JavaScriptResult
        public ActionResult Index5()
        {
            var content = new JavaScriptResult();
            content.Script = "alert('coucou')";
            return content;
        }
        // JavaScriptResult
        public ActionResult Index6()
        {
            var content = new JsonResult();
            content.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            content.Data = @"{""x"":""1""}";
            return content;
        }
        // FileResult
        public ActionResult Index7()
        {
            var content = new RedirectResult("http://google.fr");
            return content;
        }
    }
}