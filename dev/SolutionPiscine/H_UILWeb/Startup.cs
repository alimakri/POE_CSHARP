using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(H_UILWeb.Startup))]
namespace H_UILWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
