using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<int> i = 2;
            i = null;
            if (i.HasValue)
            {

            }
            string s = "jjhkjhjkhkjh";
            s = null;

            int? j = 2;

            Personne? p = null;

            string? t = "abc";
        }
    }
    class Personne
    {

    }
}
