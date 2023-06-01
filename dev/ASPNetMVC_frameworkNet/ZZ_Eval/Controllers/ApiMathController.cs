using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using System.Web.UI.WebControls;

namespace ZB_Eval.Controllers
{
    public class ApiMathController : ApiController
    {
        //Je n'arrive pas à enregistrer les images, ReadAllBytes() ne fait que lire puis fermer le fichier, alors que WriteAllBytes le réécrit
        public string Get(string id)
        {
            if (id.ToUpper() == "RAMANUJAN")
            {
                var pathPhoto = HttpContext.Current.Server.MapPath("/images/ramanujan.png;base64,");
                var pathFormule = HttpContext.Current.Server.MapPath("/images/formule_ramanujan.png;base64,");
                return JsonConvert.SerializeObject(new
                {
                    Mathematicien = id,
                    Photo = System.IO.File.ReadAllBytes(pathPhoto),
                    Formule = System.IO.File.ReadAllBytes(pathFormule),
                });
            }
            else if (id.ToUpper() == "EINSTEIN")
            {
                var pathPhoto = HttpContext.Current.Server.MapPath("/images/einstein.png;base64,");
                var pathFormule = HttpContext.Current.Server.MapPath("/images/formule_einstein.png;base64,");
                return JsonConvert.SerializeObject(new
                {
                    Mathematicien = id,
                    Photo = System.IO.File.ReadAllBytes(pathPhoto),
                    Formule = System.IO.File.ReadAllBytes(pathFormule),
                });
            }
            else
                return null;

        }

    }

}
