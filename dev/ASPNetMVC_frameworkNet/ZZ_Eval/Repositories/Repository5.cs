using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZZ_Eval.Repositories
{
    public class Repository5
    {
        private PlanteContext Context = new PlanteContext();
        internal bool Fill()
        {
            if (Context.Plantes.Count() == 0)
            {
                Context.Plantes.Add(new Plante { Id = 1, Nom = "Acaccia faux robinetier" });
                Context.Plantes.Add(new Plante { Id = 2, Nom = "Ficus" });
                Context.Plantes.Add(new Plante { Id = 3, Nom = "Baobab" });
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        internal List<Plante> Get()
        {
            return Context.Plantes.ToList();
        }
    }
    public class Plante
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }
    public class PlanteContext : DbContext
    {
        public PlanteContext() : base("name=PlanteDB")
        {

        }
        public DbSet<Plante> Plantes { get; set; }
    }

}