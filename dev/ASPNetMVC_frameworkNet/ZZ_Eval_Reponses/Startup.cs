using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZZ_Eval.Startup))]
namespace ZZ_Eval
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
