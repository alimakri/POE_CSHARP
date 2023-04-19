using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piscine_DAL
{
    [Table("LesPiscines")]
    internal class Piscine
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public int Capacite { get; set; }
        public Acces LAcces { get; set; }
        public List<Activite> LesActivites { get; set; }
    }
    [Table("LesAcces")]
    internal class Acces
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public List<Piscine> LesPiscines { get; set; }
    }
    [Table("LesActivites")]
    internal class Activite
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime DateDebut { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime DateFin { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public Piscine UnePiscine { get; set; }
    }
    internal class OccupationContext : DbContext
    {
        public OccupationContext() : base("name=OccupationConfig")
        {

        }
        public DbSet<Activite> LesActivites { get; set; }
        public DbSet<Acces> LesAcces { get; set; }
        public DbSet<Piscine> LesPiscines { get; set; }
    }
}
