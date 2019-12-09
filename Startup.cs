using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vicky.Startup))]
namespace Vicky
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
