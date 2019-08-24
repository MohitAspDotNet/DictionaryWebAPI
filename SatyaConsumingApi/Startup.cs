using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SatyaConsumingApi.Startup))]
namespace SatyaConsumingApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
