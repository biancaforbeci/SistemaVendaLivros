using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaVendaLivros.Startup))]
namespace SistemaVendaLivros
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
