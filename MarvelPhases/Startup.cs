using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarvelPhases.Startup))]
namespace MarvelPhases
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
