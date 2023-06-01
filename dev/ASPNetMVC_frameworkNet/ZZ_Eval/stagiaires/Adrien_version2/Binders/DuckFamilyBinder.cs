using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using ZZ_Eval.Models;

namespace ZB_Eval.Binders
{
    public class DuckFamilyBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var personnagePrincipal = request.Form["personnagePrincipal"];
            var neveu1 = request.Form["neveu1"];
            var neveu2 = request.Form["neveu2"];
            var neveu3 = request.Form["neveu3"];
            var family = new DuckFamily { Principal = personnagePrincipal, Neveus = new List<string> { neveu1, neveu2, neveu3 } };
            return family;
        }
    }
}