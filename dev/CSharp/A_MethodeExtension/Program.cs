using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_MethodeExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            //string phrase = "les sanglots longs des violons de l'automne";
            //int n = phrase.NombreDeMots(new char[] { '\'', ' ' });
            ////int n = OutilsString.NombreDeMots(phrase);

            var phrase = new StringBuilder("les sanglots longs des violons de l'automne");
            int n = phrase.NombreDeMots();
        }

    }
    public static class OutilsString
    {
        public static int NombreDeMots(this StringBuilder s )
        {
            return s.ToString().NombreDeMots();
        }
        public static int NombreDeMots(this string s)
        {
            return s.NombreDeMots(new char[] { '\'', ' ', ',', ';', ':' });
        }
        public static int NombreDeMots(this string s, char[] separators)
        {
            return s.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
