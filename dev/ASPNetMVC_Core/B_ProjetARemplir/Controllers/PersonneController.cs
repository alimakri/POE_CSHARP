using Microsoft.AspNetCore.Mvc;

namespace B_ProjetARemplir.Controllers
{
    public class PersonneController : Controller
    {
        private string RootPath;
        public PersonneController(IWebHostEnvironment env)
        {
            RootPath = env.ContentRootPath;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("{controller=Personne}/{action=page1}/abc/{message}")]
        public IActionResult Page1(string message)
        {
            ViewBag.Message = message;
            return View();
        }
        [Route("{controller=Personne}/{action=page2}/def/ghi/{msg}")]
        public IActionResult Page2(string msg)
        {
            var path = RootPath + @"images\secret.png";
            ViewBag.Photo = Convert.ToBase64String(System.IO.File.ReadAllBytes(path)); 
            ViewBag.Message = msg;
            return View();
        }
    }
}
