using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Story_Maker_Sridhar.Startup))]
namespace Online_Story_Maker_Sridhar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
