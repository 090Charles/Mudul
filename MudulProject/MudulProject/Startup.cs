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
           // WebSecurity.InitializeDatabaseConnection("MoodleConnection", "UserProfile", "UserId", "UserName", true);

            //WebSecurity.CreateUserAndAccount("Admin", "Admin");
         //   Roles.CreateRole("Administrator");
           // Roles.AddUserToRole("Admin", "Administrator");
        }
    }
}
