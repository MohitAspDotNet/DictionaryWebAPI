using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SatyaWebApiClient.Web.Startup))]
namespace SatyaWebApiClient.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
