using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(isrpo_practice.Startup))]
namespace isrpo_practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
