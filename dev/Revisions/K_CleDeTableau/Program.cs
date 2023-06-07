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
            var personnes = new List<Personne>
            {
                new Personne{Id=1, Name="Jacques", NoSecu="1341293704046"},
                new Personne{Id=2, Name="Ali", NoSecu="1620869382220"},
                new Personne{Id=3, Name="Pierre", NoSecu="1980869382382"}
            };
            var p1 = personnes[1];
            var p2 = personnes["1620869382220"];
            Console.WriteLine("p1 et p2 sont les même personne", p1.Equals(p2));
        }
    }
    class Personne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NoSecu { get; set; }

    }
}
