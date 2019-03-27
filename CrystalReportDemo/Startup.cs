using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrystalReportDemo.Startup))]
namespace CrystalReportDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
