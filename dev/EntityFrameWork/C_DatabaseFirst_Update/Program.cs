using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_DatabaseFirst_Update
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var candidats = GetCandidates(false);
            foreach(var candidat in candidats)
            {
                Console.WriteLine(candidat);
            }
            Console.ReadLine();
        }

        private static List<string> GetCandidates(bool embauche)
        {
            var context = new AdvContext();
            return context.JobCandidates
                .Where(x => (embauche && x.Employee != null) || (!embauche && x.Employee == null))
                .Select(x => x.Employee.Person.FullName)
                .ToList();
        }
    }
}
