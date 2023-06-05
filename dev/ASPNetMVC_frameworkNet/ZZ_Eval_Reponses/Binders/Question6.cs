using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZZ_Eval.Models;
using System.Web.Mvc;

namespace ZB_Eval.Binders
{
    public class PersonneModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var idPersoPrincipal = request.Form["personnagePrincipal"];
            var nomPersoPrincipal = request.Form["value"];
            var idNeveu1 = request.Form["neveu1"];
            var nomNeveu1 = request.Form["value"];
            var idNeveu2 = request.Form["neveu2"];
            var nomNeveu2 = request.Form["value"];
            var idNeveu3 = request.Form["neveu3"];
            var nomNeveu3 = request.Form["value"];


            var famille = new DuckFamily
            {
                Principal = nomPersoPrincipal,
                Neveus=new List<string>
                {
                    nomNeveu1,
                    nomNeveu2, nomNeveu3,
                }
                
            };
            return famille;

        }


    }
}