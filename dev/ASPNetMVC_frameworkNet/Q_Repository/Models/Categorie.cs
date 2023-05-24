using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Q_Repository.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SousCategorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Produit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public decimal ListPrice { get; set; }
        public byte[] Image { get; set; }
    }
}