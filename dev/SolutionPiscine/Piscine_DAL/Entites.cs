using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piscine_DAL
{
    internal class OccupationContext : DbContext
    {
        public DbSet<Activite> LesActivites { get; set; }
        public DbSet<Acces> LesAcces { get; set; }
        public DbSet<Piscine> LesPiscines { get; set; }
        public DbSet<Config> LesConfigs { get; set; }
        public DbSet<Stat> LesStats { get; set; }

        public OccupationContext() : base("name=OccupationConfig")
        {
        }

        internal int EnregistrerActivite(ArrayList alActivite)
        {
            var newA = alActivite.ToActivite();
            LesActivites.Add(newA);
            SaveChanges();
            return newA.Id;
        }

        internal void EnregistrerDetailActivite(int idActivite, ArrayList alActivite)
        {
            var newD = alActivite.ToActiviteAvecDetail(idActivite);
            var activite = LesActivites.FirstOrDefault(x => x.Id == idActivite);
            activite.LesDetails.Add(newD);
            SaveChanges();
        }

        internal int EnregistrerAcces(ArrayList alAcces)
        {
            var newA = alAcces.ToAcces();
            LesAcces.Add(newA);
            SaveChanges();
            return newA.Id;
        }

        internal int EnregistrerPiscine(ArrayList alPiscine)
        {
            var p = alPiscine.ToPiscine();
            var pDansBdd = LesPiscines.FirstOrDefault(x => x.Nom == p.Nom);
            if (pDansBdd != null)
            {
                pDansBdd.Nom = p.Nom;
                pDansBdd.Occupation = p.Occupation;
                pDansBdd.Capacite = p.Capacite;
                p = pDansBdd;
            }
            else
            {
                LesPiscines.Add(p);
            }
            SaveChanges();
            return p.Id;
        }

        #region Piscine
        internal ArrayList GetPiscines(int idAcces)
        {
            var resultat = new List<Piscine>();
            if (idAcces == 0)
                resultat = LesPiscines.ToList();
            else
            {
                var acces = LesAcces.Include("LesPiscines").FirstOrDefault(x => x.Id == idAcces);
                if (acces != null) resultat = acces.LesPiscines;
            }
            return resultat.ToArrayList();
        }

        internal int EnregistrerConfig(ArrayList alConfig)
        {
            var newP = alConfig.ToConfig();
            LesConfigs.Add(newP);
            SaveChanges();
            return newP.Id;
        }
        #endregion
    }

    [Table("LesPiscines")]
    internal class Piscine
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public int Capacite { get; set; }
        public int Occupation { get; set; }
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
        public List<DetailActivite> LesDetails { get; set; }
    }
    [Table("LesDetailsActivites")]
    internal class DetailActivite
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int NombrePersonne { get; set; }

        public Activite LActivite { get; set; }
    }
    [Table("LesConfigs")]
    internal class Config
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Regex { get; set; }
    }
    [Table("LesStats")]
    internal class Stat
    {
        public int Id { get; set; }
        public DateTime DateStat { get; set; }
        public int Occupation { get; set; }
        public int UnePiscineId { get; set; }
        public Piscine UnePiscine { get; set; }
    }

}
