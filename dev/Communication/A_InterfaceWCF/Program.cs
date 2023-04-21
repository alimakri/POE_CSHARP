using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_InterfaceWCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Ali Makri";
            string t = Majuscule(s);


            Console.WriteLine(t);
            Console.ReadLine();
        }
        static string Majuscule(string s)
        {
            return s.ToUpper();
        }
    }
}
