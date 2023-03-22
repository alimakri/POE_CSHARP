using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo8_Distance_Exo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Liste de ville 
            List<string> villes = new List<string> { "Paris", "Lyon", "Nancy", "Strasbourg", "Marseille" };

            // Liste de x
            List<int> lesX = new List<int> { 20, 28, 30, 40, 30 };

            // Liste de y
            List<int> lesY = new List<int> { 15, 30, 13, 16, 40 };

            // Distance la plus courte
            string depart = "?"; string arrivee = "?"; double distanceCourte = double.MaxValue;
            foreach (string villeD in villes)
            {
                foreach (string villeA in villes)
                {
                    if (villeD != villeA)
                    {
                        var indexD = villes.IndexOf(villeD);
                        var indexA = villes.IndexOf(villeA);

                        var distanceCalculee = Math.Sqrt(Math.Pow(lesX[indexA] - lesX[indexD], 2) + Math.Pow(lesY[indexA] - lesY[indexD], 2));

                        if (distanceCalculee < distanceCourte)
                        {
                            depart = villeD; arrivee = villeA; distanceCourte = distanceCalculee;
                        }
                    }
                }

            }
            Console.WriteLine("{0} - {1} est la distance la plus courte ({2})", depart, arrivee, distanceCourte);
            Console.ReadLine();
        }
    }
}
