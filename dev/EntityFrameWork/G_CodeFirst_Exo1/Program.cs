using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            var context = new OccupationContext();
            var p1 = new Piscine { Nom = "Piscine 1", Capacite = 250 };
            var p2 = new Piscine { Nom = "Piscine 2", Capacite = 410 };
            var a1 = new Acces { Type = "Bus 45", LesPiscines = new List<Piscine> { p1, p2} };
            p1.LAcces = a1;
            context.LesPiscines.Add(p1);
            context.LesPiscines.Add(p2);
            context.LesAcces.Add(a1);
            context.SaveChanges();
        }
    }
    public class Piscine
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public int Capacite { get; set; }
        public Acces LAcces { get; set; }
        public List<Activite> LesActivites { get; set; }
    }
    public class Acces
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public List<Piscine> LesPiscines { get; set; }
    }
    public class Activite
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="DateTime2")]
        public DateTime DateDebut { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
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
