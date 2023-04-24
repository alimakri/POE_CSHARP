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
            service.GetAll();
            service.AddByUrl("Strasbourg", "Krys");
            //service.GetAll();
            Console.ReadLine();
        }
    }
    internal class OpticienApi
    {
        private static WebClient ClientApi = new WebClient();

        internal void AddByUrl(string ville, string nom)
        {
            var url = $"http://localhost:1234/api/opticien/?nom={nom}&ville={ville}";
            ClientApi.UploadString(url, "POST");
        }

        internal void GetAll()
        {
            var data = ClientApi.DownloadString("http://localhost:1234/api/opticien");
            try
            {
                var liste = JsonConvert.DeserializeObject<List<Opticien>>(data);
               foreach(var opticien in liste)
                {
                    Console.WriteLine("{0} - {1}", opticien.Nom, opticien.Ville);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Opticien
    {
        public string Nom;
        public string Ville;
    }
}
