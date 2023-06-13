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
        public static DataSet1 Get(string couche)
        {
            // Etape 2 - 4
            DataSet2 ds2 = null;
            var method = $"Z{couche}_Donnees.DataPersonnes.Get";
            switch (couche)
            {
                case "3":  ds2 = Z3_Donnees.DataPersonnes.Get(); break;
                case "5":  ds2 = Z5_Donnees.DataPersonnes.Get(); break;
            }

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
