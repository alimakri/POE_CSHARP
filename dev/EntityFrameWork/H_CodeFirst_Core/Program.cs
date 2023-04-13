// See https://aka.ms/new-console-template for more information
using H_CodeFirst_Core;

Console.WriteLine("Hello, World!");
var context = new SchoolContext();
context.Students.Add(new Student { Name = "Roger" });
context.SaveChanges();