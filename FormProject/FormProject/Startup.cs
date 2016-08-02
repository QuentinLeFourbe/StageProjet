using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormProject.Startup))]
namespace FormProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
