using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Attribut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jardin = new Jardinage();
            jardin.TaillerHaies();
        }
    }
    class Jardinage
    {
        public static string Outil = "";
        [Outil()]
        public void TaillerHaies()
        {
            if (Outil == "TailleHaie") Console.WriteLine("C'est bon !");   
        }
    }
    class OutilAttribute : Attribute
    {
        public OutilAttribute()
        {
            Jardinage.Outil = "TailleHaie";
        }
    }

}
