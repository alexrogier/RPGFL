using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RPGFL_WebServices.Startup))]
namespace RPGFL_WebServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
