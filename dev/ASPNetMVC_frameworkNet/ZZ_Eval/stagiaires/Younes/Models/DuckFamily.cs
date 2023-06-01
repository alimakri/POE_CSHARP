using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZ_Eval.Models
{
    public class DuckFamily
    {
        public string Principal { get; set; }
        public List<string> Neveus { get; set; }
    }
    //modele binder
    public class DuckFamilyModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;

            var principal = form.Get("personnagePrincipal");
            var neveus = new[] { form.Get("neveu1"), form.Get("neveu2"), form.Get("neveu3") };

            return new DuckFamily
            {
                Principal = principal,
                Neveus = neveus
            };
        }
    }

}