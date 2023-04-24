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
            ListeOpticiens = DeserialisationXML();

        }
        public IEnumerable<Opticien> Get()
        {
            return ListeOpticiens;
        }
        [HttpPost]
        public void Post(int id, string nom, string ville)
        {
            ListeOpticiens.Add(new Opticien { Id = id, Nom = nom, Ville = ville });
            SerialisationXML();
        }
        public void Post(Opticien opticien)
        {
            ListeOpticiens.Add(opticien);
            SerialisationXML();
        }
        public void PostUpdate(int id, Opticien newOpticien)
        {
            var opticien = ListeOpticiens.FirstOrDefault(x => x.Id == id);
            if (opticien != null)
            {
                opticien.Ville = newOpticien.Ville;
            }
            SerialisationXML();
        }
        public void Post(int delete)
        {
            var opticien = ListeOpticiens.FirstOrDefault(x => x.Id == delete);
            if (opticien != null)
            {
                ListeOpticiens.Remove(opticien);
                SerialisationXML();
            }
        }
        private void SerialisationXML()
        {
            var serialiser = new XmlSerializer(typeof(List<Opticien>));
            var flux = new StreamWriter(@"d:\lesOpticiens.txt");
            serialiser.Serialize(flux, ListeOpticiens);
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
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }
    }
}
