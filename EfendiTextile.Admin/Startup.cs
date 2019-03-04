using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EfendiTextile.Admin.Startup))]
namespace EfendiTextile.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
