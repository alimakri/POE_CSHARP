using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZ_Eval.Models;

namespace ZB_Eval.Binders
{
    public class neveuModelBinder: IModelBinder
    {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var request = controllerContext.HttpContext.Request; // objet request info client 
                var principal = request.Form["personnagePrincipal"]; // toutes les infos du body dans form  --- querystring à la place de form si c'est dans l'url 
                var n1 = request.Form["neveu1"];
                var n2 = request.Form["neveu2"];
                var n3 = request.Form["neveu3"];

                List<string> neuveux  = new List<string>() ;

                neuveux.Add(n1);
                neuveux.Add(n2);
                neuveux.Add(n3);

                var p = new DuckFamily { Principal = principal, Neveus = neuveux };
                return p;
            }
        }
    }