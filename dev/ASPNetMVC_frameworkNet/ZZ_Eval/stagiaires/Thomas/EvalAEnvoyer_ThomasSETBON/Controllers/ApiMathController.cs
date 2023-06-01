using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ZB_Eval.Controllers
{
    public class ApiMathController : ApiController
    {

        public string Get(string nom)
        {
            var imagePath = HttpContext.Current.Server.MapPath($@"\images\{nom}.png");
            var photo = System.IO.File.ReadAllBytes(imagePath);
            var imagePath2 = HttpContext.Current.Server.MapPath($@"\images\formule_{nom}.png");
            var photo2 = System.IO.File.ReadAllBytes(imagePath2);
            var fiche = new Mathematicien
            {
                NomMathematicien = nom,
                Photo = photo,
                Formule = photo2
            };

            var fichej = JsonConvert.SerializeObject(fiche);
            return fichej;
        }

        //public string Get(string nom)
        //{

        //    var fiche = new Mathematicien
        //    {
        //        NomMathematicien = nom,
        //        Photo = GetImage($@"\images\{nom}.png"),
        //        Formule = GetImage($@"\images\formule_{nom}.png")
        //    };

        //var fichej = JsonConvert.SerializeObject(fiche);
        //    return fichej;
        //}

        //private byte[] GetImage(string image)
        //{
        //    var imagePath = HttpContext.Current.Server.MapPath(image);
        //    var photo = System.IO.File.ReadAllBytes(image);
        //    return photo;
        //}
    }

    public class Mathematicien
    {
        public string NomMathematicien { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Formule { get; set; }
    }

}

