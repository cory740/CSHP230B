using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CEby_Website.Startup))]
namespace CEby_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
