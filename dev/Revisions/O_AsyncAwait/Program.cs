using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2_AsyncAwait
{
    internal class Program
    {
        #region Exemple 1
        //static void Main(string[] args)
        //{
        //    Method1();
        //    Method2();
        //    Console.ReadLine();
        //}

        //public static async Task Method1()
        //{
        //    await Task.Run(() =>
        //    {
        //        for (int i = 0; i < 100; i++)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("{0}: {1}", "Méthode 1", i);
        //            Task.Delay(100).Wait();
        //        }
        //    });
        //}
        //public static void Method2()
        //{
        //    for (int i = 0; i < 25; i++)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Blue;
        //        Console.WriteLine("{0}: {1}", "Méthode 2", i);
        //        Task.Delay(100).Wait();
        //    }
        //}
        #endregion
        #region Exemple 2
        static void Main(string[] args)
        {
            CallMethods();
            Console.ReadLine();
        }

        private static async void CallMethods()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}: {1}", "Méthode 1", i);
                    count++;
                }
            });
            return count;   
        }
        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0}: {1}", "Méthode 2", i);
                Task.Delay(100).Wait();
            }
        }
        public static void Method3(int count)
        {
            Console.WriteLine("{0}: {1}", "Méthode 3 - count=", count);
        }
        #endregion
    }
}
