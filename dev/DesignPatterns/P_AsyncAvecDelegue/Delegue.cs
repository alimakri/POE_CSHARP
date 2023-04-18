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
        public void Execution(string message, int temps)
        {
            Thread.Sleep(1000 * temps);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exécution de la tâche {0}", message);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
    delegate void TacheDelegate(string a, int b);
}
