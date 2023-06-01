using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ZB_Eval.Controllers
{
    public class ApiMathController : ApiController
    {
        public string Get(string mathematicien)
        {
            var photo = HttpContext.Current.Server.MapPath($"/images/{mathematicien}.png");
            var formule = HttpContext.Current.Server.MapPath($"/images/formule_{mathematicien}.png");
            return JsonConvert.SerializeObject(new
            {
                Mathematicien = mathematicien.Substring(0,1).ToUpper() + mathematicien.Substring(1).ToLower(),
                Photo= System.IO.File.ReadAllBytes(photo),
                Formule= System.IO.File.ReadAllBytes(formule)
            });
        }
    }
}
