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
        private const string DataFile = @"d:\horaires-frequentation-piscines.txt";
        private readonly string CodeHtml;
        public PiscineController()
        {
            if (File.Exists(DataFile))
            {
                CodeHtml = File.ReadAllText(DataFile);
            }
            else
            {
                WebClient clientStarsbourg_eu = new WebClient();
                CodeHtml = clientStarsbourg_eu.DownloadString("https://www.strasbourg.eu/horaires-frequentation-piscines");
                File.WriteAllText(DataFile, CodeHtml);
            }
        }
        public string Get() { return CodeHtml; }
        public List<string> GetAllPiscines(string op)
        {
            switch (op)
            {
                case "all":
                    Regex reg = new Regex(@"<td class=""place-name"">([^<]+)");
                    var reponse = reg.Matches(CodeHtml).Cast<Match>().Select(x => x.Groups[1].Value.Replace("\n", "").Replace("\t", "").Trim()).ToList();
                    return reponse;
            }
            return null;
        }
        // api/piscine/occupation/CENTRE%20NAUTIQUE%20DE%20SCHILTIGHEIM
        public int GetOcupation(string op, string piscine)
        {
            switch (op)
            {
                case "occupation":
                    Regex reg = new Regex(@"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>([^<]+)<");
                    var reponses = reg.Matches(CodeHtml).Cast<Match>().Select(x => 
                        new
                        {
                            Nom = x.Groups[1].Value.Replace("\n", "").Replace("\t", "").Trim(),
                            Occupation = x.Groups[2].Value.Replace("\n", "").Replace("\t", "").Trim()
                        }).ToList();
                    var n = reponses.FirstOrDefault(x=>x.Nom.ToUpper() == piscine.ToUpper())?.Occupation;
                    int o = -1;
                    int.TryParse(n, out o);
                    return o;
            }
            return -1;
        }
    }
}
