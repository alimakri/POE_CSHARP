using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tables Per Hierarchy
namespace F_Datafirst_TPH
{
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
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    public class Student : Person
    {
        public DateTime EnrollmentDate { get; set; }
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
        public DbSet<Person> People { get; set; }
    }
}
