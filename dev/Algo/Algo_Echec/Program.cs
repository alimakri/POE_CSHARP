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

            Deplacer();
        }

        private static void Deplacer()
        {

        }
    }
}
