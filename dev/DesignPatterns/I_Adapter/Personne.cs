using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Adapter
{
    public interface IPersonneAdapter
    {
        Personne GetPersonne();
    }


    public class PersonneAdapter : IPersonneAdapter
    {
        private ExternalPersonneApiService Service;

        public PersonneAdapter(ExternalPersonneApiService service)
        {
            Service = service;
        }

        public Personne GetPersonne()
        {
            var personneExterne = Service.GetPersonne();
            var noms = personneExterne.FullName.Split(' ');
            return new Personne
            {
                Id = personneExterne.Id,
                LastName = noms[0],
                FirstName = noms[1]
            };
        }
    }
    #region Classes
    public class ExternalPersonneApiService
    {
        public PersonneExternal GetPersonne() => new() { Id = 1, FullName = "MAKRI Ali" };

    }
    public class Personne
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class PersonneExternal
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    #endregion
}
