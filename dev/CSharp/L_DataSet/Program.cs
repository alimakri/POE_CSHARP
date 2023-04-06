using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_DataSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ds = new DataSetPersonne();
            var tableVille = ds.Tables["Ville"];
            var row1 = tableVille.NewRow();
            row1["Nom"] = "Toulouse";
            tableVille.Rows.Add(row1);
            ds.AcceptChanges();

            var tablePersonne = ds.Tables["Personne"];
            var row2 = tablePersonne.NewRow();
            row2["Nom"] = "Thierry";
            row2["Ville"] = tableVille.Rows[0]["id"];
            tablePersonne.Rows.Add(row2);
            ds.AcceptChanges();
        }
    }
}
