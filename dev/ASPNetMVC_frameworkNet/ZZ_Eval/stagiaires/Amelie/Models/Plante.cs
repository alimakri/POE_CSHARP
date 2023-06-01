using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZB_Eval.Models
{
    public class Plante
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nom de la plante")]
        public string Nom { get; set; }
    }

    public class ArticleContext : DbContext
    {
        public ArticleContext() : base("name=PlanteDB")
        {
        }
        public DbSet<Plante> Plantes { get; set; }
    }
}