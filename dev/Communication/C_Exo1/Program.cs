using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace C_Exo1
{
    internal class Program
    {
        private static WebClient ClientApi = new WebClient();
        static void Main(string[] args)
        {
            // Code à insérer ----------------------------------------------

            var liste = TousLesPays();

            // -------------------------------------------------------------

            // Ne pas changer
            Console.WriteLine("Liste des pays parlant français");
            foreach (var pays in liste)
            {
                
                Console.WriteLine(pays);
            }
            Console.ReadLine();
        }

        static List<Pays> TousLesPays()
        {
            string url = $"https://restcountries.com/v3.1/lang/french"; 
            var data = ClientApi.DownloadString(new Uri(url));
            try
            {
                var liste = JsonConvert.DeserializeObject<List<Pays>>(data);
                if (liste != null || liste.Count != 0)
                    return liste;
            }
            catch (Exception)
            {
            }
            return new List<Pays>();
        }
    }
    internal class Pays
    {
        public NamePart Name;
        public List<string> Capital;
        public override string ToString()
        {
            return Name.Common;
        }

    }

    public class NamePart
    {
        public string Common;
        public string Official;
        public object NativeName;
    }
}
