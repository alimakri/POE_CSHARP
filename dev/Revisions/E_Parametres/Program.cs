using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Parametres
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculatrice();
            var op1 = 7;
            var op2 = 5;
            var operation = /*new OpDelegate(calc.Addition)*/;
            var resultat = calc.Calculer(op1, op2, operation);

            Console.WriteLine(resultat);
            Console.ReadLine();
        }
    }
    //public delegate int OpDelegate(int a, int b);
    public class Calculatrice
    {

        public object Calculer(int op1, int op2, /*OpDelegate*/ operation)
        {
            return /*operation.Invoke(op1, op2);*/
        }
        public int Addition(int op1, int op2) { return op1 + op2; }
        public int Multiplication(int op1, int op2) { return op1 * op2; }
    }
}
