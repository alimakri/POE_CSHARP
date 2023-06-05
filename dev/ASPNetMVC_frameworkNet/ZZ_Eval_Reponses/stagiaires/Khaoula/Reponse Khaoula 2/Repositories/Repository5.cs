using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZZ_Eval.Repositories
{
    public class Repository5
    {
        private PlanteContext DbContext = new PlanteContext();



        public bool Fill()
        {
            if (DbContext.PlanteDB.Any())
            {
                return false;
            }

            var plantes = new List<Plante>
        {
            new Plante { Nom = "Plante 1" },
            new Plante { Nom = "Plante 2" },
            new Plante { Nom = "Plante 3" }
        };

            DbContext.PlanteDB.AddRange(plantes);
            DbContext.SaveChanges();

            return true; 
        }

        public List<Plante> Get()
        {
            return DbContext.PlanteDB.ToList();
        }
    }

    public class Plante
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }

    public class PlanteContext : DbContext //: ma base de donnees 
    {
        public PlanteContext() : base("name=PlanteDB")
        {
        }
        public DbSet<Plante> PlanteDB { get; set; }
    }
}