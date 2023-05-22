using E_LeControleur_ModelBinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LeControleur_ModelBinder.Binders
{
    public class PersonneModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var id = int.Parse(request.Form["id"]);
            var nom = request.Form["nom"];
            var dateNaissance = DateTime.ParseExact(request.Form["DateNaissance"], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var p = new Personne { Id = id, Nom = nom, DateNaissance = dateNaissance };
            return p;
        }
    }
}