namespace WebServer.Application
{
    using Server.Contracts;
    using Server.Routing.Contracts;
    using Application.Controllers;

    public class MainApplication : IApplication
    { 
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/", httpContext => new HomeController().Index());

            appRouteConfig.Get("/register", httpContext => new UserController().RegisterGet());

            appRouteConfig.Post("/register", httpContext => new UserController().RegisterPost(httpContext.FormData["name"]));

            appRouteConfig.Get("/user/{(?<name>[a-z]+)}", httpContext => new UserController().Details(httpContext.UrlParameters["name"]));
        }
    }
}
