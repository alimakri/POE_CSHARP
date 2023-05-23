using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(M_LeControleur_Authentication.Startup))]
namespace M_LeControleur_Authentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
