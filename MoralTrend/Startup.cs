using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoralTrend.Startup))]
namespace MoralTrend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
