namespace WebServer.ByTheCakeApp
{
    using WebServer.ByTheCakeApp.Controllers;
    using WebServer.Server.Contracts;
    using WebServer.Server.Routing.Contracts;

    public class ByTheCakeApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", req=> new HomeController().Index());

            appRouteConfig.Get("/about", req => new HomeController().About());

            appRouteConfig.Get("/add", req => new CakesController().Add());

            appRouteConfig.Post("/add", req => new CakesController().Add(req.FormData["name"], req.FormData["price"]));

            appRouteConfig.Get("/search", req => new CakesController().Search(req));

            appRouteConfig.Get("/login", req => new UserController().Login());

            appRouteConfig.Post("/login", req => new UserController().Login(req));

            appRouteConfig.Get("/shopping/add/{(?<id>[0-9]+)}", req => new ShoppingController().AddToCart(req));

            appRouteConfig.Get("/cart", req => new ShoppingController().ShowCart(req));

            appRouteConfig.Post("/shopping/finish-order", req => new ShoppingController().FinishOrder(req));

            appRouteConfig.Post("/logout", req => new UserController().Logout(req));
        }
    }
}
