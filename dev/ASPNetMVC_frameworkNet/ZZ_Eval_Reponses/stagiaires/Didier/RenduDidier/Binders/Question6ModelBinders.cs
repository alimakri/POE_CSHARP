using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZB_Eval.Binders
{
    public class Question6ModelBinders : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            //var id = request.Form["id"];
            var principal = request.Form["principal"];
            var neveu = request.Form["neveu"]; List<string> ListeNeveu = neveu.Split(',').ToList();// ça doit être une liste de string !!!  
            //var value = request.Form["value"];
            var family = new
            { //Id = id ,
                Principal = principal,
                Neveus = neveu,
                //value = value
            };
            return family;
        }
    }
}