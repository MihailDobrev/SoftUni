namespace WebServer.ByTheCakeApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Helpers;
    using Models;
    using Services;

    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using Server.HTTP;

    public class ShoppingController : Controller
    {
        private readonly IProductService products;
        private readonly IUserService users;
        private readonly IShoppingService shopping;

        public ShoppingController()
        {
            this.users = new UserService();
            this.products = new ProductService();
            this.shopping = new ShoppingService();
        }

        public IHttpResponse AddToCart(IHttpRequest request)
        {
            int id = int.Parse(request.UrlParameters["id"]);

            bool productExists = this.products.Exists(id);

            if (!productExists)
            {
                return new NotFoundResponse();
            }

            ShoppingCart shoppingCart = request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            shoppingCart.ProductsIds.Add(id);

            string redirectUrl = "/search";

            const string searchTermKey = "searchTerm";

            if (request.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={request.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest request)
        {
            var shoppingCart = request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.ProductsIds.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0";
            }
            else
            {
                var productsInCart = this.products
                    .FindProductsInCart(shoppingCart.ProductsIds);

                var items = productsInCart
                    .Select(pr => $"<div>{pr.Name} - ${pr.Price:F2}</div> <br />");

                this.ViewData["cartItems"] = string.Join(string.Empty, items);

                decimal totalPrice = productsInCart
                    .Sum(pr => pr.Price);

                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"Shopping\Cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest request)
        {
            string username = request.Session.Get<string>(SessionStore.currentUserKey);
            ShoppingCart shoppingCart = request.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            int? userId = this.users.GetUserId(username);

            if (userId == null)
            {
                throw new InvalidOperationException($"User {username} does not exist");
            }

            List<int> productIds = shoppingCart.ProductsIds;

            if (!productIds.Any())
            {
                return new RedirectResponse("/");
            }

            this.shopping.CreateOrder(userId.Value, productIds);

            shoppingCart.ProductsIds.Clear();

            return this.FileViewResponse(@"Shopping\Finish-order");
        }

    }
}
