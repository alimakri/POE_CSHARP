using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
        public int Capacite { get; set; }
        public Acces UnAcces { get; set; }
    }
    public class Acces
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public Piscine UnePiscine { get; set; }
    }
    public class Activite
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public DateTime DateFin { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public Piscine UnePiscine { get; set; }
    }
    public class OccupationContext : DbContext
    {
        public OccupationContext() : base("name=OccupationConfig")
        {

        }
        public DbSet<Activite> LesActivites { get; set; }
        public DbSet<Acces> LesAcces { get; set; }
        public DbSet<Piscine> LesPiscines { get; set; }
    }
}
