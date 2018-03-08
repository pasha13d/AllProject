using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityCourseAndResultApp.Startup))]
namespace UniversityCourseAndResultApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
