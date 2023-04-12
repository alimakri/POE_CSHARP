using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_CodeFirst_Exo1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Piscine
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public int Capacite { get; set; }
        public Acces UnAcces { get; set; }
    }
    public class Acces
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public Piscine UnePiscine { get; set; }
    }
}
