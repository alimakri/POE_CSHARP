using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I_HttpModule
{
    public class MonModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            app.Response.Write("Appel depuis Context_EndRequest");
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            app.Response.Write("Appel depuis Context_BeginRequest");
        }
    }
}