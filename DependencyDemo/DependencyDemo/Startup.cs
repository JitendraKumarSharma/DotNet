using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DependencyDemo.Startup))]
namespace DependencyDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
