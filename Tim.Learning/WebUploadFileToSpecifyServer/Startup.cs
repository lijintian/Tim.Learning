using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUploadFileToSpecifyServer.Startup))]
namespace WebUploadFileToSpecifyServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
