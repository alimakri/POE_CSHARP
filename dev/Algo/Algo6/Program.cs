using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Construction du tableau
            int[] listeEntiers = { 54, 4, 89, 177, 1, 7, 11, 24 };

            // Recherche nombres impairs
            foreach (int i in listeEntiers)
            {
                if (i % 2 == 0) Console.WriteLine(i);
            }
            Console.ReadLine(); 
        }
    }
}
