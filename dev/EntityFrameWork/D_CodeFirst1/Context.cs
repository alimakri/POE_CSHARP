using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_CodeFirst1
{
    public partial class HabitantContext : DbContext
    {
        public HabitantContext() : base("name=HabitantContext")
        {
        }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Ville> Villes { get; set; }
    }
    public partial class Personne
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public List<Ville> Villes { get; set; }
    }
    public partial class Ville
    {
        public long Id { get; set; }
        public string Nom { get; set; }

        public virtual List<Personne> Personnes { get; set; }
    }
}
