using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nombresImpairs = new List<int>();
            var nombres = new List<int> { 2, 8, 9, 6, 7, 12, 17, 25, 39, 1 };
            foreach(var nombre in nombres)
            {
                if (nombre % 2 == 1) nombresImpairs.Add(nombre);
            }
        }
        static bool isPaire(int n) { return n % 2 == 0; } 
    }
}
