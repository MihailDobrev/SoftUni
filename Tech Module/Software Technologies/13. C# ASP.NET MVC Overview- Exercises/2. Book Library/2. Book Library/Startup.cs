using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2.Book_Library.Startup))]
namespace _2.Book_Library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
