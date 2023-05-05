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
        private string Regex;
        #endregion

        public PiscineController()
        {
        }

        public Dictionary<string, object> Post(string cle, string cache, [FromBody] string regex)
        {
            Regex = regex;
            if (File.Exists(DataFile) && cache != "nocache")
            {
                // Lecture du cache
                CacheHtml = File.ReadAllText(DataFile);
            }
            else
            {
                // Maj du cache (temps réel)
                WebClient clientStarsbourg_eu = new WebClient();
                CacheHtml = clientStarsbourg_eu.DownloadString("https://www.strasbourg.eu/horaires-frequentation-piscines");
                File.WriteAllText(DataFile, CacheHtml);
            }

            switch (cle)
            {
                case "Occupation":
                case "Capacite":
                    return Regex_Occupation();
                case "Horaires":
                    return Regex_Horaires();
                default:
                    throw new Exception("cle regex inconnue");
            }
        }

        private Dictionary<string, object> Regex_Horaires()
        {
            var dico = new Dictionary<string, object>();
            if (Regex != null)
            {
                Regex reg1 = new Regex(Regex);
                var reponses1 = reg1
                    .Matches(CacheHtml).Cast<Match>()
                    .ToList();
                foreach (var x in reponses1)
                {
                    var datetimes = new List<DateTime>();
                    int index = 2;
                    while (x.Groups[index].Value != null)
                    {
                        var horaires = x.Groups[index].Value.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (horaires.Length != 2) return dico;
                        datetimes.Add(new DateTime(1, 1, 1, int.Parse(horaires[0].Substring(0, 2)), int.Parse(horaires[0].Substring(2, 2)), 0));
                        datetimes.Add(new DateTime(1, 1, 1, int.Parse(horaires[1].Substring(0, 2)), int.Parse(horaires[1].Substring(2, 2)), 0));
                    }

                    dico.Add(
                        x.Groups[1].Value.Replace("\n", "").Replace("\t", "").Trim(),
                        datetimes);
                }
            }
            return dico;
        }

        private Dictionary<string, object> Regex_Occupation()
        {
            var dico = new Dictionary<string, object>();
            if (Regex != null)
            {
                Regex reg1 = new Regex(Regex);
                var reponses1 = reg1
                    .Matches(CacheHtml).Cast<Match>()
                    .ToList();
                foreach (var x in reponses1)
                {
                    dico.Add(
                        x.Groups[1].Value.Replace("\n", "").Replace("\t", "").Trim(),
                        x.Groups[2].Value.Replace("\n", "").Replace("\t", "").Trim());
                }
            }
            return dico;
        }
    }
}
