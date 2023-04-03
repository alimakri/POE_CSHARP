using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12;
            int b = 1;
            int[] tab = new int[1];
            // Première solution
            //if (b != 0)
            //{
            //    var c = a / b;
            //}

            // 2e solution
            try
            {
                var c = a / b;
                b = 1;
                var d = tab[0];
                b = 2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                b = 3;
            }
            Console.WriteLine("Fin du programme");
            Console.ReadLine();
        }
    }
}
