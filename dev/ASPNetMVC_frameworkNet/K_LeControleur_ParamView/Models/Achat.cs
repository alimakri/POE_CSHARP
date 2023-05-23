using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_LeControleur_ParamView.Models
{
    public class Achat
    {
        public int Id { get; set; }
        public string Libelle  { get; set; }
        public decimal Prix { get; set; }
    }
    public class AchatsNom
    {
        public List< Achat> Achats { get; set; }
        public string Nom { get; set; }
    }
}