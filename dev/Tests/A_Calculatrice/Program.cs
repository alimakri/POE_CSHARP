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
            Console.WriteLine(resultat1); decimal resultat2;
            if ( c.TryDivision(3, 7, out resultat2))
            Console.WriteLine(resultat2);
            else
                Console.WriteLine("pas ok");
            Console.ReadLine();
        }
    }
    public class Calculatrice
    {
        public decimal Multiplication(decimal op1, decimal op2) { return op1 * op2; }
        public bool TryDivision(decimal op1, decimal op2, out decimal resultat)
        {
            resultat = 0;
            if (op2 == 0) return false;
            resultat = op1 / op2;
            return true;
        }
    }
}
