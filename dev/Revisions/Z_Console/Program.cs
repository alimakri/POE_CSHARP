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
            // Etape 1 - 6
            var ds1 = Personnes.Get();

            foreach(DataRow row in ds1.Tables[0].Rows)
            {
                Console.WriteLine("{0}. {1}", row["Id"], row["NomComplet"]);
            }
            Console.ReadKey();
        }
    }
}
