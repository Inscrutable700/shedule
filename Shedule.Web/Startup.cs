using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shedule.Web.Startup))]
namespace Shedule.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
