using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewJersyTrafficTicket.Startup))]
namespace NewJersyTrafficTicket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
