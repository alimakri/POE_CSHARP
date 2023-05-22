using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LeControleur_ModelBinder.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
    }
}