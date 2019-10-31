using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scraper_Application.Startup))]
namespace Scraper_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
