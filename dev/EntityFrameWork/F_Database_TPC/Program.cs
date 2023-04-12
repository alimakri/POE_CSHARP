using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Database_TPC
{
    // Tables Per Class

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EntityContext())
            {
                var student = new Student()
                {
                    FullName = "Mark",
                    EnrollmentDate = DateTime.Now
                };
                var teacher = new Teacher()
                {
                    FullName = "John",
                    HireDate = DateTime.Now
                };
                context.People.Add(student);
                context.People.Add(teacher);
                context.SaveChanges();
            }
        }
    }
    public abstract class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    public class Student : Person
    {
        public DateTime EnrollmentDate { get; set; }
        [NotMapped]
        public int Test { get; set; }
    }
    public class Teacher : Person
    {
        public DateTime HireDate { get; set; }
    }
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=EntityContextConfig")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Students");
            });
            modelBuilder.Entity<Teacher>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Teachers");
            });
        }
        public DbSet<Person> People { get; set; }
    }
}
