﻿using H_WebDeBase.Models;
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
            Comptes.Add(new Compte { Id = 1, Titulaire = "Pierre", Montant = 100, Message="Bonjour Pierre....", Ecritures = new List<Ecriture>() });
            Comptes.Add(new Compte { Id = 2, Titulaire = "Paul", Montant = 300, Message=null, Ecritures = new List<Ecriture>() });
            Comptes.Add(new Compte { Id = 3, Titulaire = "Jacques", Montant = -50, Message = "Bonjour Jacques....", Ecritures = new List<Ecriture>() });
            Comptes[0].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Achat Auchan", Montant = -103.50M });
            Comptes[0].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Impots Reven", Montant = -1100.00M });
            Comptes[0].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Salaire avri", Montant = 2100.90M });
            Comptes[1].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Achat Carrefour", Montant = -103.50M });
            Comptes[1].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Impots Reven", Montant = -2100.00M });
            Comptes[1].Ecritures.Add(new Ecriture { Id = Guid.NewGuid(), Libelle = "Salaire avri", Montant = 4100.90M });
        }
        // http://localhost:58378/home/index
        public string Index(int? id)
        {
            string path = ""; string content = "";
            if (id==null)
            {
                path = Server.MapPath("/pages/error.html");
                content = System.IO.File.ReadAllText(path);
                return content.Replace("@id", "non renseigné");
            }
            var compte = Comptes.FirstOrDefault(x => x.Id == id);  string nom = "Inconnu"; decimal montant = 0; string ul=""; 
            string montantColor = "montantColorPositif"; string message = ""; string messageDisabled = "";
            if (compte == null)
            {
                path = Server.MapPath("/pages/error.html");
                content = System.IO.File.ReadAllText(path);
            }
            else
            {
                path = Server.MapPath("/pages/index.cshtml");
                content = System.IO.File.ReadAllText(path);
                nom = compte.Titulaire; montant = compte.Montant;
                ul = "<table>";
                foreach(var e in compte.Ecritures)
                {
                    ul += $"<tr><td>{e.Libelle}</td><td>{e.Montant}</td></tr>";
                }
                ul += "</table>";
                if (compte.Montant < 0) montantColor = "montantColorNegatif";

                if (!string.IsNullOrEmpty(compte.Message))
                {
                    message = compte.Message;
                }
                else
                    messageDisabled = "disabled='disabled'";
            }
            content = content
                .Replace("@nom", nom)
                .Replace("@id", id.ToString())
                .Replace("@messageDisabled", messageDisabled)
                .Replace("@message", message)
                .Replace("@montantColor", montantColor)
                .Replace("@montant", montant.ToString("# ###.00"))
                .Replace("@ecritures", ul);
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