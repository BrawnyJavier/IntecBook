using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ximplit_WallApp.Startup))]
namespace Ximplit_WallApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
