using System.Web;
using System.Web.Mvc;

namespace D_WebApiPost_Serveur
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
