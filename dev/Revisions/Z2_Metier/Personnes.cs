using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Z4_Dto;

namespace Z2_Metier
{
    public enum SourceEnum { None = 0, Real = 3, Fake = 5 }
    public static class Personnes
    {
        public static DataSet1 GetPersonnes(SourceEnum source)
        {
            var couche = (int)source;
            // Etape 2 - 4
            var method = $"Z{couche}_Donnees.DataPersonnes.Get";

            // Equivalent à Z{couche}_Donnees.Data.GetPersonnes();
            //(DataSet2)Assembly
            //    .LoadFrom($@"D:\POE_CSHARP\dev\Revisions\Z2_Metier\bin\Debug\Z{couche}_Donnees.dll")
            //    .GetType($"Z{couche}_Donnees.Data")
            //    .GetMethod("GetPersonnes")
            //    .Invoke(null, null);
            var ds2 = Z3_Donnees.Data.GetPersonnes();


            // Etape 5
            var ds1 = new DataSet1();
            foreach (DataRow row2 in ds2.Tables["Personne"].Rows)
            {
                var newRow1 = ds1.Tables["Personne"].NewRow();
                newRow1["Id"] = row2["Id"];
                newRow1["NomComplet"] = row2["Prenom"] + " " + row2["Nom"];
                ds1.Tables["Personne"].Rows.Add(newRow1);
            }

            return ds1;
        }

        public static DataSet1 GetDetails(SourceEnum source, int idPersonne)
        {
            var couche = (int)source;

            // Etape 2 - 4
            DataSet2 ds2 = null;
            var method = $"Z{couche}_Donnees.DataDetails.Get";

            // Equivalent à Z{couche}_Donnees.DataPersonnes.Get();
            ds2 = (DataSet2)Assembly
                .LoadFrom($@"D:\POE_CSHARP\dev\Revisions\Z2_Metier\bin\Debug\Z{couche}_Donnees.dll")
                .GetType($"Z{couche}_Donnees.Data")
                .GetMethod("GetDetails")
                .Invoke(null, new object[] { idPersonne } );

            var ds1 = new DataSet1();
            if (ds2 != null)
            {
                // Etape 5
                foreach (DataRow row2 in ds2.Tables["Detail"].Rows)
                {
                    var newRow1 = ds1.Tables["Detail"].NewRow();
                    newRow1["Magasin"] = row2["Magasin"];
                    ds1.Tables["Detail"].Rows.Add(newRow1);
                }
            }
            return ds1;
        }
    }
}
