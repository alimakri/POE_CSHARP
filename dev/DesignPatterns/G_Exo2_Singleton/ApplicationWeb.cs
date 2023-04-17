using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Exo2_Singleton
{
    public class ApplicationWeb
    {
        public static int Connect
        {
            get
            {
                Compteur++;
                return Compteur;
            }
        }
        private ApplicationWeb()
        {
            Compteur = 0;
        }

        private static int Compteur;

        public static int Get()
        {
            return Compteur;
        }
    }
}
