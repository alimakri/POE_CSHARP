using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z4_Dto;

namespace Z3_Donnees
{
    public static class DataPersonnes
    {
        private static Repository Repo = new Repository();
        public static DataSet2 Get()
        {
            // Etape 3
           return Repo.GetPersonnes();
        }
    }
}
