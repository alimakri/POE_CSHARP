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
        public IHttpActionResult Get()
        {
            var path = HttpContext.Current.Server.MapPath("/image/einstein.png");
            var photo = System.IO.File.ReadAllBytes(path);
            var photoBase64 = Convert.ToBase64String(photo);



            var mathematicien = new
            {
                nom = "Albert Einstein",
                Photo = Convert.ToBase64String(photo),
                Formule = "formule_einstein.png"
            };

            return Ok(mathematicien);
        }
    }
}


