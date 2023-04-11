using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_CodeFirst1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new HabitantContext();
            var p1 = context.Personnes.FirstOrDefault();
            
            // Insert personne
        }
    }
}
