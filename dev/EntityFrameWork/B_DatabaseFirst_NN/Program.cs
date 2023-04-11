using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_DatabaseFirst_NN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var habitants = GetHabitants("Agen");
            foreach(var h in habitants)
            {
                Console.WriteLine(h.Nom);
            }
            Console.ReadLine();
        }

        private static IEnumerable<Personne> GetHabitants(string ville)
        {
            var context = new HabitantContext();
            return context.Personnes.Where(x => x.Villes.Any(y => y.Nom == ville));
        }
    }
}
