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
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            var t = new Tache();
            t.GoGlobal();

            watch.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
    class Tache
    {
        private List<int> Liste;
        public Tache()
        {
            Liste = new List<int>();
            for (int i = 0; i < 100000; i++) Liste.Add(i);

        }
        public async Task Go(IEnumerable<int> liste)
        {
            foreach (var id in liste) Console.WriteLine(id);
        }
        public async Task GoGlobal()
        {
            var t1 = new Tache();
            var t2 = new Tache();

            //t1.Go(Liste); // 8 416 ms

            await t1.Go(Liste.Take(50000));
            await t2.Go(Liste.Skip(50000).Take(50000));
        }
    }
}
