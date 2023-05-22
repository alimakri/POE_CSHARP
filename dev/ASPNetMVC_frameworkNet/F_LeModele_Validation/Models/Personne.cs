using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_LeControleur_ModelBinder.Models
{
    public class Personne
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Merci d'indiquer un nom")]
        public string Nom { get; set; }
        [RegularExpression("[A-Z]{2}[0-9]{3}[A-Z]{2}")]
        public string Immatriculation { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date de naissance")]
        public DateTime DateNaissance { get; set; }
        public bool Inscrit { get; set; }
    }
}