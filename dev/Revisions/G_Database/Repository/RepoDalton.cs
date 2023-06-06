using G_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Database.Repository
{
    public class RepoDalton
    {
        public List<Personne> Get()
        {
            return new List<Personne>
            {
                    new Personne { Nom = "Dalton", Prenom = "Joe" },
                    new Personne { Nom = "Dalton", Prenom = "Jack" },
                    new Personne { Nom = "Dalton", Prenom = "William" },
                    new Personne { Nom = "Dalton", Prenom = "Averel" },
            };
        }
    }
}
