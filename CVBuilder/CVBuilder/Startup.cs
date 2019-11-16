using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVBuilder.Startup))]
namespace CVBuilder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
