using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitTesting.Startup))]
namespace UnitTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
