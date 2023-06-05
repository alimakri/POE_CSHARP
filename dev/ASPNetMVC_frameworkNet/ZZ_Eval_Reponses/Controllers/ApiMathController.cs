using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ZB_Eval.Controllers
{
	public class DonneeMathematicien
	{
		public string Mathematicien;
		public byte[] Photo;
		public byte[] Formule;
	}
	public class ApiMathController : ApiController
	{
		// GET: ApiMath

		public string Get(string id)
		{
			var pathPhoto = HttpContext.Current.Server.MapPath($"/images/{id}.png");
			var pathFormule = HttpContext.Current.Server.MapPath($"/images/formule_{id}.png");
			var photo = System.IO.File.ReadAllBytes(pathPhoto);
			var formule = System.IO.File.ReadAllBytes(pathFormule);
			DonneeMathematicien data = new DonneeMathematicien
			{
				Mathematicien = Char.ToUpper(id[0]) + id.Substring(1),
				Photo = photo,
				Formule = formule
			};
			return JsonConvert.SerializeObject(data);
		}

	}
}