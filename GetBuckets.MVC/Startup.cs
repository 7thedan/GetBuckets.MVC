using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetBuckets.MVC.Startup))]
namespace GetBuckets.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
