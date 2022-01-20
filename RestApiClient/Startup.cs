using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestApiClient.Startup))]
namespace RestApiClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
