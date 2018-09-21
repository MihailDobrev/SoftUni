namespace WebServer.ByTheCakeApp
{
    using Microsoft.EntityFrameworkCore;
    using Controllers;
    using Data;
    using ViewModels.Products;
    using ViewModels.User;
    using Server.Contracts;
    using Server.Routing.Contracts;

    public class ByTheCakeApplication : IApplication
    {
        public void InitializeDatabase()
        {
            using (var db = new ByTheCakeDbContext())
            {
                db.Database.Migrate();
            }
        }
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", req => new HomeController().Index());

            appRouteConfig.Get("/about", req => new HomeController().About());

            appRouteConfig.Get("/add", req => new ProductsController().Add());

            appRouteConfig.Post("/add", req => new ProductsController().Add(new ProductsViewModel//req.FormData["name"], req.FormData["price"]) 
            {
                Name = req.FormData["name"],
                Price = decimal.Parse(req.FormData["price"]),
                ImageUrl= req.FormData["imageUrl"]
            }));

            appRouteConfig.Get("/search", req => new ProductsController().Search(req));

            appRouteConfig.Get("/login", req => new UserController().Login());

            appRouteConfig.Post("/login", req => new UserController().Login(req, new LoginViewModel()
            {
                Username = req.FormData["username"],
                Password = req.FormData["password"]
            }));

            appRouteConfig.Get("/shopping/add/{(?<id>[0-9]+)}", req => new ShoppingController().AddToCart(req));

            appRouteConfig.Get("/cart", req => new ShoppingController().ShowCart(req));

            appRouteConfig.Post("/shopping/finish-order", req => new ShoppingController().FinishOrder(req));

            appRouteConfig.Get("/cakeDetails/{(?<id>[0-9]+)}", req => new ProductsController().Details(req));

            appRouteConfig.Post("/logout", req => new UserController().Logout(req));

            appRouteConfig.Get("/register", req => new UserController().Register());

            appRouteConfig.Post("/register", req => new UserController().Register(req, new RegisterUserViewModel
            {
                UserName = req.FormData["username"],
                Password = req.FormData["password"],
                ConfirmPassword = req.FormData["confirm-password"]
            }));

            appRouteConfig.Get("/profile", req => new UserController().Profile(req));

            appRouteConfig.Get("/orders", req => new OrdersController().ShowOrders(req));

            appRouteConfig.Get("/orderDetails/{(?<id>[0-9]+)}", req => new OrdersController().Details(req));
        }
    }
}
