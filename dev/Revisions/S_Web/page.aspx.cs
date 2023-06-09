using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace S_Web
{
    public partial class page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["LeCookie"];
            if (myCookie != null && !string.IsNullOrEmpty(myCookie.Values["Valeur"]))
            {
                LeCookie.Text = myCookie.Values["Valeur"].ToString();
            }
        }
    }
}