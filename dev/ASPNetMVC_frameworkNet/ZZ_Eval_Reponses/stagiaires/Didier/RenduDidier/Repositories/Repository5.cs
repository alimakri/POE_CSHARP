using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using ZZ_Eval.Models;

namespace ZZ_Eval.Repositories



{
    //public class Repository5
    //{
    //    internal bool Fill()
    //    {

    //    }
    //    internal object Get()
    //    {

    //    }
    //}
    // On crée le context de la bdd

    // COMMENTAIRE POUR EVITER BUG
    //public class Repository5 //: PlanteDB
    //{
    //    private PlanteContext Context = new PlanteContext();
    //    internal bool Fill(List<Plante> Articles)
    //    {
    //        foreach (var Article in Articles)
    //        {
    //            Context.Plantes.Add(Article);
    //            Context.SaveChanges();
    //        }
    //    }

    //    internal List<Plante> Get()
    //    {
    //        List<Plante> mesArticles = Context.Plantes.ToList();
    //        return mesArticles;
    //    }
    //}
    // j'implémente la classe plante DB qui a les champ ID et Nom 



    // PREMIER ESSAI

    // public class PlanteDB
    //{

    //    
    //    public PlanteDB
    //        {
    //        public int Id { get; set; }

    //    public string Nom { get; set; }
    //};
}
