using C_Todo_V1.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace C_Todo_V1.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public bool Fait { get; set; }
    }
    public class TodoContext : DbContext
    {
        public TodoContext() : base("name=TodoConfig")
        {

        }
        public DbSet<Todo> Todoes { get; set; }
    }
}