using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZZ_Eval.Models;

namespace ZZ_Eval.ViewModels
{
    // TODO Question 1 
    
    public class Question1ViewModel
    {
        public List<Personne> Personnes { get; set; }
        public List<Voiture> Voitures { get; set; }
        public string Titre { get; set; }
    }
    
}