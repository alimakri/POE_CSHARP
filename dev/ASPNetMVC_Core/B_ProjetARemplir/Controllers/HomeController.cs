using B_ProjetARemplir.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace B_ProjetARemplir.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> Logger;
        private string RootPath;

        public HomeController(
            ILogger<HomeController> logger, 
            IWebHostEnvironment env
            )
        {
            Logger = logger;
            RootPath = env.ContentRootPath;

        }

        public IActionResult Index()
        {
            ArrayList al = new ArrayList();
            al.Add(RootPath);
            Serilog.Log.Information("Passe par Home/Index");
            return View(al);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}