using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace ZB_Eval.Controllers
{
    public class ApiMathController : ApiController
    {
        // si ? on passe pas par la route
        public string Get (string id)
        {
            var photo = HttpContext.Current.Server.MapPath($"/images/{id}.png");
            var formule = HttpContext.Current.Server.MapPath($"/images/formule_{id}.png");
            return JsonConvert.SerializeObject(new
            {
                Mathematicien = id.Substring(0,1).ToUpper() + id.Substring(1).ToLower(),
                Photo= System.IO.File.ReadAllBytes(photo),
                Formule= System.IO.File.ReadAllBytes(formule)
            });        
        }
    }
}
