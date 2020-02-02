using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordBook.Startup))]
namespace WordBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
