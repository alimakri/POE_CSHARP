using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegueFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var d1 = new Action(Afficher);
            d1();

            var d2 = new Func<int, decimal, string>(AfficherFunc);
            d2(0, 3.14M);

            var d3 = new Action<string>(AfficherAction2);
            d1();
        }
        static void AfficherAction2(string s)
        {
            Console.WriteLine("Delegue avec la classe Action");
        }
        static void Afficher()
        {
            Console.WriteLine("Delegue avec la classe Action");
        }
        static string AfficherFunc(int i, decimal m)
        {
            Console.WriteLine("Delegue avec la classe Func");
            return "";
        } 
    }
}
