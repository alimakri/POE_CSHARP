using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Q_AsyncTask_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tache1 = new Task(Execution);
            var tache2 = new Task(Execution);
            Console.WriteLine(DateTime.Now);

            //tache1.Start();
            Task.WaitAll(new Task[] { tache1, tache2 });
            Console.WriteLine("Fin des tâches");
            Console.WriteLine(DateTime.Now);

            Console.ReadLine();
        }
        static void Execution()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Fin");
        }
    }
}
