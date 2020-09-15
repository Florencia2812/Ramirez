using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADMRamirez.Startup))]
namespace ADMRamirez
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
