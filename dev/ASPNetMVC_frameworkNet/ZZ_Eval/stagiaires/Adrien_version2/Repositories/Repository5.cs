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
            if (Context.Database.Exists()) // J'ai tenté un .Count() mais je n'ai pas réussi, sûrement à discuter je n'ai pas compris pq
                return false;
            else {
                List<Plante> plantes = new List<Plante>
            {
                new Plante{Id = 1, Nom = "Accacia faux robinetier"},
                new Plante{Id = 2, Nom = "Ficcus"},
                new Plante{Id = 3,Nom = "Baobab"}
            };
                Context.Plantes.AddRange(plantes);
                Context.SaveChanges();
                return true;
            }
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
        public PlanteContext() : base("name=PlanteConfig")
        {

        }
        public DbSet<Plante> Plantes { get; set; }
    }
}