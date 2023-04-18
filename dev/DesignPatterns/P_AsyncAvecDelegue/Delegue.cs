using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_AsyncAvecDelegue
{
    public class Tache
    {
        public Personne P;
        public void Execution(string nom, string message, int temps)
        {
            if (P == null) P = new Personne { Nom = nom };
            Thread.Sleep(1000 * temps);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exécution de la tâche {0}", message);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void RetourExecution(IAsyncResult r)
        {
            string message = r.AsyncState as string;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0} : {1}", message, DateTime.Now);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
    delegate void TacheDelegate(string a, string b, int c);
    public class Personne
    {
        public string Nom;
    }
}
