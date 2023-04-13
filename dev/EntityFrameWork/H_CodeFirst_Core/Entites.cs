using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_CodeFirst_Core
{
    // Install-Package Microsoft.EntityFrameworkCore.SqlServer
    // Install-Package Microsoft.EntityFrameworkCore.Tools -Version 7.0.5
    // Add-Migration CreateSchoolDB
    // update-database –verbose
    // https://1drv.ms/u/s!AmBkQr-1-ilzhIg2x-RbosXDajMP7A?e=36wS2V
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=SchoolDB;integrated security=True;trustServerCertificate=true");
        }
    }
}
