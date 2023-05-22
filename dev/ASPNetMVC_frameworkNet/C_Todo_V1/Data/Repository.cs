using C_Todo_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C_Todo_V1.Data
{
    public class Repository
    {
        private TodoContext Context = new TodoContext();
        internal List<Todo> Get()
        {
            return Context.Todoes.ToList();
        }

        internal Todo Get(int id)
        {
            return Context.Todoes.FirstOrDefault(x => x.Id == id);
        }

        internal void Remove(int id)
        {
            var todo = Context.Todoes.FirstOrDefault(x => x.Id == id);
            if (todo == null) return;
            Context.Todoes.Remove(todo);
            Context.SaveChanges();
        }

        internal Todo Add()
        {
            var todo = new Todo();
            Context.Todoes.Add(todo);
            Context.SaveChanges();
            return todo;
        }
    }
}