using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZZ_Eval.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date de naissance")]
        public DateTime DateNaissance { get; set; }
        public bool EstEmbauche { get; set; }
    }
}