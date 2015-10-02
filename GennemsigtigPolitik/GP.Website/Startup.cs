using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GP.Website.Startup))]
namespace GP.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
