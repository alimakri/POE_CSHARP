using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ZB_Eval.Models;

namespace ZZ_Eval.Controllers
{
    public class ApiMathController : ApiController
    {
        private byte[] fiche;

        internal Fiche GetImage(string id)
        {
            var fiche = new Fiche();

            if (id == "einstein")
            {
                var path1 = HttpContext.Current.Server.MapPath("C:\\Users\\Amélie\\Downloads\\POE_CSHARP-mainEXAM\\POE_CSHARP-main\\dev\\ASPNetMVC_frameworkNet\\ZZ_Eval_Reponses\\images\\formule_einstein.png");
                var path2 = HttpContext.Current.Server.MapPath("C:\\Users\\Amélie\\Downloads\\POE_CSHARP-mainEXAM\\POE_CSHARP-main\\dev\\ASPNetMVC_frameworkNet\\ZZ_Eval_Reponses\\images\\einstein.png");
                fiche.Formule = System.IO.File.ReadAllBytes(path1);
                fiche.Photo = System.IO.File.ReadAllBytes(path2);
                fiche.Mathematicien = "Einstein";
            }

            if (id == "ramanujan")
            {
                var path1 = HttpContext.Current.Server.MapPath("C:\\Users\\Amélie\\Downloads\\POE_CSHARP-mainEXAM\\POE_CSHARP-main\\dev\\ASPNetMVC_frameworkNet\\ZZ_Eval_Reponses\\images\\formule_ramanujan.png");
                var path2 = HttpContext.Current.Server.MapPath("C:\\Users\\Amélie\\Downloads\\POE_CSHARP-mainEXAM\\POE_CSHARP-main\\dev\\ASPNetMVC_frameworkNet\\ZZ_Eval_Reponses\\images\\ramanujan.png");
                fiche.Formule = System.IO.File.ReadAllBytes(path1);
                fiche.Photo = System.IO.File.ReadAllBytes(path2);
                fiche.Mathematicien = "Ramanujan";
            }

            return fiche;

            //content = System.IO.File.ReadAllText(path);
        }

    }
}
