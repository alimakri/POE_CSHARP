using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoriel
{
    class Program
    {
        static void Main(string[] args)
        {
            // n! = n * (n-1)!
            var x = Outils.Factoriel(7); // 7*6*5*4*3*2*1
            Console.WriteLine(x);// 5040
            Console.ReadLine();
        }
    }
    public static class Outils
    {
        //public static long Factoriel(int n)
        //{
        //    if (n == 0) return 1;
        //    if (n == 1) return 1; 
        //    return n * Factoriel(n - 1);
        //}
    }
}
