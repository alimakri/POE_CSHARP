using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace J_XmlHttp_.Controllers
{
    public class DataController : ApiController
    {
        public string Get() { return "hello"; }
        public string Post(int id)
        {
            if (id==1) return JsonConvert.SerializeObject(new Personne { Nom = "MAKRI", Prenom = "Ali" });
            else return JsonConvert.SerializeObject(new Personne { Nom = "Dupont", Prenom = "Pierre" });
        }
    }
    public class Personne { public string Nom { get; set; } public string Prenom { get; set; } }
}
