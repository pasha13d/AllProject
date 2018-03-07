using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDJ.UCommerce.Startup))]
namespace BDJ.UCommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
