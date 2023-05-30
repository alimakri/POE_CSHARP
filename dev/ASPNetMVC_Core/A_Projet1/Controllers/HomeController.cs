using A_Projet1.Models;
using A_ProjetComplet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace A_Projet1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
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
        public ActionResult Index6()
        {
            return View(new List<Personne>
            {
                new Personne { Id = 1, Nom = "Riri", Ville = "Singapour" },
                new Personne { Id = 2, Nom = "Fifi", Ville = "Hanai" },
                new Personne { Id = 3, Nom = "Loulou", Ville = "Constantine" },
            });
        }
    }
}