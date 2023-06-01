using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZZ_Eval.Repositories
{
    public class Repository5
    {
        private PlanteDB Context = new PlanteDB();
        internal bool Fill()
        {
            if (!Context.Plantes.Any())
            {

                var plantes = new List<Plante>
        {
            new Plante { Nom = "Accacia faux robinetier" },
            new Plante { Nom = "Ficcus" },
            new Plante { Nom = "Baobab" }
        };

                Context.Plantes.AddRange(plantes);
                Context.SaveChanges();return true;
            }
            else { return false; }
            
        }

        internal object Get()
        {
            return Context.Plantes.ToList(); ;
        }
    }
    public class Plante
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }
    public class PlanteDB : DbContext
    {
        public PlanteDB() : base("name=PlanteDB")
        {

        }
        public DbSet<Plante> Plantes { get; set; }
    }
}