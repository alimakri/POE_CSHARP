using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Echec
{
    internal class Program
    {
        static List<string> echiquier = new List<string>(); string lettre;
        static string cavalier = "A1";
        static List<string> deplacementsPossibles = new List<string> { "1,2", "1,-2", "2,1", "2,-1", "-1,2", "-1,-2", "-2,1", "-2,-1" };
        static Random alea = new Random();
        static int compteur = 0;

        static void Main(string[] args)
        {
            string lettre;
            // Construction de l'échiquier
            for (int i = 65; i <= 72; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    lettre = ((char)i).ToString();
                    echiquier.Add(lettre + j.ToString());
                }
            }
            Console.WriteLine(cavalier);
            while (cavalier != "H8")
            {
                if (Deplacer())
                {
                    compteur++;
                    Console.WriteLine("{0}: {1}", compteur, cavalier);
                }
                else
                    Console.WriteLine("--");
            }
            Console.ReadLine();
        }

        private static bool Deplacer()
        {
            var d = alea.Next(1, 9);
            var depl = deplacementsPossibles[d - 1]; // "-2,1"
            var tab = depl.Split(',');
            var deplH = int.Parse(tab[0]);  // -2
            var deplV = int.Parse(tab[1]);  // -1
            var cavalierH = cavalier[0];    // A (65)
            var cavalierV = cavalier[1];    // 1

            cavalierH = (char)((int)cavalierH + deplH);
            if (cavalierH < 'A' || cavalierH > 'H') return false;
            cavalierV = (char)((int)cavalierV + deplV);
            if ((int)cavalierV - 48 < 1 || (int)cavalierV - 48 > 8) return false;

            cavalier = cavalierH + cavalierV.ToString();
            return true;
        }
    }
}
