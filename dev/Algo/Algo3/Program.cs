using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var resultat = Factoriel2(14);
        }

        private static int Factoriel2(int n)
        {
            if (n == 1) return 1;
            var resultat = n * Factoriel2(n - 1);
            return resultat;
        }

        static int Factoriel1(int n)
        {
            int resultat = 1;
            for(int i = n; i > 1; i--)
            {
                resultat = resultat * i;
            }
            return resultat;
        }
    }
}
