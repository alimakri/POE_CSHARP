using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace ZZ_Eval.Repositories
{
	public class Plante
	{
		public int Id { get; set; }
		public string Nom { get; set; }
	}
	public class Repository5
	{
		public class PlanteContext : DbContext
		{
			public PlanteContext() : base("name=PlanteDB")
			{

			}
			public DbSet<Plante> Plantes { get; set; }
		}

		private PlanteContext Context = new PlanteContext();

		internal bool Fill()
		{
			if (Context.Plantes.Count() == 0)
			{
				Context.Plantes.Add(new Plante { Id = 1, Nom = "Accacia faux robinetier" });
				Context.Plantes.Add(new Plante { Id = 2, Nom = "Ficcus" });
				Context.Plantes.Add(new Plante { Id = 3, Nom = "Baoba" });
				Context.SaveChanges();
				return true;
			}
			return false;
		}

		internal object Get()
		{
			return Context.Plantes.ToList();
		}
	}
}