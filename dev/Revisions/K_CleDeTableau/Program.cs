using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_CleDeTableau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personnes = new Personnes
            {
                new Personne{Id=1, Name="Jacques", NoSecu="1341293704046"},
                new Personne{Id=2, Name="Ali", NoSecu="1620869382220"},
                new Personne{Id=3, Name="Pierre", NoSecu="1980869382382"}
            };
            var p1 = personnes[1];
            var p2 = personnes["1620869382220"];
            var p3 = personnes[p1];
            Console.WriteLine("p1, p2 et p3 sont les mêmes personne: {0}", p1.Equals(p2) && p1.Equals(p3));
            Console.ReadLine();
        }
    }
    class Personnes : List<Personne>
    {
        public Personne this[string noSecu]
        {
            get
            {
                foreach (var p in this)
                {
                    if (p.NoSecu == noSecu) return p;
                }
                return null;
            }
        }
        public Personne this[Personne pRef]
        {
            get
            {
                foreach (var p in this)
                {
                    if (p.Equals(pRef)) return p;
                }
                return null;
            }
        }
    }
    class Personne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NoSecu { get; set; }
       
    }
}
