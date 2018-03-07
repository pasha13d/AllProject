using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POSW.Startup))]
namespace POSW
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
