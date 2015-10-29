using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pro.Assur.Startup))]
namespace Pro.Assur
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
