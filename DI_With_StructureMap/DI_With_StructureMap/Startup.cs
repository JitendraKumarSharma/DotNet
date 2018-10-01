using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DI_With_StructureMap.Startup))]
namespace DI_With_StructureMap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
