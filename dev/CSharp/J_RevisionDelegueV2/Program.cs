using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RevisionDelegue
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Calculatrice((x, y) => x + y);
            //var c = new Calculatrice((x, y) =>
            //{
            //    double total = 1;
            //    for (int i = 1; i <= y; i++)
            //    {
            //        total *= x;
            //    }
            //    return total;
            //});
            var resultat = c.Calculer(3, 7);
        }
    }
    class Calculatrice
    {
        private Func<double, double, double> Op = null;
        public Calculatrice(Func<double, double, double> delegue)
        {
            Op = delegue;
        }
        public double Calculer(double op1, double op2)
        {
            return Op(op1, op2);
        }
    }
}
