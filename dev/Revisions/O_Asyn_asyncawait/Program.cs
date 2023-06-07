using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_Asyn_asyncawait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Tableau();
            t1.Execute();
            Console.ReadLine();
        }

    }

    class Tableau
    {
        public async Task M1()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
        public async Task M2()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
        public async void Execute()
        {
            await M1();
            await M2();
        }
    }
}
