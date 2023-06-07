using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.ReadLine();
            // -------------------------
            var t1 = new Tache();
            var action = new Action<int, ConsoleColor, string>(t1.Go);


            action.BeginInvoke(2, ConsoleColor.Cyan, "A", new AsyncCallback(t1.Fin), "Compteur 1"); // 7 s
            action.BeginInvoke(1, ConsoleColor.Red, "B", new AsyncCallback(t1.Fin), "Compteur 2"); // 7 s
            // -------------------------

            Console.ReadLine();
        }
    }
    class Tache
    {
        public void Go(int k, ConsoleColor c, string nom)
        {
            for (int i = 0; i < k * 50000; i++)
            {
                Console.ForegroundColor = c;
                Console.WriteLine($"{nom} - {i}");
            }
        }
        public void Fin(IAsyncResult res)
        {
            Console.WriteLine("Fin de l'action: " + (string)res.AsyncState);
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
    }
}
