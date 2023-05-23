using H_WebDeBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H_WebDeBase.Controllers
{
    public class HomeController : Controller
    {
        #region Version 4
        private List<Compte> Comptes = new List<Compte>();

        public HomeController()
        {
            Comptes.Add(new Compte { Id = 1, Titulaire = "Pierre", Montant = 100, Ecritures = new List<Ecriture>() });
            Comptes.Add(new Compte { Id = 2, Titulaire = "Paul", Montant = 300, Ecritures = new List<Ecriture>() });
            Comptes.Add(new Compte { Id = 3, Titulaire = "Jacques", Montant = -50, Ecritures = new List<Ecriture>() });
            Comptes[0].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Achat Auchan", Montant = -103.50M });
            Comptes[0].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Impots Reven", Montant = -1100.00M });
            Comptes[0].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Salaire avri", Montant = 2100.90M });
            Comptes[1].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Achat Carrefour", Montant = -103.50M });
            Comptes[1].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Impots Reven", Montant = -2100.00M });
            Comptes[1].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Salaire avri", Montant = 4100.90M });
        }
        // http://localhost:58378/home/index
        public string Index(int id)
        {
            var compte = Comptes.FirstOrDefault(x => x.Id == id); string path = ""; string content = ""; string nom = "Inconnu"; decimal montant = 0;
            if (compte == null)
            {
                path = Server.MapPath("/pages/error.html");
                content = System.IO.File.ReadAllText(path);
            }
            else
            {
                path = Server.MapPath("/pages/index.html");
                content = System.IO.File.ReadAllText(path);
                nom = compte.Titulaire; montant = compte.Montant;

            }
            content = content
                .Replace("@nom", nom)
                .Replace("@id", id.ToString())
                .Replace("@montant", montant.ToString("# ###.00"));
            return content;
        }
        #endregion

        #region Versions de base
        public string Index3(int id)
        {
            var path = Server.MapPath("/pages/index3.html");
            var s = System.IO.File.ReadAllText(path);
            var nom = "Inconnu"; var montant = 0M;
            switch (id)
            {
                case 1: nom = "Pierre"; montant = 100; break;
                case 2: nom = "Paul"; montant = 300; break;
                case 3: nom = "Jacques"; montant = -50; break;
            }
            var content = s
                .Replace("@nom", nom)
                .Replace("@montant", montant.ToString("# ###.00"));
            return content;
        }
        public string Index2()
        {
            var path = Server.MapPath("/pages/index2.html");
            var s = System.IO.File.ReadAllText(path);
            return s;
        }
        public string Index1()
        {
            return "<html><body><h2>Version 1</h2></body></html>";
        }
        #endregion
    }
}