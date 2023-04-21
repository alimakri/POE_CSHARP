using A_Service1WCF;
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

            Service1 svc1 = new Service1();
            string t = svc1.Majuscule(s);


            Console.WriteLine(t);
            Console.ReadLine();
        }
    }
}
