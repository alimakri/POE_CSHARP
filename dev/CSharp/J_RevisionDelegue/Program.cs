using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RevisionDelegue
{
    delegate int Operation(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Operation(Addition);
            var c = new Calculatrice(d);
            var resultat = c.Calculer(3, 7);
            
        }
        static int Addition(int a, int b) { return a + b; }
        static int Multiplication(int a, int b) { return a * b; }
    }
    class Calculatrice
    {
        private Operation Op = null;
        public Calculatrice(Operation delegue)
        {
            Op = delegue;
        }
        public int Calculer(int op1, int op2)
        {
            return Op.Invoke(op1, op2);
        }
    }
}
