using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_UnitTest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new Calculatrice();
            var resultat1 = c.Multiplication(3, 7);
            Console.WriteLine(resultat1);
            var resultat2 = c.Division(3, 7);
            Console.WriteLine(resultat2);
            Console.ReadLine();
        }
    }
    public class Calculatrice
    {
        public decimal Multiplication(decimal op1, decimal op2) { return op1 * op2; }
        public decimal Division(decimal op1, decimal op2) { return op1 / op2; }
    }
}
