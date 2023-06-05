using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_A_Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoussoleEnum direction = BoussoleEnum.Nord | BoussoleEnum.Est;
            var c = CouleurEnum.Rouge | CouleurEnum.Vert | CouleurEnum.Bleu;

            if ((c & CouleurEnum.Rouge) == CouleurEnum.Rouge)
            {

            }
            Console.WriteLine("Valeur de {0} = {1}", 
                direction.ToString(), (int)direction);
        }
    }
    [Flags]
    enum BoussoleEnum { Nord = 1, Sud = 2, Est = 4, Ouest = 8, NordEst = BoussoleEnum.Nord & BoussoleEnum.Est }
    [Flags]
    enum CouleurEnum { Rouge = 1, Vert = 2, Bleu = 4 }
}
