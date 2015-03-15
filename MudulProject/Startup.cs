using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MudulProject.Startup))]
namespace MudulProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
