using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_LambdaExpression
{
    delegate bool PariteDelegue(int n);
    class Program
    {
        static void Main(string[] args)
        {
            List<int> resultat = new List<int>();
            var nombres = new List<int> { 2, 8, 9, 6, 7, 12, 17, 25, 39, 1 };

            Compute(nombres, resultat, new PariteDelegue(isImpaire));
        }

        private static void Compute(List<int> nombres, List<int> resultat, PariteDelegue f)
        {
            foreach (var nombre in nombres)
            {
                if (f(nombre)) resultat.Add(nombre);
            }
        }

        static bool isPaire(int n) { return n % 2 == 0; }
        static bool isImpaire(int n) { return n % 2 == 1; }
    }
}
