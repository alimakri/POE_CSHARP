using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;

namespace D_WebApiPost_Serveur.Controllers
{
    public class OpticienController : ApiController
    {
        private List<Opticien> ListeOpticiens;
        public OpticienController()
        {

            //ListeOpticiens = new List<Opticien>
            //{
            //    new Opticien{ Nom="Strasbourg", Ville="Krys" },
            //    new Opticien{ Nom="Optic 2000", Ville="Lyon" },
            //    new Opticien{ Nom="Afflelou", Ville="Nancy" },
            //};

        }
        public IEnumerable<Opticien> Get()
        {
            return ListeOpticiens;
        }
        public void Post(string nom, string ville)
        {
           //ListeOpticiens.Add(new Opticien{ Nom=nom, Ville=ville });
        }
        private void SerialisationXML(List<Opticien> liste)
        {
            var serialiser = new XmlSerializer(typeof(List<Opticien>));
            var flux = new StreamWriter(@"d:\lesOpticiens.txt");
            serialiser.Serialize(flux, liste);
            flux.Close();
        }
        private List<Opticien> DeserialisationXML()
        {
            var serialiser = new XmlSerializer(typeof(List<Opticien>));
            var flux = new StreamReader(@"d:\lesOpticiens.txt");
            var liste = (List<Opticien>)serialiser.Deserialize(flux);
            flux.Close();
            return liste;
        }
    }
    public class Opticien
    {
        public string Nom;
        public string Ville;
    }
}
