using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Z4_Dto;

namespace Z5_Donnees
{
    public class Repository
    {
        internal DataSet2 GetPersonnes()
        {
            var data = File.ReadAllText(@"Personnes.txt");
            Regex reg1 = new Regex(@"([0-9]+). ([^ ]+) ([^\n]+)");
            var matches = reg1
                .Matches(data).Cast<Match>()
                .Select(x=>new { Id = x.Groups[1].Value, Prenom = x.Groups[2].Value, Nom = x.Groups[3].Value })
                .ToList();

            var ds2 = new DataSet2();
            foreach(var match in matches)
            {
                var newRow = ds2.Tables[0].NewRow();
                newRow["Id"] = match.Id;
                newRow["Nom"] = match.Nom;
                newRow["Prenom"] = match.Prenom;
                ds2.Tables[0].Rows.Add(newRow);
            }
            return ds2;
        }
    }
}
