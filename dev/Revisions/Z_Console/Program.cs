using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2_Metier;

namespace Z_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quelle couche de données ?");
            Console.WriteLine("3. Base de données");
            Console.WriteLine("5. Données fictives");
            var couche = Console.ReadLine();

            // Etape 1 - 6
            var ds1 = Personnes.GetPersonnes((SourceEnum)Enum.Parse(typeof(SourceEnum), couche));

            foreach(DataRow row in ds1.Tables["Personne"].Rows)
            {
                Console.WriteLine("{0}. {1}", row["Id"], row["NomComplet"]);
            }
            Console.ReadKey();
        }
    }
}
