using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeacherStudent.Startup))]
namespace TeacherStudent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
