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

            // Ecrire Le Cookie
            // https://stackoverflow.com/questions/3140341/how-can-i-create-persistent-cookies-in-asp-net
            //create a cookie
            HttpCookie myCookie = new HttpCookie("LeCookie");

            //Add key-values in the cookie
            myCookie.Values.Add("Valeur", $"{prenom} {nom}");

            //set cookie expiry date-time. Made it to last for next 12 hours.
            myCookie.Expires = DateTime.Now.AddMinutes(1);

            //Most important, write the cookie to client.
            Response.Cookies.Add(myCookie);
        }
    }
}