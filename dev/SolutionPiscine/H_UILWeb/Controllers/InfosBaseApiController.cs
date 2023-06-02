using H_UILWeb.Dto;
using H_UILWeb.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PiscineBOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace H_UILWeb.Controllers
{
    public class InfosBaseApiController : ApiController
    {
        public List<PiscineViewModel> Piscines;
        private ClientWebApi Api = new ClientWebApi();
        public string Get()
        {
            if (Metier.IsInit())
            {
                //Metier.NouveauRegex("Capacite", @"<td class=""place-name"">[\n\t ]*(.*?)[\n\t ]*<\/td>(?:.*?)*(?:\s)*([0-9]*)(?:.*?)(?:\s)*<td(?:.*?)>(?:\s)*<div(?:.*?)>(?:[\s-])*<\/div>(?:\s)*<div(?:.*?)>(?:[A-zé\n\s-])*<\/div>(?:\s)*<div(?:.*?)>(?:\s*?)[\s]*Capacité totale :  [0-9]*");
                Metier.NouveauRegex("Occupation", @"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>([^<]+)<");
                Metier.NouveauRegex("Capacite", @"<td class=""place-name"">([^<]+)[^<]+<[^<]+<[^<]+<[^>]+>[^<]+<[^<]+<[^<]+<[^<]+<[^>]+>[^:]*:  ([0-9]*)");
                Metier.NouveauRegex("Horaires", @"<td class=""place-name"">[\n\r\t ]*(.*?)[\n\r\t ]*</td>[\r\n\t ]*<td[^<]*<[^<]*<[^<]*<[^<]*<[^<]*<[^<]*<[^<]*<[^<]*<td class=""first-day"">[^<]*<div class=""opening-time (?:exception)?"">[\r\n\t ]*([0-9]{2}:[0-9]{2} - [0-9]{2}:[0-9]{2})*[\r\n\t ].*[\r\n\t ]*(?:<div class=""opening-time (?:exception)?"">[\r\n\t ]*([0-9]{2}:[0-9]{2} - [0-9]{2}:[0-9]{2})*[\r\n\t ].*[\r\n\t ]*)?");
                Metier.Init();
            }
            Metier.LoadConfigs();
            Piscines = Metier.GetPiscines(new ArrayList { 0 }).ToListPiscine();
            var dico = Api.CallAspnetApi("Horaires", @"<td class=""place-name"">[\n\r\t ]*(.*?)[\n\r\t ]*</td>[\r\n\t ]*<td[^<]*<[^<]*<[^<]*<[^<]*<[^<]*<[^<]*<[^<]*<[^<]*<td class=""first-day"">[^<]*<div class=""opening-time (?:exception)?"">[\r\n\t ]*([0-9]{2}:[0-9]{2} - [0-9]{2}:[0-9]{2})*[\r\n\t ].*[\r\n\t ]*(?:<div class=""opening-time (?:exception)?"">[\r\n\t ]*([0-9]{2}:[0-9]{2} - [0-9]{2}:[0-9]{2})*[\r\n\t ].*[\r\n\t ]*)?");
            foreach (var piscine in Piscines)
            {
                piscine.Horaires = new List<DateTime>();
                if (dico.ContainsKey(piscine.Nom))
                {
                    foreach (JToken token in (Newtonsoft.Json.Linq.JArray)dico[piscine.Nom])
                    {
                        if (DateTime.TryParse(token.ToString(), out DateTime dateTime))
                        {
                            piscine.Horaires.Add(dateTime);
                        }
                    }
                    piscine.HorairesStr = new List<string>();
                    for (int i = 0; i < piscine.Horaires.Count; i += 2)
                    {
                        piscine.HorairesStr.Add($"{piscine.Horaires[i].ToString("HH:mm")} - {piscine.Horaires[i + 1].ToString("HH:mm")}");
                    }
                }
            }
            return JsonConvert.SerializeObject(Piscines);
        }
    }
}
