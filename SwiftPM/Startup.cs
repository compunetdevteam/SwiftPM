using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SwiftPM.Startup))]
namespace SwiftPM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
