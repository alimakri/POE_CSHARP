using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace F_WebApi_Route.Controllers
{
    public class LivreController : ApiController
    {
        private List<Livre> Livres;
        public LivreController()
        {
            Livres = new List<Livre>
            {
            new Livre{ISBN="978-2-409-02074-2", Titre="Scrum"},
            new Livre{ISBN="978-2-409-02074-3", Titre="C#"},
            new Livre{ISBN="978-2-409-02074-4", Titre="Les septs habitudes de ceux... (Covey)"},
            };
        }
        #region De manière standard
        public List<Livre> GetLivres()
        {
            return Livres;
        }
        public Livre GetLivre(string isbn)
        {
            return Livres.FirstOrDefault(x => x.ISBN == isbn);
        }
        #endregion
        #region Avec route
        public Livre GetLivreByRoute(string id)
        {
            return Livres.FirstOrDefault(x => x.ISBN == id);
        }
        public string GetLivreRouteCat(int cat)
        {
            return $"Passage par la route nommée Cat avec comme paramètre la valeur {cat}";
        }
        public string GetLivreRouteReference(int reference)
        {
            //var s = reference == null ? "pas de valeur" : reference.ToString();
            var s = reference.ToString();
            return $"Passage par la route nommée reference avec comme paramètre la valeur ({s})";
        }
        public string GetSansController(string test)
        {
            return $"Passage par la route nommée SansController";
        }
        #endregion

    }
    public class Livre
    {
        public string ISBN;
        public string Titre;
    }
}
