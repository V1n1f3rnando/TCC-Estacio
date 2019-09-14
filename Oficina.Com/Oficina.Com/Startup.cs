using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oficina.Com.Startup))]
namespace Oficina.Com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
