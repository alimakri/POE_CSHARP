using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fluent API
            //Configure default schema
            //modelBuilder.HasDefaultSchema("Admin");

            //Map entity to table
            modelBuilder.Entity<Personne>().ToTable("Employees");
            modelBuilder.Entity<Ville>().ToTable("Cities", "dbo");

            //Configure primary key
            modelBuilder.Entity<Personne>().HasKey<Guid>(s => s.Cle);

            //Configure Column
            modelBuilder.Entity<Personne>()
                        .Property(p => p.DateNaissance)
                        .HasColumnName("DoB")
                        .HasColumnOrder(3)
                        .HasColumnType("datetime2");
        }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Ville> Villes { get; set; }
    }
    [Table("Employes")]
    public partial class Personne
    {
        public Guid Cle { get; set; }
        [Required]
        [StringLength(150)]
        public string Nom { get; set; }
        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }
        public int Age { get; set; }
        public DateTime DateNaissance { get; set; }
        [NotMapped]
        public decimal Argent { get; set; }
        [Column("Sexe")]
        public bool Genre { get; set; }
        public Auto Prius { get; set; }

        public List<Ville> Villes { get; set; }
    }
    public partial class Ville
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }

        public virtual List<Personne> Personnes { get; set; }
    }
    public class Auto
    {
        public long Id { get; set; }
    }
}
