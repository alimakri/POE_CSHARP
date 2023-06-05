using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

using ZZ_Eval.Models;

namespace E_LeControlleur__ModeleBuilder.Builder
{
    public class DuckFamilyModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            string personnagePrincipal = request.Form.Get("personnagePrincipal");
            string neveu1 = request.Form.Get("neveu1"); // neveu1 comme dans la page html name = "neveu1"
            string neveu2 = request.Form.Get("neveu2");
            string neveu3 = request.Form.Get("neveu3");

            DuckFamily family = new DuckFamily
            {
                Principal = personnagePrincipal,
                Neveus = new List<string> { neveu1, neveu2, neveu3 }
            };

            return family;
        }
    }
}

