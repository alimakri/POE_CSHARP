﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_LeControleur_ParamView.Models
{
    public enum CategorieEnum { DisqueDurExterne, Literie, Medical }
    public class Achat
    {
        public int Id { get; set; }
        public string Libelle  { get; set; }
        public decimal Prix { get; set; }
        public CategorieEnum Categorie { get; set; }
    }
    public class AchatsNom
    {
        public List< Achat> Achats { get; set; }
        public string Nom { get; set; }
    }
}