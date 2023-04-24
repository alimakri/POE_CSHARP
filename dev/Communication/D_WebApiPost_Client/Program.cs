using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace D_WebApiPost_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new OpticienApi();
            service.GetAll(ConsoleColor.Cyan);
            service.AddByUrl(1, "Strasbourg", "Krys");
            service.AddByBody(new Opticien { Id = 2, Nom = "General Optique", Ville = "Lyon" });
            service.UpdateVille(2,  new Opticien { Ville = "Marseille" });
            service.Delete(2);
            service.GetAll(ConsoleColor.Green);
            Console.ReadLine();
        }
    }
    internal class OpticienApi
    {
        private static WebClient ClientApi = new WebClient();

        internal void AddByUrl(int id, string ville, string nom)
        {
            var url = $"http://localhost:1234/api/opticien/?id={id}&nom={nom}&ville={ville}";
            ClientApi.UploadString(url, "POST");
        }
        internal void AddByBody(Opticien opticien)
        {
            var url = $"http://localhost:1234/api/opticien/";
            ClientApi.Headers.Add("Content-Type", "application/json");
            ClientApi.UploadString(url, "POST", JsonConvert.SerializeObject(opticien));
        }

        internal void GetAll(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            var data = ClientApi.DownloadString("http://localhost:1234/api/opticien");
            try
            {
                var liste = JsonConvert.DeserializeObject<List<Opticien>>(data);
                foreach (var opticien in liste)
                {
                    Console.WriteLine("{0} - {1}", opticien.Nom, opticien.Ville);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal void Delete(int idOpticien)
        {
            var url = $"http://localhost:1234/api/opticien/?delete={idOpticien}";
            ClientApi.UploadString(url, "POST");
        }

        internal void UpdateVille(int id, Opticien opticien)
        {
            var url = $"http://localhost:1234/api/opticien/?id={id}";
            ClientApi.Headers.Add("Content-Type", "application/json");
            ClientApi.UploadString(url, "POST", JsonConvert.SerializeObject(opticien));
        }
    }
    class Opticien
    {
        public int Id;
        public string Nom;
        public string Ville;
    }
}
