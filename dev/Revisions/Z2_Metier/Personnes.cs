using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z4_Dto;

namespace Z2_Metier
{
    public static class Personnes
    {
        public static DataSet1 Get()
        {
            // Etape 2 - 4
            var ds2 = Z5_Donnees.DataPersonnes.Get();

            // Etape 5
            var ds1 = new DataSet1();
            foreach(DataRow row2 in ds2.Tables[0].Rows)
            {
                var newRow1 = ds1.Tables[0].NewRow();
                newRow1["Id"] = row2["Id"];
                newRow1["NomComplet"] = row2["Prenom"] + " " + row2["Nom"];
                ds1.Tables[0].Rows.Add(newRow1);
            }
            return ds1;
        }
    }
}
