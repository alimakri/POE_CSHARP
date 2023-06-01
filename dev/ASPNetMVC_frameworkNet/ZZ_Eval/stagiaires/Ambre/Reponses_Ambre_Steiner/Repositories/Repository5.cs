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
            var premierElement = Context.PlanteDB.FirstOrDefault();
            if (premierElement==null)
            {
                var plante = new Plante();
                Context.PlanteDB.Add(plante);
                Context.SaveChanges();
                return true;
            }
            else { return false; }


        }

        internal object Get()
        {
            return Context.PlanteDB.ToList();
        }

        public class Plante
        {
            public int Id { get; set; }
            public string Nom { get; set; }


        }

        public class PlanteContext : DbContext
        {
            public PlanteContext() : base("name=PlanteConfig")
            {

            }

            public DbSet<Plante> PlanteDB { get; set; }


        }
    }
}