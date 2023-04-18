using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_AsyncAvecDelegue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var tache1 = new Tache();
            var tache2 = new Tache();

            Console.WriteLine(DateTime.Now);

            // Version 1
            //tache1.Execution("Tâche 1", 5);
            //tache2.Execution("Tâche 2", 3);

            // Version 2
            //var dTache1 = new TacheDelegate(tache1.Execution);
            //var dTache2 = new TacheDelegate(tache2.Execution);
            //dTache1.Invoke("Tâche 1", 5);
            //dTache1.Invoke("Tâche 2", 3);

            // Version 3
            var dTache1 = new TacheDelegate(tache1.Execution);
            var dTache2 = new TacheDelegate(tache2.Execution);
            dTache1.BeginInvoke("Tâche 1", 5, null, null);
            dTache1.Invoke("Tâche 2", 3);


            Console.WriteLine(DateTime.Now);

            Console.ReadLine();
        }
    }
}
