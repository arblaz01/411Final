using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS411Final.Startup))]
namespace CIS411Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
