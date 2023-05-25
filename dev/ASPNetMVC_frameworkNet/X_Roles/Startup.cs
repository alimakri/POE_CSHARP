using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(X_Roles.Startup))]
namespace X_Roles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
