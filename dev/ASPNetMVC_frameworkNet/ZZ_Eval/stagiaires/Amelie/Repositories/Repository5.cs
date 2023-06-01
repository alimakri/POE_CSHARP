using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZB_Eval.Models;

namespace ZZ_Eval.Repositories
{
    public class Repository5
    {
        private ArticleContext Context = new ArticleContext();
        internal void Fill(List<Plante> Articles)
        {
            foreach (var Article in Articles)
            {
                Context.Plantes.Add(Article);
                Context.SaveChanges();
            }
        }

        internal List<Plante> Get()
        {
            List<Plante> Mes_articles = Context.Plantes.ToList();
            return Mes_articles;
        }

    }

}