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
        public string GetCodeHtml() { return CodeHtml; }
        
        public Dictionary<string, object> Get(string op)
        {
            var dico = new Dictionary<string, object>();
            switch (op)
            {
                case "occupation":
                    // http://localhost:57974/api/get/occupation
                    Regex reg1 = new Regex(@"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>([^<]+)<");
                    var reponses1 = reg1
                        .Matches(CodeHtml).Cast<Match>()
                        .ToList();
                    foreach(var x in reponses1)
                    {
                        dico.Add(x.Groups[1].Value.Replace("\n", "").Replace("\t", "").Trim(), x.Groups[2].Value.Replace("\n", "").Replace("\t", "").Trim());
                    }
                    break;
                case "capacite":
                    // http://localhost:57974/api/get/capacite
                    Regex reg2 = new Regex(@"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>[^<]+<[^<]+<[^<]+<[^<]+<[^>]+>[^:]*:  ([0-9]*)");
                    var reponses2 = reg2
                        .Matches(CodeHtml).Cast<Match>()
                        .ToList();
                    foreach(var x in reponses2)
                    {
                        dico.Add(x.Groups[1].Value.Replace("\n", "").Replace("\t", "").Trim(), x.Groups[2].Value.Replace("\n", "").Replace("\t", "").Trim());
                    }
                    break;
            }
            return dico;
        }
    }
}
