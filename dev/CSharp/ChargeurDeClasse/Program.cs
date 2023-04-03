using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using u = ChargeurDeClasse.MondeVegetal;
using ChargeurDeClasse2;

namespace ChargeurDeClasse
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new u.Vegetal();
            var x = v.Nom;
            var y = v.TypeVegetal;

            var m = new Mineral();
            int i, j = 1;
        }
    }
    public class Personne
    {

    }
}
namespace ChargeurDeClasse2
{
    public partial class Vegetal
    {
        public int TypeVegetal;
    }
}
