using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace S_Web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nom="", prenom="";
            if (Request.HttpMethod == "GET")
            {
                nom = Request.QueryString["nom"];
                prenom = Request.QueryString["prenom"];
            }
            else if (Request.HttpMethod == "POST")
            {
                nom = Request.Form["nom"];
                prenom = Request.Form["prenom"];
            }
            Nom.Text = nom;
            Prenom.Text = prenom;
        }
    }
}