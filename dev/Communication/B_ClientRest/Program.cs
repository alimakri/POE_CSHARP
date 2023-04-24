using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace B_ClientRest
{
    internal class Program
    {
        private static WebClient ClientApi = new WebClient();
        static void Main(string[] args)
        {
            //TousLesPaysEnBrut();
            DataPays("France");
            Console.ReadLine();
        }
        // GET
        static void TousLesPaysEnBrut()
        {
            string url = "https://restcountries.com/v3.1/all";
            var data = ClientApi.DownloadString(url);
            Console.WriteLine(data);

        }
        // GET avec paramètre
        static void DataPays(string name)
        {
            string url = $"https://restcountries.com/v3.1/name/{name}"; // MVC
            var data = ClientApi.DownloadString(new Uri(url));
            try
            {
                var liste = JsonConvert.DeserializeObject<List<Pays>>(data);
                if (liste == null && liste.Count == 0)
                    Console.WriteLine("Ce pays n'est pas renseigné");
                else
                    Console.WriteLine("{0}: {1} ({2}). Capital: {3}",
                        name, liste[0].Name.NativeName.fra.Official,
                        liste[0].Name.NativeName.fra.Common, liste[0].Capital[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    internal class Pays
    {
        public NamePart Name;
        public List<string> Capital;

    }

    public class NamePart
    {
        public string Common;
        public string Official;
        public NativeName NativeName;
    }
    public class NativeName
    {
        public NativeNameDetail fra;
    }
    public class NativeNameDetail
    {
        public string Official;
        public string Common;
    }
}
