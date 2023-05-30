using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A_ProjetComplet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [Route("a")]
        public List<string> GetEaux()
        {
            return new List<string> { "Badoit", "San Peligrino", "Perrier" };
        }
        [Route("b")]
        public List<string> GetEauxAutres()
        {
            return new List<string> { "Quezac", "Volvic" };
        }
    }
}
