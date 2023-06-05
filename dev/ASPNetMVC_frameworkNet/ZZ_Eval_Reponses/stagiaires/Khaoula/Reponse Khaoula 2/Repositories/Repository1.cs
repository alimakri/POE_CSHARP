using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZZ_Eval.Models;

namespace ZZ_Eval.Repositories
{
    public class Repository1
    {
        public List<Personne> GetLesPersonnes()
        {
            return new List<Personne>
            {
            new Personne{ Id=1, Nom="Ryan", DateNaissance=new DateTime(1998, 8, 18)},
            new Personne{ Id=2, Nom="Li", DateNaissance=new DateTime(2002, 10, 1), EstEmbauche=true},
            new Personne{ Id=3, Nom="Hazam", DateNaissance=new DateTime(2000, 3, 7)},
            };
        }

        internal List<Voiture> GetLesVoitures()
        {
            return new List<Voiture>
            {
            new Voiture{ Id=1, Nom="Renault Fuego"},
            new Voiture{ Id=2, Nom="Fiat Lancia"  }
            };
        }
    }
}