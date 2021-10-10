using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIGEVALP.Startup))]
namespace SIGEVALP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
