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
            var tache3 = new Tache();

            Console.WriteLine(DateTime.Now);

            #region Versions
            // Version 1
            //tache1.Execution("Tâche 1", 5);
            //tache2.Execution("Tâche 2", 3);

            // Version 2
            //var dTache1 = new TacheDelegate(tache1.Execution);
            //var dTache2 = new TacheDelegate(tache2.Execution);
            //dTache1.Invoke("Tâche 1", 5);
            //dTache1.Invoke("Tâche 2", 3);
            #endregion

            // Version 3
            //var dTache1 = new TacheDelegate(tache1.Execution);
            //var dTache2 = new TacheDelegate(tache2.Execution);
            //var dTache3 = new TacheDelegate(tache3.Execution);

            //var dRetourTache1 = new AsyncCallback(tache1.RetourExecution);
            //var dRetourTache2 = new AsyncCallback(tache2.RetourExecution);

            //dTache1.BeginInvoke("T1", "Tâche 1", 5, dRetourTache1, "Retour tâche 1");
            //dTache1.BeginInvoke("T2", "Tâche 2", 3, dRetourTache2, "Retour tâche 2");
            //dTache3("T3", "Tâche 2", 3);
            //Console.WriteLine(tache3.P.Nom); // Processus inter-thread sont interdits
            //Console.WriteLine(DateTime.Now);

            // Version 3bis
            var dTache1 = new TacheDelegate(tache1.Execution);
            var dTache2 = new TacheDelegate(tache2.Execution);
            var dTache3 = new TacheDelegate(tache3.Execution);

            dTache1.BeginInvoke("T1", "Tâche 1", 5, tache1.RetourExecution, "Retour tâche 1");
            dTache1.BeginInvoke("T2", "Tâche 2", 3, tache2.RetourExecution, "Retour tâche 2");
            dTache3("T3", "Tâche 2", 3);
            Console.WriteLine(tache3.P.Nom); // Processus inter-thread sont interdits
            Console.WriteLine(DateTime.Now);

            Console.ReadLine();
        }
    }
}
