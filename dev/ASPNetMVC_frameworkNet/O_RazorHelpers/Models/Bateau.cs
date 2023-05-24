using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace O_RazorHelpers.Models
{
    public enum SousMarinEnum { None, SNA, SNLE}
    public class SousMarin
    {
        public int Id { get; set; }
        public SousMarinEnum Type { get; set; }
        [DisplayName("Nom du bâtiment")]
        [Required(ErrorMessage ="Précisez le nom")]
        public string Nom { get; set; }
        [DisplayName("A quai")]
        public bool AQuai { get; set; }
    }
}