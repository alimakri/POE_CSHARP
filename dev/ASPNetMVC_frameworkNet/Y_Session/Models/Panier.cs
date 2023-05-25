using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Y_Session.Models
{
    public class PanierElement
    {
        public int Id { get; set; }
        public string Produit { get; set; }
        public decimal Prix { get; set; }
    }
}