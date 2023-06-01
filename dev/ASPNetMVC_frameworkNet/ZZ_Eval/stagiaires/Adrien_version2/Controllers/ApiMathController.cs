using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ZB_Eval.Controllers
{
    public class ApiMathController : ApiController
    {
        
        
        public string Get (string nom)
        {
            var fiche = new Fiche();
            fiche.mathematicien = nom;

            var pathPhoto = HttpContext.Current.Server.MapPath("/images/"+ nom + ".png");
            var pathFormule = HttpContext.Current.Server.MapPath("/images/formule_"+ nom + ".png");

            fiche.Photo = System.IO.File.ReadAllBytes(pathPhoto);
            fiche.Formule = System.IO.File.ReadAllBytes(pathFormule);

            var result = new {
                Nom = fiche.mathematicien,
                Photo = fiche.Photo,
                Formule = fiche.Formule
            };

            return JsonConvert.SerializeObject(result);
        }
    }
}