using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace J_HttpHandler
{
    public class MonHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            var urlTab = context.Request.Url.ToString().Split('/');
            var url = urlTab[urlTab.Length - 1];
            
            var path = context.Server.MapPath(url);
            if (!System.IO.File.Exists(path)) path = context.Server.MapPath("error.m2i");
            var content = System.IO.File.ReadAllText(path);
            context.Response.Write(content);
        }
    }
}