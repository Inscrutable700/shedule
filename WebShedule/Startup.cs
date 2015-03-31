using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShedule.Startup))]
namespace WebShedule
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
