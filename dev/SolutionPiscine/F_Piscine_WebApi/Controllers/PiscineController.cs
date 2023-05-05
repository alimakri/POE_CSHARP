using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace F_Piscine_WebApi.Controllers
{
    public class PiscineController : ApiController
    {
        #region Propriétés
        private const string DataFile = @"d:\horaires-frequentation-piscines.txt";
        private string CacheHtml;
        #endregion

        public PiscineController()
        {
        }

        public Dictionary<string, object> Post(string cache, [FromBody] string regex)
        {
            if (File.Exists(DataFile) && cache != "nocache")
            {
                CacheHtml = File.ReadAllText(DataFile);
            }
            else
            {
                WebClient clientStarsbourg_eu = new WebClient();
                CacheHtml = clientStarsbourg_eu.DownloadString("https://www.strasbourg.eu/horaires-frequentation-piscines");
                File.WriteAllText(DataFile, CacheHtml);
            }
            var dico = new Dictionary<string, object>();
            if (regex != null)
            {
                Regex reg1 = new Regex(regex);
                var reponses1 = reg1
                    .Matches(CacheHtml).Cast<Match>()
                    .ToList();
                foreach (var x in reponses1)
                {
                    dico.Add(x.Groups[1].Value.Replace("\n", "").Replace("\t", "").Trim(), x.Groups[2].Value.Replace("\n", "").Replace("\t", "").Trim());
                }
            }
            return dico;
        }
    }
}
