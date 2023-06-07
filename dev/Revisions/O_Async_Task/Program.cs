using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_Async_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.ReadLine();
            
            Task t1 = new Task(Go);
            Task t2 = new Task(Go);
            Task.WaitAll(new Task[] { t1, t2 });

            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.ReadLine();

        }
        static void Go()
        {
            for (int i = 0; i <50000; i++)
            {
                //Console.ForegroundColor = c;
                Console.WriteLine(i);
            }

        }
    }
}
