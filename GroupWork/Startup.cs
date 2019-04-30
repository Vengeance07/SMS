using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroupWork.Startup))]
namespace GroupWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
