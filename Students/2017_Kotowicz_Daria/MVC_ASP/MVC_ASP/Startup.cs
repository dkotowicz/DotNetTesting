using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_ASP.Startup))]
namespace MVC_ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
