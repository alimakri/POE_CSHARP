using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H_WebDeBase.Models
{
    public class Compte
    {
        public int Id;
        public string Titulaire;
        public decimal Montant;
        public List<Ecriture> Ecritures;
    }
    public class Ecriture
    {
        public Guid Id;
        public string Libelle;
        public decimal Montant;
    }
}