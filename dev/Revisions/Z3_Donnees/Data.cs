using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z4_Dto;

namespace Z3_Donnees
{
    public static class Data
    {
        private static Repository Repo = new Repository();
        public static DataSet2 GetPersonnes()
        {
            // Etape 3
            return Repo.GetEmployes();
        }
        public static DataSet2 GetDetails(int idPersonne)
        {
            // Etape 3
            return Repo.GetDetails(idPersonne);
        }

    }
}
