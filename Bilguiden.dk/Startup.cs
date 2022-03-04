using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bilguiden.dk.Startup))]
namespace Bilguiden.dk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
