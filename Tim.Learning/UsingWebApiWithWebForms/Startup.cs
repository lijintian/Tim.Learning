using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsingWebApiWithWebForms.Startup))]
namespace UsingWebApiWithWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
