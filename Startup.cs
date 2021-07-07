using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rvas_ispit_projekat.Startup))]
namespace Rvas_ispit_projekat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
